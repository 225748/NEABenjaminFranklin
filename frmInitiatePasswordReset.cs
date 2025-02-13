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
using System.Windows.Media.TextFormatting;

namespace NEABenjaminFranklin
{
    public partial class frmInitiatePasswordReset : Form
    {
        public frmInitiatePasswordReset()
        {
            InitializeComponent();
        }

        private int CheckForUser(string email)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "Select UserID " +
                "FROM tblPeople " +
                $"WHERE Email = '{email}'";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            int userID = 0;
            while (dr.Read())
            {
                userID = Convert.ToInt32(dr[0].ToString());
            }
            dbConnector.Close();
            return userID;
        }

        private void PerformPasswordReset(int userID)
        {
            //Create random temp password
            Random random = new Random();
            string tempPassword = "T";
            tempPassword = tempPassword + random.Next(10, 1000);
            if (txtEmail.Text.Length > 20)
            {
                tempPassword += txtEmail.Text.ToUpper().Substring(10, 3);
            }
            else
            {
                tempPassword += txtEmail.Text.ToUpper().Substring(0,3);
            }
            tempPassword += txtEmail.Text.ToUpper()[random.Next(0, txtEmail.Text.Length)];
            tempPassword += txtEmail.Text.ToUpper()[random.Next(0, txtEmail.Text.Length)];
            tempPassword += random.Next(10, 100);

            //hash password using a function
            clsPasswordHasher passwordHasher = new clsPasswordHasher();
            string hashedPassword = passwordHasher.HashPassword(tempPassword, userID);


            /////////////////////////////
            //Need too code
            //Eventually email this temporary password (using a seperate function) to the new user
            //CREATE AN EMAIL CLASS TO CREATE OBJECTS OFF WHEN SENDING EMAIL
            ////////////////////////////

            //if email not sucessfully sent
            MessageBox.Show("There was an issue emailing the temporary password to the new user" +
                "\n\nThis information will not be viewable once this window is closed" +
                "\n\nPlease communicate the following manually:" +
                $"\n\n Email: {txtEmail.Text}" +
                $"\n One-Time Temporary Password: {tempPassword}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Clipboard.SetText(tempPassword);


            //Update database
            clsDBConnector dbConnector = new clsDBConnector();
            string sqlCommand = $"UPDATE tblPeople " +
                $"SET HashedPassword = '{hashedPassword}', " +
                $"NeedPasswordReset = true " +
                $"WHERE (tblPeople.UserID = {userID})";
            dbConnector.Connect();
            dbConnector.DoSQL(sqlCommand);
            dbConnector.Close();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            //validate email entry
            Validation validator = new Validation();
            string response = validator.emailValidation(txtEmail.Text);
            if (response == "nullString")
            {
                MessageBox.Show("Please enter email information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (response == "invalid")
            {
                MessageBox.Show("Please enter a valid email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if it gets here, its a valid email format

            //check if email exists for a user first, then send reset
            int userID = CheckForUser(txtEmail.Text);

            if (userID != 0)
            {
                PerformPasswordReset(userID);
                this.Close();
            }
            else
            {
                MessageBox.Show("Account could not be found\nPlease check the email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
