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
    public partial class cntrlRotaInstance : UserControl
    {

        public int RotaID { get; set; }
        public string InstanceDate { get; set; }
        public string InstanceTime { get; set; }
        public int InstanceID { get; set; }
        public List<clsRoles> Roleslst = new List<clsRoles>();
        public bool HostMode { get; set; }

        public cntrlRotaInstance(int rotaID, string instanceDate, string instanceTime, int instanceID, bool hostMode = true)
        {
            InitializeComponent();
            RotaID = rotaID;
            InstanceDate = instanceDate;
            InstanceTime = instanceTime;
            InstanceID = instanceID;
            HostMode = hostMode;
            if (HostMode)
            {
                btnEditAssignments.Enabled = true;
                btnEditAssignments.Visible = true;
            }
            else
            {
                btnEditAssignments.Enabled = false;
                btnEditAssignments.Visible = false;
            }
            InitaliseTextFields();
            FillFlp();
        }
        public void InitaliseTextFields()
        {
            lblDate.Text = InstanceDate;
            lblTime.Text = InstanceTime;
        }
        public void FillFlp()
        {
            // See onenote design for plan
            // Fill this with a label for the role (use the list for number and sql it) then labels for each assigned user
            // if no assigned user - fill with "no user assigned" label
            // Repeat for all roles for this rota

            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT tblRoles.RoleName, tblRotaRoles.RoleNumber, tblRotaRoles.RotaRoleNumber " +
                "FROM((tblRota INNER JOIN " +
                "tblRotaRoles ON tblRota.RotaID = tblRotaRoles.RotaID AND tblRota.RotaID = tblRotaRoles.RotaID) INNER JOIN " +
                "tblRoles ON tblRotaRoles.RoleNumber = tblRoles.RoleNumber) " +
                $"WHERE(tblRotaRoles.RotaID = {RotaID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                clsRoles Role = new clsRoles(dr[0].ToString(), Convert.ToInt32(dr[2].ToString()));
                Roleslst.Add(Role);
            }
            dbConnector.Close();

            foreach (clsRoles role in Roleslst)
            {
                Label lblRoleName = new Label();
                lblRoleName.Text = role.RoleName;
                lblRoleName.Font = new Font(lblRoleName.Font.Name, 9, FontStyle.Bold);
                lblRoleName.AutoSize = true;
                lblRoleName.MinimumSize = new System.Drawing.Size(0,20);
                flpAssignedRoles.Controls.Add(lblRoleName);

                //Using the role class to easily send name and role number around
                //BUT
                //I am using the "role number" property to send in ROTA role number in this case as its required below
                FindAndDisplayUsersForRole(role.RoleNumber, InstanceID);
            }

        }
        private void FindAndDisplayUsersForRole(int rotaRoleNumber, int instanceID) // can potentially do these 2 sql in one - see onenote page
        { //Given a role - get all assigned users for this role for this instance - if none then add a "No user assigned label"

            //given the instanceID, find all associated assignedRotaRoles for this instanceID (from RotaInstanceRoles)
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT tblRotaInstanceRoles.AssignedRotaRolesID " +
                "FROM((tblAssignedRotaRoles INNER JOIN " +
                "tblRotaInstanceRoles ON tblAssignedRotaRoles.AssignedRotaRolesID = tblRotaInstanceRoles.AssignedRotaRolesID) INNER JOIN " +
                "tblRotaRoles ON tblAssignedRotaRoles.RotaRoleNumber = tblRotaRoles.RotaRoleNumber) " +
                $"WHERE(tblRotaInstanceRoles.RotaInstanceID = {instanceID}) AND (tblRotaRoles.RotaRoleNumber = {rotaRoleNumber})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            List<int> assignedRotaRoleIDs = new List<int>();
            while (dr.Read())
            {
                assignedRotaRoleIDs.Add(Convert.ToInt32(dr[0].ToString()));
            }
            dbConnector.Close();

            //now with each rota role number (passed in) and eached assigned rotarolesID check for a userID in assignedrotaroles
           
            foreach (int assignedRotaRoleID in assignedRotaRoleIDs)
            {
                dbConnector = new clsDBConnector();
                sqlCommand = "SELECT DISTINCT tblPeople.FirstName, tblPeople.LastName, tblRotaInstanceRoles.Accepted " +
                    "FROM(((tblAssignedRotaRoles INNER JOIN " +
                    "tblPeople ON tblAssignedRotaRoles.UserID = tblPeople.UserID) INNER JOIN " +
                    "tblRotaInstanceRoles ON tblAssignedRotaRoles.AssignedRotaRolesID = tblRotaInstanceRoles.AssignedRotaRolesID) INNER JOIN " +
                    "tblRotaRoles ON tblAssignedRotaRoles.RotaRoleNumber = tblRotaRoles.RotaRoleNumber) " +
                    $"WHERE(tblAssignedRotaRoles.RotaRoleNumber = {rotaRoleNumber}) AND (tblAssignedRotaRoles.AssignedRotaRolesID = {assignedRotaRoleID})";
                dbConnector.Connect();
                dr = dbConnector.DoSQL(sqlCommand);

                while (dr.Read())
                {
                    Label lblUser = new Label();
                    lblUser.Text = dr[0].ToString() + " " + dr[1].ToString();
                    //padding so the names are 'tab shifted' right under the role headings
                    lblUser.Padding = new Padding(20, 0, 0, 0);
                    lblUser.AutoSize = true;
                    lblUser.Margin = new System.Windows.Forms.Padding(0,2,0,6);

                    //Code below is to colour (and strikethrough for declined) each name according to users A/D
                    if (Convert.ToInt32(dr[2].ToString()) == 1) //Accepted
                    {
                        lblUser.ForeColor = Color.Green;
                    }
                    else if (Convert.ToInt32(dr[2].ToString()) == -1) //Declined
                    {
                        lblUser.ForeColor = Color.Crimson;
                        lblUser.Font = new Font(lblUser.Font, FontStyle.Strikeout);
                    }
                    else if (Convert.ToInt32(dr[2].ToString()) == 0) //Not Acknowledged
                    {

                    }
                    lblUser.Show();
                    flpAssignedRoles.Controls.Add(lblUser);
                }
                dbConnector.Close();
            }
        }

        private void btnEditAssignments_Click(object sender, EventArgs e)
        {
            string instanceDateTime = lblDate.Text + " " + lblTime.Text;
            frmAddEditNewInstance frmAddNewInstance = new frmAddEditNewInstance(RotaID,"","",true,InstanceID,instanceDateTime);
            frmAddNewInstance.ShowDialog();
        }
    }
}
