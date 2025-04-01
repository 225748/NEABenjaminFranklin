using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEABenjaminFranklin
{
    public partial class cntrlRoleWithListVUsers : UserControl
    {
        public string RoleName { get; set; }
        public int RotaRoleNumber { get; set; }
        public int RotaID { get; set; }
        public List<string> UnassignableUsers = new List<string>();  //pulled from parent form as well as in cntrl istelf

        //These globals below are used when edit mode of AddEditNewInstance is active
        public bool PreSelectUsers { get; set; }
        public int InstanceID { get; set; }
        public List<clsUser> UsersList = new List<clsUser>();

        // -- //

        public List<int> AssignedRotaRoleIDs = new List<int>();

        public cntrlRoleWithListVUsers()
        {
            InitializeComponent();
        }

        private void cntrlRoleWithListVUsers_Load(object sender, EventArgs e)
        {
            lblRoleName.Text = RoleName;
            FillChkList();
        }
        private void FillChkList()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "Select (LastName & " + "', '" + "& FirstName) as Name, UserID, FirstName, LastName " +
                "FROM tblPeople " +
                "ORDER BY LastName, FirstName";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                lstVUsers.Items.Add(dr[0].ToString());
                lstVUsers.Items[lstVUsers.Items.Count - 1].SubItems.Add(dr[1].ToString());
                if (PreSelectUsers)
                {
                    clsUser user = new clsUser();
                    user.userID = Convert.ToInt32(dr[1].ToString());
                    user.chkListIndex = (lstVUsers.Items.Count - 1);
                    UsersList.Add(user);
                }
            }
            if (PreSelectUsers)
            {//do SQL to find if already assigned, if so then make selected true
                foreach (clsUser user in UsersList)
                {
                    dbConnector = new clsDBConnector();
                    sqlCommand = "SELECT tblRotaInstanceRoles.RotaInstanceRoleNumber, tblAssignedRotaRoles.UserID " +
                        "FROM(tblAssignedRotaRoles INNER JOIN " +
                        "tblRotaInstanceRoles ON tblAssignedRotaRoles.AssignedRotaRolesID = tblRotaInstanceRoles.AssignedRotaRolesID) " +
                        $"WHERE(tblRotaInstanceRoles.RotaInstanceID = {InstanceID}) AND(tblAssignedRotaRoles.RotaRoleNumber = {RotaRoleNumber}) " +
                        $"AND(tblAssignedRotaRoles.UserID = {user.userID})";
                    dbConnector.Connect();
                    dr = dbConnector.DoSQL(sqlCommand);
                    while (dr.Read())
                    {//Its found an assignedRotaRoleID
                        //MessageBox.Show(dr[1].ToString() + " " + dr[0].ToString());
                        lstVUsers.Items[user.chkListIndex].Checked = true;
                    }
                    dbConnector.Close();
                }
            }

        }
        private int FindLargestID(string tableName, string keyName)//largest ID is allways the one you have just created
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlStr;
            dbConnector.Connect();
            sqlStr = $" SELECT MAX({keyName}) AS maxID FROM {tableName} ";
            dr = dbConnector.DoSQL(sqlStr);
            while (dr.Read())
            {
                return Convert.ToInt32(dr[0]);
            }
            dbConnector.Close();
            return 0;
        }

        private int CheckForExistingAssignment(ListViewItem CheckedItem)
        {
            int userID = Convert.ToInt32(CheckedItem.SubItems[1].Text);
            return CheckForExistingAssignmentByUserID(userID);
        }
        //Reason for segmented function is some places have the userID but not the listview therefore skip the step above
        public int CheckForExistingAssignmentByUserID(int userID)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT AssignedRotaRolesID " +
                "FROM tblAssignedRotaRoles " +
                $"WHERE(RotaRoleNumber = {RotaRoleNumber}) " +
                $"AND(UserID = {userID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            int ret = 0;
            while (dr.Read())
            {
                ret = Convert.ToInt32(dr[0].ToString()); //return assignedRotaRoleID if there is one
            }
            dbConnector.Close();
            return ret;

        }
        public void AssignUsersToRotaRole(int rotaInstanceID)
        {
            for (int i = 0; i < lstVUsers.CheckedItems.Count; i++)
            {
                //First check for any conflicting unavailability
                int userID = Convert.ToInt32(lstVUsers.CheckedItems[i].SubItems[1].Text);
                bool unavailable = ((Application.OpenForms["frmAddEditNewInstance"] as frmAddEditNewInstance).CheckForUnavailabiliyConflict(userID, rotaInstanceID));
                //Reason why open form name is different from type is legacy - form was just add before dual use
               
                var result = DialogResult.No;//initalised here to use later
                if (unavailable)
                {
                    //Get their full name
                    string fullName = "";
                    clsDBConnector dbConnector = new clsDBConnector();
                    OleDbDataReader dr;
                    string sqlCommand = "SELECT FirstName, LastName " +
                        "FROM tblPeople " +
                        $"WHERE UserID = {userID}";
                    dbConnector.Connect();
                    dr = dbConnector.DoSQL(sqlCommand);
                    while (dr.Read())
                    {
                        fullName = (dr[0].ToString() + " " + dr[1].ToString());
                    }
                    dbConnector.Close();

                    result = MessageBox.Show($"{fullName} has conflicting unavailability with this date.\n" +
                        "Would you like to ignore this unavailability and assign them anyways?\n" +
                        $"(Currently Assigned to: {RoleName}" +
                        "", "Unavailability Conflict", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        //append their name to a list to read out at end (read out from form not each control) - form pulls these lists
                        UnassignableUsers.Add(fullName);
                    }

                    //if they still want to assign, proceed as usual
                }
                if (!unavailable | result == DialogResult.Yes)
                {//allows for all available users or users we have chosen to ignore their unavailability to continue with assignment

                    //check if they already have been assigned this rota role, if so do nothing
                    int existingAssignmentID = CheckForExistingAssignment(lstVUsers.CheckedItems[i]);
                    if (existingAssignmentID == 0) //none already existing, therfore can add a new one
                    {
                        clsDBConnector dbConnector = new clsDBConnector();
                        string cmdStr = $"INSERT INTO tblAssignedRotaRoles (RotaRoleNumber, UserID) " +
                            $"VALUES ({RotaRoleNumber}, '{Convert.ToInt32(lstVUsers.CheckedItems[i].SubItems[1].Text)}')";
                        dbConnector.Connect();
                        dbConnector.DoDML(cmdStr);
                        dbConnector.Close();
                        AssignedRotaRoleIDs.Add(FindLargestID("tblAssignedRotaRoles", "AssignedRotaRolesID"));
                    }
                    else //one already existing, add to assignedrotarolesIds list the assignedrotaRoleID returned from the check
                    {
                        AssignedRotaRoleIDs.Add(existingAssignmentID);
                    }
                }

            }
        }


    }
}
