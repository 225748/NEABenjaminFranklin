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
    public partial class frmUserEditUserInfo : Form
    {
        private int UserID { get; set; }

        public frmUserEditUserInfo(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }

        private void frmUserEditUserInfo_Load(object sender, EventArgs e)
        {
            PreFillInformation(UserID);
        }
        private void PreFillInformation(int userID)
        {//populates input fields with the user's information
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT FirstName, LastName, DOB, Email " +
                "FROM tblPeople " +
                $"WHERE(UserID = {userID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                txtFirstName.Text = dr[0].ToString();
                txtLastName.Text = dr[1].ToString();
                dtpDOB.Value = Convert.ToDateTime(dr[2].ToString());
                txtEmail.Text = dr[3].ToString();
            }
            dbConnector.Close();
        }

        private bool ValidateFields()
        {
            Validation validator = new Validation();

            string response = validator.emailValidation(txtEmail.Text);
            if (response == "nullString")
            {
                MessageBox.Show("Please enter email information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (response == "invalid")
            {
                MessageBox.Show("Please enter a valid email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string fNameResponse = validator.plainTextValidation(txtFirstName.Text);
            string lNameResponse = validator.plainTextValidation(txtLastName.Text);

            if (fNameResponse == "nullString" | lNameResponse == "nullString")
            {
                MessageBox.Show("Please fill out the Name fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (fNameResponse == "invalid" | lNameResponse == "invalid")
            {
                MessageBox.Show("Invalid name characters detected\nPlease only use upper and lowercase letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; //passed all tests if reached this point

        }
        private void UpdateUser()
        {
            bool validated = ValidateFields();
            if (validated)
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string sqlCommand = $"UPDATE tblPeople " +
                    $"SET FirstName = '{txtFirstName.Text}', LastName = '{txtLastName.Text}', DOB = '{dtpDOB.Value.Date}', Email = '{txtEmail.Text}' " +
                    $"WHERE(tblPeople.UserID = {UserID})";
                dbConnector.Connect();
                dbConnector.DoSQL(sqlCommand);
                dbConnector.Close();
                MessageBox.Show("Information Updated", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            UpdateUser();
            this.Close();
        }
    }
}
