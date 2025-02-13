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
    public partial class frmInitial : Form
    {
        public frmInitial()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private bool CompareHash(string plainTextPassword, int userID)
        {

            clsPasswordHasher passwordHasher = new clsPasswordHasher();
            string hash = passwordHasher.HashPassword(plainTextPassword, userID);

            //sql to compare
            string databaseHash = "";
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT HashedPassword " +
                "FROM tblPeople " +
                $"WHERE (UserID = {userID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                databaseHash = dr[0].ToString();
            }
            dbConnector.Close();
            if (hash == databaseHash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int AuthoriseCredentials()
        {
            bool validCredentials = false;
            bool validEmail = true;
            int userID = 0;

            Validation validator = new Validation();
            string response = validator.emailValidation(txtEmail.Text);
            if (response == "nullString")
            {
                MessageBox.Show("Please enter email information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validEmail = false;
            }
            else if (response == "invalid")
            {
                MessageBox.Show("Please enter a valid email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validEmail = false;
            }


            if (validEmail)
            {
                //getUserID for the email
                clsDBConnector dbConnector = new clsDBConnector();
                OleDbDataReader dr;
                string sqlCommand = "SELECT UserID " +
                    "FROM tblPeople " +
                    $"WHERE (Email = '{txtEmail.Text}')";
                dbConnector.Connect();
                dr = dbConnector.DoSQL(sqlCommand);

                while (dr.Read())
                {
                    userID = Convert.ToInt32(dr[0].ToString());
                }
                dbConnector.Close();


                //hash password and then compare in compare hash
                validCredentials = CompareHash(txtPassword.Text, userID);

                if (!validCredentials)
                {
                    userID = 0; //even though we've found the userID above, the password was incorrect
                }
            }
            return userID; //return userID = if not valid then 0 is returned
        }
        private bool CheckForPasswordReset()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT NeedPasswordReset, UserID " +
                "FROM tblPeople " +
                $"WHERE(Email = '{txtEmail.Text}')";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            bool reset = false;
            int userID = 0;
            while (dr.Read())
            {
                reset = Convert.ToBoolean(dr[0].ToString());
                userID = Convert.ToInt32(dr[1].ToString());
            }
            dbConnector.Close();
            if (reset)
            {//check temp password matches
                bool correctTempPass = CompareHash(txtPassword.Text, userID);
                if (correctTempPass)
                {
                    frmPasswordReset frmPasswordReset = new frmPasswordReset(userID);
                    frmPasswordReset.ShowDialog();
                    txtPassword.Clear();
                    return true;//breaks out of login cycle to allow for password reset
                }
                else
                {
                    MessageBox.Show("There was an issue authorising this temporary password\nPlease check inputs and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;//breaks out of login cycle to allow for password reset
                }
            }
            else
            {
                return false;
            }
        }

        private void btnHostLogin_Click(object sender, EventArgs e)
        {
            bool reset = CheckForPasswordReset();
            if (reset)
            {
                return;//break out of this function so they can start again
            }
            int authorisedUserID = AuthoriseCredentials();

            //Now check for host credentials
            bool validHost = false;
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT HostRole " +
                "FROM tblPeople " +
                $"WHERE(UserID = {authorisedUserID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                validHost = Convert.ToBoolean(dr[0].ToString());
            }
            dbConnector.Close();

            //bool validHost = true; //for bypass testing
            if (validHost)
            {
                this.Hide();
                frmHostLandingPage hostLandingPage = new frmHostLandingPage(authorisedUserID);
                hostLandingPage.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("There was an issue authorising this user as a host." +
                    "\n\nThis user may not have host privileges." +
                    "\nIf you belive this user should have host privileges,\nplease check inputs and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            bool reset = CheckForPasswordReset();
            if (reset)
            {
                return;//break out of this function so they can start again
            }
            int authorisedUserID = AuthoriseCredentials();
            if (authorisedUserID != 0)
            {
                this.Hide();                            //THIS (Currently 17 for testing) SHOULD BE THE USER ID OF THE LOGGED IN USER
                frmUserLandingPage userLandingPage = new frmUserLandingPage(authorisedUserID);
                userLandingPage.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("There was an issue logging into your account\nPlease try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblResetPassword_Click(object sender, EventArgs e)
        {
            frmInitiatePasswordReset frmInitiatePasswordReset = new frmInitiatePasswordReset();
            frmInitiatePasswordReset.ShowDialog();
        }
    }
}
