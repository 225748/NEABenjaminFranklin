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
using System.Windows.Media.Media3D;

namespace NEABenjaminFranklin
{
    public partial class cntrlAcceptDeclineDates : UserControl
    {
        private string Date { get; set; }
        private string Time { get; set; }
        private string RoleName { get; set; }
        private string RotaName { get; set; }

        private int RotaID { get; set; }
        private int InstanceID { get; set; }
        private int RotaInstanceRoleNumber { get; set; }
        private int UserID  { get; set; }


        public int Accepted { get; set; }
        //Used to be a bool but updated to int to get tri-state
        //(1 = accepted, 0 = not acknowledged, -1 = declined )

        public cntrlAcceptDeclineDates(string date, string time, string roleName, string rotaName, int rotaID, int instanceID, int rotaInstanceRoleNumber, int userID)
        {
            InitializeComponent();
            Date = date;
            Time = time;
            RoleName = roleName;
            RotaName = rotaName;
            RotaID = rotaID;
            InstanceID = instanceID;
            RotaInstanceRoleNumber = rotaInstanceRoleNumber;
            UserID = userID;
        }

        private void cntrlAcceptDeclineDates_Load(object sender, EventArgs e)
        {
            lblDate.Text = Date;
            lblTime.Text = Time;
            lblRole.Text = RoleName;
            lblRotaName.Text = RotaName;
            btnAcceptDate.Enabled = true;
            btnDeclineDate.Enabled = true;
            Accepted = QueryADstate();
            UpdateADstate();

            tmrEmailSendDelay.Interval = 10000;//10 seconds grace period
            tmrEmailSendDelay.Enabled = false;
        }
        private int QueryADstate()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT Accepted FROM tblRotaInstanceRoles " +
                $"WHERE(RotaInstanceRoleNumber = {RotaInstanceRoleNumber})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            int ADstate = 0;
            while (dr.Read())
            {
                ADstate = Convert.ToInt32(dr[0].ToString());
            }
            dbConnector.Close();
            return ADstate;
        }

        private void UpdateADstate()
        {//used for both inital button states (I.e. if user previously A/D) and updates
            if (Accepted == 1)
            {
               // btnAcceptDate.BackColor = Color.FromArgb(50, 255, 190); //old colour
                btnAcceptDate.BackColor = Color.FromArgb(192, 255, 192);
                btnAcceptDate.Text = "Accepted";
                btnDeclineDate.BackColor = Color.Empty;
                btnDeclineDate.Text = "Decline";
            }
            else if (Accepted == -1)
            {
                //btnDeclineDate.BackColor = Color.FromArgb(255, 128, 128); //old colour
                btnDeclineDate.BackColor = Color.FromArgb(255, 150, 150);
                btnDeclineDate.Text = "Declined";
                btnAcceptDate.BackColor = Color.Empty;
                btnAcceptDate.Text = "Accept";
            }
            else //not acknowledged yet
            {
                btnAcceptDate.BackColor = Color.FromArgb(192, 255, 192);
                btnAcceptDate.Text = "Accept";
                btnDeclineDate.BackColor = Color.FromArgb(255, 150, 150);
                btnDeclineDate.Text = "Decline";
            }
        }

        private void UpdateADDatabaseState()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            string cmdStr = "UPDATE tblRotaInstanceRoles " +
                $"SET Accepted = {Accepted} " +
                $"WHERE(tblRotaInstanceRoles.RotaInstanceRoleNumber = {RotaInstanceRoleNumber})";
            dbConnector.Connect();
            dbConnector.DoDML(cmdStr);
            dbConnector.Close();
        }

        private void StartEmailDelay()
        {//allows user a 'grace period' to click A/D as much as they want before it sends the email
         //prevents hosts being spammed with emails from people clicking the wrong thing or changing minds quickly

            //First check if timer is not already set
            if (tmrEmailSendDelay.Enabled != true)
            {
                tmrEmailSendDelay.Enabled = true;
                tmrEmailSendDelay.Start();
            }
            else
            {
                //do nothing, A/D has very recently been changed so currently in delay anyways
            }
        }
        private void tmrEmailSendDelay_Tick(object sender, EventArgs e)//delay elapsed
        {
            tmrEmailSendDelay.Stop();
            tmrEmailSendDelay.Enabled = false;

            //Now send the email for A/D to host
            try
            {
                DoEmail();
            }
            catch (Exception)
            {//email not sent - not too worried as its not a critical email
            }
        }

        private void DoEmail()
        {
            //Get full and first name of host
            string hostFullName = "";
            string hostFirstName = "";
            string hostEmailAddress = "";
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT tblPeople.FirstName, tblPeople.LastName, tblPeople.Email " +
                "FROM(tblRotaInstanceRoles INNER JOIN tblPeople ON tblRotaInstanceRoles.AssignedByID = tblPeople.UserID) " +
                $"WHERE(tblRotaInstanceRoles.RotaInstanceRoleNumber = {RotaInstanceRoleNumber})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                hostFullName = dr[0].ToString() + " " + dr[1].ToString();
                hostFirstName = dr[0].ToString();
                hostEmailAddress = dr[2].ToString();
            }
            dbConnector.Close();

            //Get user email and firstName
            string firstName = "";
            dbConnector = new clsDBConnector();
            sqlCommand = "SELECT FirstName " +
                "FROM tblPeople " +
                $"WHERE(UserID = {UserID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                firstName = dr[0].ToString();
            }
            dbConnector.Close();

            string rotaName = RotaName;
            string date = Date;
            string time = Time;
            string role = RoleName;

            //Get ADState
            int ADint = QueryADstate();
            string ADState = "Not Yet Acknowledged";
            if (ADint == 1)
            {
                ADState = "Accepted";
            }
            else if (ADint == -1)
            {
                ADState = "Declined";
            }

            //Email
            clsEmailManager emailManager = new clsEmailManager();

            //Retrieve template
            string templateFilePath = (AppDomain.CurrentDomain.BaseDirectory + "/Html_Email_Templates/assignmentResponse.html");//directs to its own debug folder and then the file

            //Make an array of variables to replace in the html template
            clshtmlVariable[] variableReplacements = new clshtmlVariable[8];//num of unique variables in html template

            //for every unique variable in the template do this
            variableReplacements[0] = new clshtmlVariable("{hostFullName}", hostFullName);
            variableReplacements[1] = new clshtmlVariable("{hostFirstName}", hostFirstName);
            variableReplacements[2] = new clshtmlVariable("{rota}", rotaName);
            variableReplacements[3] = new clshtmlVariable("{date}", date);
            variableReplacements[4] = new clshtmlVariable("{time}", time);
            variableReplacements[5] = new clshtmlVariable("{role}", role);
            variableReplacements[6] = new clshtmlVariable("{usersName}", firstName);
            variableReplacements[7] = new clshtmlVariable("{ADState}", ADState);


            string htmlBody = emailManager.ReadAndPopulateEmailTemplate(templateFilePath, variableReplacements);
            try
            {
                emailManager.SendEmail(hostEmailAddress, htmlBody, $"A new {rotaName} assignment response!");
            }
            catch (Exception)
            {
                //didn't send
            }
        }

        private void btnAcceptDate_Click(object sender, EventArgs e)
        {
            Accepted = 1;
            UpdateADstate();
            UpdateADDatabaseState();
            (Application.OpenForms["frmUserLandingPage"] as frmUserLandingPage).LoadAcknowledgementStats();
            StartEmailDelay();
        }

        private void btnDeclineDate_Click(object sender, EventArgs e)
        {
            Accepted = -1;
            UpdateADstate();
            UpdateADDatabaseState();
            (Application.OpenForms["frmUserLandingPage"] as frmUserLandingPage).LoadAcknowledgementStats();
            StartEmailDelay();
        }

    }
}
