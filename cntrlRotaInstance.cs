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
        public List<clsRoles> Roleslst = new List<clsRoles>();

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
            string sqlCommand = "SELECT tblRoles.RoleName, tblRotaRoles.RoleNumber " +
                "FROM((tblRota INNER JOIN " +
                "tblRotaRoles ON tblRota.RotaID = tblRotaRoles.RotaID AND tblRota.RotaID = tblRotaRoles.RotaID) INNER JOIN " +
                "tblRoles ON tblRotaRoles.RoleNumber = tblRoles.RoleNumber) " +
                $"WHERE(tblRotaRoles.RotaID = {RotaID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                clsRoles Role = new clsRoles(dr[0].ToString(), Convert.ToInt32(dr[1].ToString()));
                Roleslst.Add(Role);
            }
            dbConnector.Close();

            foreach (clsRoles role in Roleslst)
            {
                Label lblRoleName = new Label();
                lblRoleName.Text = role.RoleName;
                flpAssignedRoles.Controls.Add(lblRoleName);
                FindAndDisplayUsersForRole(role.RoleNumber, InstanceID);
            }

        }
        private void FindAndDisplayUsersForRole(int rotaRoleNumber, int instanceID)
        { //Given a role - get all assigned users for this role for this instance - if none then add a "No user assigned label"

            //given the instanceID, find all associated assignedRotaRoles for this instanceID (from RotaInstanceRoles)
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT tblRotaInstanceRoles.AssignedRotaRolesID " +
                "FROM((tblAssignedRotaRoles INNER JOIN " +
                "tblRotaInstanceRoles ON tblAssignedRotaRoles.AssignedRotaRolesID = tblRotaInstanceRoles.AssignedRotaRolesID) INNER JOIN " +
                "tblRotaRoles ON tblAssignedRotaRoles.RotaRoleNumber = tblRotaRoles.RotaRoleNumber) " +
                $"WHERE(tblRotaInstanceRoles.RotaInstanceID = {instanceID})";
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
                sqlCommand = "SELECT tblAssignedRotaRoles.UserID, tblPeople.FirstName, tblPeople.LastName " +
                    "FROM(tblAssignedRotaRoles INNER JOIN " +
                    "tblPeople ON tblAssignedRotaRoles.UserID = tblPeople.UserID) " +
                    $"WHERE(tblAssignedRotaRoles.RotaRoleNumber = {rotaRoleNumber}) AND(tblAssignedRotaRoles.AssignedRotaRolesID = {assignedRotaRoleID}) " +
                    "AND(tblAssignedRotaRoles.UserID = tblPeople.UserID)";
                dbConnector.Connect();
                dr = dbConnector.DoSQL(sqlCommand);

                while (dr.Read())
                {
                    Label lblUser = new Label();
                    lblUser.Text = dr[1].ToString() + dr[2].ToString();
                    flpAssignedRoles.Controls.Add(lblUser);
                }
                dbConnector.Close();
            }
        }
    }
}
