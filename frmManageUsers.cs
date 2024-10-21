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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            DisplayUsers();
        }

        private void DisplayUsers()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "Select FirstName, LastName, DOB, HostRole, Email FROM tblPeople";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            lstVUsers.Items.Clear();


            //bubble up host roles to the top
            while (dr.Read()) // change this so all the sub items are added using a nested loop
            {
                lstVUsers.Items.Add(dr[0].ToString());
                lstVUsers.Items[lstVUsers.Items.Count - 1].SubItems.Add(dr[1].ToString());
                lstVUsers.Items[lstVUsers.Items.Count - 1].SubItems.Add(dr[2].ToString());
                lstVUsers.Items[lstVUsers.Items.Count - 1].SubItems.Add(dr[3].ToString());
                lstVUsers.Items[lstVUsers.Items.Count - 1].SubItems.Add(dr[4].ToString());
            }
            dbConnector.Close();
        }

        private void initaliseInputFields()//possibly covert to also doing the combo box fill
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            dtpDOB.Controls.Clear();
            chkHostRole.Checked = false;
        }
        private string getUserID(string firstName, string lastName, DateTime dob, bool hostRole, string email)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "Select UserID FROM tblPeople" +
                $" WHERE FirstName = '{firstName}'" +
                $" AND LastName = '{lastName}'" +
                $" AND DOB = #" + dob.ToString("MM/dd/yyyy") + "#" +
                $" AND HostRole = {hostRole}" +
                $" AND Email = '{email}'";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            string sqlReturn = "";
            while (dr.Read())
            {
                sqlReturn = sqlReturn + dr[0].ToString();
            }
            if (sqlReturn == "")
            {
                return null;
            }
            return sqlReturn;

        }

        private void deleteUser(int userID)
        {
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                OleDbDataReader dr;
                string sqlCommand = $"DELETE FROM tblPeople WHERE UserID = {userID}";
                dbConnector.Connect();
                dbConnector.DoSQL(sqlCommand);
                MessageBox.Show("User Deleted", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("User not deleted", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateUser(int userID, string firstName, string lastName, DateTime dob, bool hostRole, string email)
        {
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                OleDbDataReader dr;
                string sqlCommand = $"UPDATE tblPeople" +
                    $"SET FirstName = '{firstName}'" +
                    $"AND LastName = '{lastName}'" +
                    $"AND DOB = '{dob.Date}'" +
                    $"AND HostRole = {hostRole}" +
                    $"AND Email = '{email}'" +
                    $"WHERE UserID = {userID}";
                dbConnector.Connect();
                dbConnector.DoSQL(sqlCommand);
                MessageBox.Show("User Updated", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Changes not updated", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            var promptResult = MessageBox.Show("This action is irreversible", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (promptResult == DialogResult.OK)
            {
                string userIDString = getUserID(txtFirstName.Text, txtLastName.Text, dtpDOB.Value.Date, chkHostRole.Checked, txtEmail.Text);
                if (userIDString == null)
                {
                    MessageBox.Show("Cannot locate user in database", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    int userIDInt = Convert.ToInt32(userIDString);
                    deleteUser(userIDInt);
                    DisplayUsers();
                    initaliseInputFields();
                }
            }
            else
            {
                MessageBox.Show("User not deleted", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            var promptResult = MessageBox.Show("Are you sure you wish to make these changes", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (promptResult == DialogResult.OK)
            {
                //do update
            }
            else
            {
                MessageBox.Show("Changes Not Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //clear and update list view box, clear all inputs to textboxes
        }
    }
}

