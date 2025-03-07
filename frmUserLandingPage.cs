using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            try//load stats
            {
                if (tbStats.Enabled == true)//won't try again if we disabled it due to an issue
                {
                    LoadAcknowledgementStats();
                    LoadMostCommonAssigner();
                    LoadRolesChart();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("There was an issue loading your statistics", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbStats.Enabled = false;
            }

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
            string userFullName = "";
            while (dr.Read())
            {
                userFullName = dr[0].ToString() + " " + dr[1].ToString();
            }
            dbConnector.Close();
            return userFullName;
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
                    string date = rotaInstanceDateTime.Date.ToString().Substring(0, 10);
                    string time = rotaInstanceDateTime.TimeOfDay.ToString().Substring(0, 5);

                    cntrlAcceptDeclineDates cntrlAcceptDeclineDates
                        = new cntrlAcceptDeclineDates(date, time, roleName, rotaName, rotaID, instanceID, rirn, UserID);
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

        public void LoadAcknowledgementStats()//public as accessed from the ad cntrls too
        {
            crtRoles.Series[0].Points.Clear();
            crtRoles.Series[1].Points.Clear();

            for (int i = -1; i < 2; i++)
            {
                clsDBConnector dbConnector = new clsDBConnector();
                OleDbDataReader dr;
                string sqlCommand = "SELECT COUNT(tblRotaInstanceRoles.RotaInstanceRoleNumber) AS Expr1, tblRotaInstance.RotaInstanceDateTime " +
                    "FROM((tblRotaInstanceRoles INNER JOIN " +
                    "tblAssignedRotaRoles ON tblRotaInstanceRoles.AssignedRotaRolesID = tblAssignedRotaRoles.AssignedRotaRolesID) INNER JOIN " +
                    "tblRotaInstance ON tblRotaInstanceRoles.RotaInstanceID = tblRotaInstance.RotaInstanceID) " +
                    $"WHERE(tblAssignedRotaRoles.UserID = {UserID}) AND(tblRotaInstanceRoles.Accepted = {i}) " +
                    "GROUP BY tblRotaInstance.RotaInstanceDateTime";
                dbConnector.Connect();
                dr = dbConnector.DoSQL(sqlCommand);
                //sql returns:
                //dr[0] num of roles that are either A/D/NYA - dependant on while - on a specific instance
                //dr[1] is the date of it

                int numOfADNYA = 0;
                while (dr.Read())
                {
                    if (Convert.ToDateTime(dr[1].ToString()) > DateTime.Now)
                    {
                        //for every day later than today, add its num of A/D/NYA to a total of all days - dependant on our i
                        numOfADNYA += Convert.ToInt32(dr[0]);
                    }
                }
                if (i == 1)
                {
                    lblAcceptedNum.Text = numOfADNYA.ToString();
                }
                else if (i == 0)
                {
                    lblNyaNum.Text = numOfADNYA.ToString();
                }
                else if (i == -1)
                {
                    lblDeclinedNum.Text = numOfADNYA.ToString();
                }
                dbConnector.Close();
            }
        }

        private void LoadMostCommonAssigner()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT COUNT(tblRotaInstanceRoles.AssignedByID) AS numAssignedTo, " +
                "tblPeople.FirstName + ' ' + tblPeople.LastName AS name " +
                "FROM((tblRotaInstanceRoles INNER JOIN " +
                "tblAssignedRotaRoles ON tblRotaInstanceRoles.AssignedRotaRolesID = tblAssignedRotaRoles.AssignedRotaRolesID) INNER JOIN " +
                "tblPeople ON tblRotaInstanceRoles.AssignedByID = tblPeople.UserID AND tblRotaInstanceRoles.AssignedByID = tblPeople.UserID) " +
                $"WHERE(tblAssignedRotaRoles.UserID = {UserID}) " +
                "GROUP BY tblRotaInstanceRoles.AssignedByID, tblPeople.FirstName, tblPeople.LastName";
            //Counts each assignement of this user by an 'AssignedBy' UserID, and then 'Groups' that to output the count per AssignedByID
            //Output format of dr is
            //dr[0] is the number assigned by a host
            //dr[1] is the name of the host that assigned those
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            int highestAssignments = 0;
            string highestAssigner = "";
            while (dr.Read())
            {
                if (Convert.ToInt32(dr[0]) > highestAssignments)
                {
                    highestAssignments = Convert.ToInt32(dr[0]);
                    highestAssigner = dr[1].ToString();
                }
            }
            lblHighestAssigner.Text = highestAssigner.ToString();
            dbConnector.Close();
        }

        private void LoadRolesChart()
        {
            //Get the data we need
            List<string> roles = new List<string>();
            List<int> assignments = new List<int>();
            List<double> averageAssignments = new List<double>();

            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT  RoleName FROM tblRoles";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                roles.Add(dr[0].ToString());
            }
            dbConnector.Close();

            foreach (string roleName in roles)
            {
                dbConnector = new clsDBConnector(); //count num of assignments for this role
                sqlCommand = "SELECT COUNT(tblAssignedRotaRoles.RotaRoleNumber) " +
                    "FROM (((tblAssignedRotaRoles INNER JOIN " +
                    "tblRotaInstanceRoles ON tblAssignedRotaRoles.AssignedRotaRolesID = tblRotaInstanceRoles.AssignedRotaRolesID) " +
                    "INNER JOIN " +
                    "tblRotaRoles ON tblAssignedRotaRoles.RotaRoleNumber = tblRotaRoles.RotaRoleNumber) " +
                    "INNER JOIN tblRoles ON tblRotaRoles.RoleNumber = tblRoles.RoleNumber) " +
                    $"WHERE (tblAssignedRotaRoles.UserID = {UserID}) AND (tblRoles.RoleName = '{roleName}')";
                dbConnector.Connect();
                dr = dbConnector.DoSQL(sqlCommand);
                while (dr.Read())
                {
                    assignments.Add(Convert.ToInt32(dr[0]));
                }
                dbConnector.Close();
            }
            ///Now get average stats
            int userCount = 0;
            dbConnector = new clsDBConnector();
            sqlCommand = "SELECT COUNT(UserID) FROM tblPeople";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                userCount = Convert.ToInt32(dr[0]);
            }
            dbConnector.Close();

            foreach (var roleName in roles)
            {
                dbConnector = new clsDBConnector(); //count num of assignments for this role
                sqlCommand = "SELECT COUNT(tblRotaInstanceRoles.RotaInstanceRoleNumber) AS numOfAssignments " +
                    "FROM(((tblAssignedRotaRoles INNER JOIN " +
                    "tblRotaInstanceRoles ON tblAssignedRotaRoles.AssignedRotaRolesID = tblRotaInstanceRoles.AssignedRotaRolesID) " +
                    "INNER JOIN tblRotaRoles ON tblAssignedRotaRoles.RotaRoleNumber = tblRotaRoles.RotaRoleNumber) " +
                    "INNER JOIN tblRoles ON tblRotaRoles.RoleNumber = tblRoles.RoleNumber) " +
                    $"WHERE(tblRoles.RoleName = '{roleName}')";
                dbConnector.Connect();
                dr = dbConnector.DoSQL(sqlCommand);
                while (dr.Read())
                {
                    double average = Convert.ToDouble(dr[0]) / userCount;
                    averageAssignments.Add(average);
                }
                dbConnector.Close();
            }



            for (int i = 0; i < roles.Count; i++)
            {//unless you delete series 2 (avg) in the graph, if you don't add data for the 2nd series, it will duplicate first
                DataPoint dataPoint = new DataPoint(0, assignments[i]);
                dataPoint.AxisLabel = roles[i];
                crtRoles.Series[0].Points.Add(dataPoint);
                dataPoint = new DataPoint(0, averageAssignments[i]);
                dataPoint.AxisLabel = roles[i] + "Ave";
                crtRoles.Series[1].Points.Add(dataPoint);
            }
        }

        private void btnAccountSettings_Click(object sender, EventArgs e)
        {
            frmUserEditUserInfo frmUserEditUserInfo = new frmUserEditUserInfo(UserID);
            frmUserEditUserInfo.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Restart();
            Environment.Exit(0);
            //as forms were not closing when opening new ones, log out wouldn't reset the form indexes
            //problem with that is to access hostID for new assignment email, it uses forms index
            //frmInitial frmInitial = new frmInitial();
            //frmInitial.ShowDialog();
            //this.Close();
        }

        private void tbUserLanding_SelectedIndexChanged(object sender, EventArgs e)
        {
            //moved load of chart to form load for better usability
        }

        private void pcRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbStats.Enabled == true)//won't try again if we disabled it due to an issue
                {
                    LoadAcknowledgementStats();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an issue loading your statistics", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnavailability_Click(object sender, EventArgs e)
        {
            frmUserUnavailability frmUserUnavailability = new frmUserUnavailability(UserID);
            frmUserUnavailability.ShowDialog();
        }
    }
}
