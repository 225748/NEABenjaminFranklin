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

        private string hashPassword(string plainText)
        {
            ////////////////////////////////////
            ///NEED TO WRITE CUSTOM HASHING ALORGITHM - DONT USE BUILT IN IF CAN!!!
            ///////////////////////////////////////
            string hashed = "";
            return hashed;
        }

        private int AuthoriseCredentials()
        {
            bool validCredentials = false;
            bool validEmail = true;

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
                //Hash the password to compare to hash stored in database
                string hashedPassword = hashPassword(txtPassword.Text);

                clsDBConnector dbConnector = new clsDBConnector();
                OleDbDataReader dr;
                string sqlCommand = "SELECT UserID " +
                    "FROM tblPeople " +
                    $"WHERE(Email = {txtEmail.Text}) AND (HashedPassword = {hashedPassword})";
                dbConnector.Connect();
                dr = dbConnector.DoSQL(sqlCommand);
                while (dr.Read())
                {
                    validCredentials = true;
                    return Convert.ToInt32(dr[0].ToString()); //userID found and returned for login
                }
            }
            return 0; //no userID found for this combination of email and hashed password
        }

        //have a default password for new users and then prompt for change on first login
        private void btnHostLogin_Click(object sender, EventArgs e)
        {
            //int authorisedUserID = AuthoriseCredentials();

            ////Now check for host credentials
            //bool validHost = false;
            //clsDBConnector dbConnector = new clsDBConnector();
            //OleDbDataReader dr;
            //string sqlCommand = "SELECT HostRole " +
            //    "FROM tblPeople " +
            //    $"WHERE(UserID = {authorisedUserID})";
            //dbConnector.Connect();
            //dr = dbConnector.DoSQL(sqlCommand);
            //while (dr.Read())
            //{
            //    validHost = Convert.ToBoolean(dr[0].ToString());
            //}

            bool validHost = true; //for bypass testing
            if (validHost)
            {
                this.Hide();
                frmHostLandingPage hostLandingPage = new frmHostLandingPage();
                hostLandingPage.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("There was an issue authorising this user as a host\nPlease try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            int authorisedUserID = AuthoriseCredentials();
            if (authorisedUserID != 0)
            {
                this.Hide();                            //THIS (Currently 17 for testing) SHOULD BE THE USER ID OF THE LOGGED IN USER
                frmUserLandingPage userLandingPage = new frmUserLandingPage(17);
                userLandingPage.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("There was an issue logging into your account\nPlease try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
