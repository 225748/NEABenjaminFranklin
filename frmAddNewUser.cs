using NEABenjaminFranklin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //create validate email function
            Validation validator = new Validation();
            string response = validator.emailValidation(txtEmail.Text);
            string validatedEmail = "";
            if (response == "email")
            {
                validatedEmail = txtEmail.Text;
            }
            else
            {
                MessageBox.Show("Please enter a valid email","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string hashedPassword = passwordHasher.PerformHash(tempPassword,salt);

            /////////////////////////////
            //Need too code
            //Eventually email this temporary password (using a seperate function) to the new user
            //CREATE AN EMAIL CLASS TO CREATE OBJECTS OFF WHEN SENDING EMAIL
            ////////////////////////////

            //if email not sucessfully sent
            MessageBox.Show("There was an issue emailing the temporary password to the new user" +
                "\n\nThis information will not be viewable once this window is closed" +
                "\n\nPlease communicate the following manually:" +
                $"\n\n Email: {validatedEmail}" +
                $"\n One-Time Temporary Password: {tempPassword}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Clipboard.SetText(tempPassword);

            bool successfulUserCreation = false;
            //insert data into people table
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string cmdStr = $"INSERT INTO tblPeople  (FirstName, LastName, DOB, HostRole, Email, HashedPassword, Salt) " +
                    $"VALUES ('{txtFirstName.Text}', '{txtLastName.Text}','{dtpDOB.Value.Date}',{chkHostRole.Checked}," +
                    $"'{validatedEmail}','{hashedPassword}','{salt}')";
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
                //error message
            }
            else
            {
                MessageBox.Show("User successfully created", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //send email to new user containing login details (email signed up and temporay password)
                //try except that, if error, display messaage box containing temp password to communicate to user manually
                //if all goes well display a message box saying user created and login email sent
                this.Close();
            }

        }

    }
}
