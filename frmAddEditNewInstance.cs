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
    public partial class frmAddEditNewInstance : Form
    {
        public int RotaID { get; set; }
        public string RotaName { get; set; }
        public string ThemeColour { get; set; }
        public bool EditMode { get; set; }
        //IF edit mode
        public int EditModeInstanceID { get; set; }

        public frmAddEditNewInstance(int rotaID, string rotaName = "", string themeColour = "", bool editMode = false, int InstanceIDIfEditMode = 0)
        {
            InitializeComponent();
            RotaID = rotaID;

            //If we have only been given rotaID, do sql to get name and theme colour - provision for the cntrlRotaInstance creating an object of this
            //As the cntrl itself is not given this info

            if (rotaName == "" | themeColour == "")
            {
                clsDBConnector dbConnector = new clsDBConnector();
                OleDbDataReader dr;
                string sqlCommand = "SELECT RotaName, RotaThemeColour " +
                    "FROM tblRota " +
                    $"WHERE RotaID = {rotaID}";
                dbConnector.Connect();
                dr = dbConnector.DoSQL(sqlCommand);

                while (dr.Read())
                {
                    RotaName = dr[0].ToString();
                    ThemeColour = dr[1].ToString();
                }
                dbConnector.Close();
            }
            else
            {
                RotaName = rotaName;
                ThemeColour = themeColour;
            }
            EditMode = editMode;
            EditModeInstanceID = InstanceIDIfEditMode;

        }

        private void frmAddNewInstance_Load(object sender, EventArgs e)
        {
            FillFlp();
            dtpDate.MinDate = DateTime.Now;
            dtpTime.CustomFormat = "HH:mm"; //Captial HH for 24HR NOT for mins as that becomes month
            dtpTime.Format = DateTimePickerFormat.Custom;
            dtpTime.ShowUpDown = true;
            int lengthLimit = 20;
            if (RotaName.Length > lengthLimit)
            { lblRotaName.Text = RotaName.Substring(0, lengthLimit - 3) + "..."; }
            else { lblRotaName.Text = RotaName; }
            lblRotaName.Text = RotaName;
            if (ThemeColour == "0") //default - no user colour set
            {
                btnThemeColour.BackColor = Color.Silver;
            }
            else
            {
                btnThemeColour.BackColor = Color.FromArgb(Convert.ToInt32(ThemeColour));
            }

            if (EditMode)
            {
                
                this.Text = "Update / Delete Instance";
                pnlEditMode.Enabled = true;
                pnlEditMode.Show();
                btnAddInstance.Enabled = false;
                btnAddInstance.Hide();
            }
            else
            {
                this.Text = "Add New Instance";
                pnlEditMode.Enabled = false;
                pnlEditMode.Hide();
                btnAddInstance.Enabled = true;
                btnAddInstance.Show();
            }
        }
        private void FillFlp()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT tblRoles.RoleName, tblRotaRoles.RotaRoleNumber " +
                "FROM((tblRota INNER JOIN " +
                "tblRotaRoles ON tblRota.RotaID = tblRotaRoles.RotaID AND tblRota.RotaID = tblRotaRoles.RotaID) INNER JOIN " +
                "tblRoles ON tblRotaRoles.RoleNumber = tblRoles.RoleNumber) " +
                $"WHERE(tblRotaRoles.RotaID = {RotaID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                cntrlRoleWithListVUsers cntrlroleWithUsersList = new cntrlRoleWithListVUsers();
                cntrlroleWithUsersList.RoleName = dr[0].ToString();
                cntrlroleWithUsersList.RotaRoleNumber = Convert.ToInt32(dr[1]);
                cntrlroleWithUsersList.RotaID = RotaID;
                if (EditMode)
                {//Need to fill with currently selected users
                    cntrlroleWithUsersList.PreSelectUsers = true;
                    cntrlroleWithUsersList.InstanceID = EditModeInstanceID;
                }
                flpRoles.Controls.Add(cntrlroleWithUsersList);
            }
            dbConnector.Close();

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

        private bool CheckForExistingInstance(int rotaID, DateTime dateTime)
        {
            //MessageBox.Show(dateTime.ToString("MM/dd/yyyy HH:mm:00"));
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT RotaInstanceID " +
                "FROM tblRotaInstance " +
                $"WHERE (RotaID = {rotaID}) " +
                $"AND (RotaInstanceDateTime = #{dateTime.ToString("MM/dd/yyyy HH:mm:00")}#)"; //Convert date to us format with time
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                return true;
            }
            dbConnector.Close();
            return false;
        }

        private void AddNewInstance()
        {
            //assign users to roles and create an instance of this date and time
            DateTime dateTime = new DateTime(dtpDate.Value.Year,
                                    dtpDate.Value.Month,
                                    dtpDate.Value.Day,
                                    dtpTime.Value.Hour,
                                    dtpTime.Value.Minute,
                                    0, 0);


            //Need to do// -------
            //1. --- Check if this datetime  of this specific rota already exisits, if so dont do any more of these steps
            bool exists = CheckForExistingInstance(RotaID, dateTime);

            if (exists)
            {
                MessageBox.Show("An instance of this rota for this date and time already exists, please select another date/time", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                //1a.Create an instance of the rota with this datetime

                clsDBConnector dbConnector = new clsDBConnector();
                string cmdStr = $"INSERT INTO tblRotaInstance (RotaID, RotaInstanceDateTime) " +
                    $"VALUES ({RotaID}, '{Convert.ToString(dateTime)}')";
                dbConnector.Connect();
                dbConnector.DoDML(cmdStr);
                dbConnector.Close();
                int rotaInstanceID = FindLargestID("tblRotaInstance", "RotaInstanceID");

                foreach (cntrlRoleWithListVUsers cntrl in flpRoles.Controls)
                {
                    //2 check if an assigned rota role id for this user id, role and this rota already exsist, if so do not add one - do this in the cntrl
                    //2a.Create an assignedRotaRoleID using tblRotaRoles.RoleNumber and UserID for each role control
                    cntrl.AssignUsersToRotaRole();

                    //For a new instance we dont need to check if an instance role already exists - when editing you will need to check
                    //3.Create RotaInstanceRole Number using assignedRotaRoleID pulled from each control and RotaInstanceID from local var
                    for (int i = 0; i < cntrl.AssignedRotaRoleIDs.Count; i++)
                    {
                        dbConnector = new clsDBConnector();
                        cmdStr = $"INSERT INTO tblRotaInstanceRoles (RotaInstanceID, AssignedRotaRolesID) " +
                            $"VALUES ({rotaInstanceID}, {cntrl.AssignedRotaRoleIDs[i]})";
                        dbConnector.Connect();
                        dbConnector.DoDML(cmdStr);
                        dbConnector.Close();
                    }
                }

                //Check if successfull ----- to do
                MessageBox.Show("Date Added and User(s) Assigned Successfully", "Rota Connect Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateInstance(int rotaInstanceID)
        {
            List<clsUser> preUpdatelst = new List<clsUser>();
            List<clsUser> updatelst = new List<clsUser>();
            //  - remember lstVusers is the actual lists
            //  THEREFORE it is want the user wants as the update
            //  userslist is a list of checked users in a class list upon creation
            //  THEREFORE it can be used to compare as a comparison to see what has changed


            //For every cntrl in flproles, get each userID in its lstVUsers and see if checked
            foreach (cntrlRoleWithListVUsers cntrlRoleWithListVUsers in flpRoles.Controls)
            {
                for (int i = 0; i < cntrlRoleWithListVUsers.lstVUsers.Items.Count; i++)
                {//sub items of this list is userID
                    //This code gets userID of each user in a cntrl's listV and whether is it checked or not and assigns to an update list
                    clsUser user = new clsUser();
                    user.userID = Convert.ToInt32(cntrlRoleWithListVUsers.lstVUsers.Items[i].SubItems[1].Text);
                    if (cntrlRoleWithListVUsers.lstVUsers.Items[i].Checked == true)
                    {
                        user.CheckedinListV = true;
                    }
                    else
                    {
                        user.CheckedinListV = false;
                    }
                    updatelst.Add(user); //list containing all userIDs and whether they are checked or not
                }
            
                //If checked then see if there is an exisitng AssignedRotaRoleNunber for that user (done in control as above i believe)
                  //If so check if there is an existing RotaInstanceRoleNumber for that AssignedRotaRoleNunber and InstanceID
                    //If so do nothing as it started as checked and has ended as checked
                  //If there isn't, add them to a list of people needing to be added
                    //started unchecked but have has this assigned rota role before
               //If checked but not AssignedRotaRoleNumber for that user, make one and then add them to the list of people needing to be added
                    //Started unchecked and have never had this assigned rota role before
               //If not checked, see if they have an exsiting AssignedRotaRoleNunber for this role and rota
                  //If so then check if they were assigned to this instance by checking for  RotaInstanceRoleNumber for that AssignedRotaRoleNunber and InstanceID
                    //If There is a RotaInstanceRole Number, delete it (remove them from this instance)
                    //If not do nothing (They've had the role before but were never assigned to it for this specific instance)
                  //If not then do nothing (They've never had the role before on this rota and therefore are not assigned to it)

               //For everyone in the list to be be assigned RotaInstanceRoleNumber, use their AssignedRotaRoleNunber and the InstanceID
                 //They started unchecked but we want to add them.
            }
        }

        private void btnAddInstance_Click(object sender, EventArgs e)
        {
            AddNewInstance();
            (Application.OpenForms["frmManageRotaInstances"] as frmManageRotaInstances).RefreshFlp();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateInstance(EditModeInstanceID);
            (Application.OpenForms["frmManageRotaInstances"] as frmManageRotaInstances).RefreshFlp();
            this.Close();
        }
    }
}
