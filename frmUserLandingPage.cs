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
    public partial class frmUserLandingPage : Form
    {
        public int UserID { get; set; }

        public frmUserLandingPage(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }

        private void frmUserLandingPage_Load(object sender, EventArgs e)
        {
            InitaliseForm(); //treat this function as the form load - it is used as a reset called from other functions
        }

        private void InitaliseForm()
        {
            FillADDates();
            FillFlpRotas();
            lblFullName.Text = GetUserFullName(UserID);
        }

        private string GetUserFullName(int userID)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT FirstName, LastName " +
                "FROM tblPeople " +
                $"WHERE (UserID = {userID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                return dr[0].ToString() + " " + dr[1].ToString();
            }
            dbConnector.Close();
            return "";
        }

        private void FillADDates()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT tblRotaInstance.RotaInstanceDateTime, tblRoles.RoleName, tblRota.RotaName, " +
                "tblRotaInstance.RotaID, tblRotaInstance.RotaInstanceID, tblRotaInstanceRoles.RotaInstanceRoleNumber, " +
                "tblAssignedRotaRoles.UserID " +
                "FROM(((((tblRotaInstance INNER JOIN tblRota ON tblRotaInstance.RotaID = tblRota.RotaID) INNER JOIN " +
                "tblRotaInstanceRoles ON tblRotaInstance.RotaInstanceID = tblRotaInstanceRoles.RotaInstanceID) INNER JOIN " +
                "tblRotaRoles ON tblRota.RotaID = tblRotaRoles.RotaID) INNER JOIN " +
                "tblRoles ON tblRotaRoles.RoleNumber = tblRoles.RoleNumber) INNER JOIN " +
                "tblAssignedRotaRoles ON tblRotaInstanceRoles.AssignedRotaRolesID = tblAssignedRotaRoles.AssignedRotaRolesID " +
                "AND tblRotaRoles.RotaRoleNumber = tblAssignedRotaRoles.RotaRoleNumber) " +
                $"WHERE(tblAssignedRotaRoles.UserID = {UserID}) " +
                "ORDER BY tblRotaInstance.RotaInstanceDateTime";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                //For simplicity of reading - assigning the sql outputs to vars to manipulate
                DateTime rotaInstanceDateTime = Convert.ToDateTime(dr[0].ToString());
                string roleName = dr[1].ToString();
                string rotaName = dr[2].ToString();
                int rotaID = Convert.ToInt32(dr[3].ToString());
                int instanceID = Convert.ToInt32(dr[4].ToString());
                int rirn = Convert.ToInt32(dr[5].ToString()); //rirn = rota instance role number

                // don't show dates that have already happened
                if (rotaInstanceDateTime > DateTime.Now)
                {
                    string date = rotaInstanceDateTime.Date.ToString().Substring(0,10);
                    string time = rotaInstanceDateTime.TimeOfDay.ToString().Substring(0,5);

                    /////////////
                    /////Currently building this bit
                    /////////////
                    cntrlAcceptDeclineDates cntrlAcceptDeclineDates 
                        = new cntrlAcceptDeclineDates(date,time,roleName,rotaName,rotaID,instanceID,rirn,UserID);
                    flpDates.Controls.Add(cntrlAcceptDeclineDates);
                }

            }
            dbConnector.Close();
            if (flpDates.Controls.Count == 0)
            {//No assignements for this user
                Label lblNoDates = new Label();
                lblNoDates.Text = "There are no future assigned dates to display.";
                lblNoDates.AutoSize = true;
                flpDates.Controls.Add(lblNoDates);
            }
        }
        private void FillFlpRotas()
        {
            //Add controls for the rotas this user currently has at least one instancerolenum but don't add multiple times if they have multiple
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT DISTINCT tblRota.RotaID, tblRota.RotaName, tblRota.RotaThemeColour, " +
                "tblRota.FacilityID, tblFacility.FacilityName " +
                "FROM(((((tblRotaInstance INNER JOIN tblRota ON tblRotaInstance.RotaID = tblRota.RotaID) INNER JOIN " +
                "tblRotaInstanceRoles ON tblRotaInstance.RotaInstanceID = tblRotaInstanceRoles.RotaInstanceID) INNER JOIN " +
                "tblAssignedRotaRoles ON tblRotaInstanceRoles.AssignedRotaRolesID = tblAssignedRotaRoles.AssignedRotaRolesID) INNER JOIN " +
                "tblRotaRoles ON tblRota.RotaID = tblRotaRoles.RotaID AND tblAssignedRotaRoles.RotaRoleNumber = tblRotaRoles.RotaRoleNumber) " +
                "INNER JOIN tblFacility ON tblRota.FacilityID = tblFacility.FacilityID) " +
                $"WHERE(tblRotaInstanceRoles.RotaInstanceRoleNumber <> 0) AND(tblAssignedRotaRoles.UserID = {UserID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                cntrlRotaOverview cntrlRotaOverview =
                    new cntrlRotaOverview(dr[1].ToString(), Convert.ToInt32(dr[0].ToString()),
                    dr[4].ToString(), Convert.ToInt32(dr[3].ToString()), dr[2].ToString(), false);
                flpRotas.Controls.Add(cntrlRotaOverview);
            }
            dbConnector.Close();
        }

    }
}
