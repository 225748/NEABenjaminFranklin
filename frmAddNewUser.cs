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
            //put all validators in a seperate class and access the functions like db connector
            //create validate string functions for firstname and last name

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
            if (txtLastName.Text.Length > 3)
            {
                tempPassword += txtLastName.Text.ToUpper().Substring(0, 3);
            }
            else
            {
                tempPassword += txtLastName.Text.ToUpper();
            }
            tempPassword += txtFirstName.Text.ToUpper();
            tempPassword += random.Next(10, 99);

            //hash password using a function
            string hashedPassword = "TEST";

            bool successfulUserCreation = false;
            //insert data into people table
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string cmdStr = $"INSERT INTO tblPeople  (FirstName, LastName, DOB, HostRole, Email, HashedPassword) " +
                    $"VALUES ('{txtFirstName.Text}', '{txtLastName.Text}','{dtpDOB.Value.Date}',{chkHostRole.Checked}," +
                    $"'{validatedEmail}','{hashedPassword}')";
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
