using NEABenjaminFranklin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
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
            //create validate string functions for firstname and last name

            //create validate email function

            string validatedEmail = "TEST@TEST.COM";


            //create a temporary password
            string tempPassword = "TEST";
            //hash password using a function
            string hashedPassword = "TEST";


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

            }
            catch (Exception)
            {
                MessageBox.Show("Error adding user to database\nUser has not been created","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw;
            }
            //send email to new user containing login details (email signed up and temporay password)
            //try except that, if error, display messaage box containing temp password to communicate to user manually
            //if all goes well display a message box saying user created and login email sent
           

        }

    }
}
