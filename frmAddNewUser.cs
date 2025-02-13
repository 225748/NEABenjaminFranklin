using NEABenjaminFranklin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEABenjaminFranklin
{
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
        }
        private int FindLargestID(string tableName, string keyName)//largest ID is allways the one you have just created
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlStr;
            dbConnector.Connect();
            sqlStr = $" SELECT MAX({keyName}) AS maxID FROM {tableName} ";
            dr = dbConnector.DoSQL(sqlStr);
            int ret = 0;
            while (dr.Read())
            {
                ret = Convert.ToInt32(dr[0]);
            }
            dbConnector.Close();
            return ret;
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
            string templateFilePath = (AppDomain.CurrentDomain.BaseDirectory + "/Html_Email_Templates/newUserEmailTemplate.html");//directs to its own debug folder and then the file

            //Make an array of variables to replace in the html template
            clshtmlVariable[] variableReplacements = new clshtmlVariable[4];//num of unique variables in html template

            //for every unique variable in the template do this
            variableReplacements[0] = new clshtmlVariable("{firstName}", firstName);
            variableReplacements[1] = new clshtmlVariable("{lastName}", lastName);
            variableReplacements[2] = new clshtmlVariable("{email}", email);
            variableReplacements[3] = new clshtmlVariable("{temporaryPassword}", tempPassword);


            bool successfull = false;

            string htmlBody = emailManager.ReadAndPopulateEmailTemplate(templateFilePath, variableReplacements);
            try
            {
                emailManager.SendEmail(email, htmlBody, "Your new RotaConnect Account!");
                successfull = true;
            }
            catch (Exception)
            {
                successfull = false; //will need to manually communicate the temp password
            }
            return successfull;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
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


            //create a temporary password
            Random random = new Random();
            string tempPassword = "";
            tempPassword = tempPassword + txtFirstName.Text.Length;
            if (txtLastName.Text.Length > 3)
            {
                tempPassword += txtLastName.Text.ToUpper().Substring(0, 3);
            }
            else
            {
                tempPassword += txtLastName.Text.ToUpper();
            }
            tempPassword += txtFirstName.Text.ToUpper()[0];
            tempPassword += random.Next(10, 99);

            //hash password using a function
            clsPasswordHasher passwordHasher = new clsPasswordHasher();
            string salt = passwordHasher.GenerateSalt();
            string hashedPassword = passwordHasher.PerformHash(tempPassword, salt);


            //insert new user into people table
            bool successfulUserCreation = false;
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string cmdStr = $"INSERT INTO tblPeople  (FirstName, LastName, DOB, HostRole, Email, HashedPassword, Salt, NeedPasswordReset) " +
                    $"VALUES ('{txtFirstName.Text}', '{txtLastName.Text}','{dtpDOB.Value.Date}',{chkHostRole.Checked}," +
                    $"'{validatedEmail}','{hashedPassword}','{salt}', true)";
                dbConnector.Connect();
                dbConnector.DoDML(cmdStr);
                dbConnector.Close();
                successfulUserCreation = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error adding user to database\nUser has not been created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            if (!successfulUserCreation)
            {
                MessageBox.Show("Error adding user to database\nUser has not been created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            MessageBox.Show("User successfully created", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);




            //get the new userID
            int userID = FindLargestID("tblPeople", "UserID");

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
                MessageBox.Show("Welcome email with temporary password successfully sent", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();

        }

    }
}
