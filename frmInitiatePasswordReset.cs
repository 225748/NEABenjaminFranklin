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

        private bool Email(string email, string tempPassword, int userID)
        {
            //Get first and last name
            string firstName = ""; string lastName = "";
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT FirstName, LastName " +
                "FROM tblPeople " +
                $"WHERE UserID = {userID}";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                firstName = dr[0].ToString();
                lastName = dr[1].ToString();
            }
            dbConnector.Close();


            //Email
            clsEmailManager emailManager = new clsEmailManager();

            //Retrieve template
            string templateFilePath = (AppDomain.CurrentDomain.BaseDirectory + "/Html_Email_Templates/passwordResetEmailTemplate.html");//directs to its own debug folder and then the file

            //Make an array of variables to replace in the html template
            clshtmlVariable[] variableReplacements = new clshtmlVariable[3];//num of unique variables in html template

            //for every unique variable in the template do this
            variableReplacements[0] = new clshtmlVariable("{firstName}", firstName);
            variableReplacements[1] = new clshtmlVariable("{email}", email);
            variableReplacements[2] = new clshtmlVariable("{temporaryPassword}", tempPassword);


            bool successfull = false;

            string htmlBody = emailManager.ReadAndPopulateEmailTemplate(templateFilePath, variableReplacements);
            try
            {
                emailManager.SendEmail(email, htmlBody, "RotaConnect Password Reset");
                successfull = true;
            }
            catch (Exception)
            {
                successfull = false; //will need to manually communicate the temp password
            }
            return successfull;
        }

        private void PerformPasswordReset(int userID)
        {
            //validate email
            Validation validator = new Validation();
            string response = validator.emailValidation(txtEmail.Text);
            string validatedEmail = "";
            if (response == "email")
            {
                validatedEmail = txtEmail.Text;
            }
            else
            {
                MessageBox.Show("Please enter a valid email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; //breaks out the function
            }


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

            //Update database
            clsDBConnector dbConnector = new clsDBConnector();
            string sqlCommand = $"UPDATE tblPeople " +
                $"SET HashedPassword = '{hashedPassword}', " +
                $"NeedPasswordReset = true " +
                $"WHERE (tblPeople.UserID = {userID})";
            dbConnector.Connect();
            dbConnector.DoSQL(sqlCommand);
            dbConnector.Close();



            //Communicate temp password to new user via email
            bool successfull = Email(validatedEmail, tempPassword, userID);

            //if email not sucessfully sent
            if (!successfull)
            {
                MessageBox.Show("There was an issue emailing the temporary password to the new user" +
                    "\n\nThis information will not be viewable once this window is closed" +
                    "\n\nPlease communicate the following manually:" +
                    $"\n\n Email: {validatedEmail}" +
                    $"\n One-Time Temporary Password: {tempPassword}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clipboard.SetText(tempPassword);
            }
            if (successfull)
            {
                MessageBox.Show("Email with temporary password successfully sent", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
