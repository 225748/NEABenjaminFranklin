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
        //public List<int> RoleNumbers = new List<int>();

        public cntrlRotaInstance(int rotaID, string instanceDate, string instanceTime, int instanceID)
        {
            InitializeComponent();
            RotaID = rotaID;
            InstanceDate = instanceDate;
            InstanceTime = instanceTime;
            InstanceID = instanceID;
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
            string sqlCommand = "SELECT tblRoles.RoleName, tblRoles.RoleNumber " +
                "FROM((tblRota INNER JOIN " +
                "tblRotaRoles ON tblRota.RotaID = tblRotaRoles.RotaID AND tblRota.RotaID = tblRotaRoles.RotaID) INNER JOIN " +
                "tblRoles ON tblRotaRoles.RoleNumber = tblRoles.RoleNumber) " +
                $"WHERE(tblRotaRoles.RotaID = {RotaID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                Label lblRoleName = new Label();
                lblRoleName.Text = dr[0].ToString();
                flpAssignedRoles.Controls.Add(lblRoleName);
                //Now have a role - get all assigned users for this role for this instance - if none then add a "No user assigned label"
                FindAndDisplayUsersForRole(Convert.ToInt32(dr[1].ToString()),InstanceID);

            }
            dbConnector.Close();

        }
        private void FindAndDisplayUsersForRole(int roleNumber, int instanceID)
        { //Given a role - get all assigned users for this role for this instance - if none then add a "No user assigned label"

            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;

            /////////////////////
            ///Not sure on this sql yet
            ///THIS CODE CAUSES "UNSPECIFIED ERROR" IN THE sql connector class
            ///as the previous connection is still open
            ///
            /// Potentially just get the previous function to add all roles to a list and then find all users for those roles and then add to flp
            /////////////////////
           
            //string sqlCommand = "SELECT tblRotaInstanceRoles.RotaInstanceRoleNumber " +
            //    "FROM((((tblRotaInstanceRoles INNER JOIN " +
            //    "tblRotaInstance ON tblRotaInstanceRoles.RotaInstanceID = tblRotaInstance.RotaInstanceID) INNER JOIN " +
            //    "tblAssignedRotaRoles ON tblRotaInstanceRoles.AssignedRotaRolesID = tblAssignedRotaRoles.AssignedRotaRolesID) INNER JOIN " +
            //    "tblPeople ON tblAssignedRotaRoles.UserID = tblPeople.UserID) INNER JOIN " +
            //    "tblRotaRoles ON tblAssignedRotaRoles.RotaRoleNumber = tblRotaRoles.RotaRoleNumber) " +
            //    $"WHERE (tblRotaInstance.RotaInstanceID = {instanceID}) " +
            //    $"AND (tblRotaRoles.RotaRoleNumber = {roleNumber})";
            //dbConnector.Connect();
            //dr = dbConnector.DoSQL(sqlCommand);
            //while (dr.Read())
            //{
            //    Label lblUser = new Label();
            //    lblUser.Text = dr[0].ToString();
            //    flpAssignedRoles.Controls.Add(lblUser);
            //}
        }
    }
}
