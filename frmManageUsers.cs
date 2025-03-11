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
        public virtual System.Drawing.Font font { get; set; }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            DisplayUsers();
            FillCombo();
            FillInputFields(false);
        }

        private void DisplayUsers()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "Select FirstName, LastName, DOB, HostRole, Email FROM tblPeople ORDER BY HostRole, LastName, FirstName";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            lstVUsers.Items.Clear();

            while (dr.Read())
            {
                lstVUsers.Items.Add(dr[0].ToString());
                lstVUsers.Items[lstVUsers.Items.Count - 1].SubItems.Add(dr[1].ToString());
                lstVUsers.Items[lstVUsers.Items.Count - 1].SubItems.Add(dr[2].ToString().Substring(0,10));
                lstVUsers.Items[lstVUsers.Items.Count - 1].SubItems.Add(dr[3].ToString());
                lstVUsers.Items[lstVUsers.Items.Count - 1].SubItems.Add(dr[4].ToString());
            }
            dbConnector.Close();
        }
        private void FillCombo()
        {
            clsDBConnector dBConnector = new clsDBConnector();
            dBConnector.Connect();
            string sqlString = "SELECT userID, (FirstName & " + "' '" + " & LastName) as userName FROM tblPeople ORDER BY LastName ";
            OleDbDataAdapter da = new OleDbDataAdapter(sqlString, dBConnector.GetConnectionString());
            DataSet ds = new DataSet();
            da.Fill(ds, "tblPeople");
            cmbUsers.DisplayMember = "userName";
            cmbUsers.ValueMember = "UserID";
            cmbUsers.DataSource = ds.Tables["tblPeople"];
        }

        private void FillInputFields(bool useCombo) //also used to initalise fields at the start
        {
            if (useCombo) // uses userID of selected user from the combo box
            {
                clsDBConnector dbConnector = new clsDBConnector();
                OleDbDataReader dr;
                dbConnector.Connect();
                string sqlString = "SELECT FirstName, LastName, DOB, HostRole, Email" +
                    " FROM tblPeople" +
                    " WHERE UserID = " + cmbUsers.SelectedValue;
                dr = dbConnector.DoSQL(sqlString);

                while (dr.Read())
                {
                    txtFirstName.Text = dr[0].ToString();
                    txtLastName.Text = dr[1].ToString();
                    dtpDOB.Value = Convert.ToDateTime(dr[2]);
                    chkHostRole.Checked = Convert.ToBoolean(dr[3]);
                    txtEmail.Text = dr[4].ToString();
                    pnlUserInfoInputFields.Enabled = true;
                }
                dbConnector.Close();
            }
            else
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                dtpDOB.Controls.Clear();
                chkHostRole.Checked = false;
                cmbUsers.Text = "-- Select a user to modify --";
                //cmbUsers.Font = new Font(cmbUsers.Font, FontStyle.Bold);

                pnlUserInfoInputFields.Enabled = false;
            }
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
            else
            {
                return sqlReturn;
            }
        }

        private void DeleteUser(int userID)
        {
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
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

        private void UpdateUser(int userID, string firstName, string lastName, DateTime dob, bool hostRole, string email)
        {
            Validation validator = new Validation();
            string response = validator.emailValidation(email);
            string validatedEmail = "";
            if (response == "email")
            {
                validatedEmail = email;
            }
            else
            {
                MessageBox.Show("Please enter a valid email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; //breaks out the function
            }

            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string sqlCommand = $"UPDATE tblPeople" +
                    $" SET FirstName = '{firstName}'" +
                    $", LastName = '{lastName}'" +
                    $", DOB = #" + dob.ToString("MM/dd/yyyy") + "#" +
                    $", HostRole = {hostRole}" +
                    $", Email = '{email}'" +
                    $" WHERE UserID = {userID}";
                dbConnector.Connect();
                dbConnector.DoSQL(sqlCommand);
                MessageBox.Show("User Updated", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Changes not updated", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillInputFields(true);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            var promptResult = MessageBox.Show("This action is irreversible", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (promptResult == DialogResult.OK)
            {
                string userIDString = getUserID(txtFirstName.Text, txtLastName.Text, dtpDOB.Value.Date, chkHostRole.Checked, txtEmail.Text);
                if (userIDString == null)
                {
                    MessageBox.Show("Cannot locate user in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int userIDInt = Convert.ToInt32(userIDString);
                    DeleteUser(userIDInt);
                    DisplayUsers();
                    FillCombo();
                    FillInputFields(false);
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
                UpdateUser(Convert.ToInt32(cmbUsers.SelectedValue), txtFirstName.Text, txtLastName.Text, dtpDOB.Value.Date, chkHostRole.Checked, txtEmail.Text);
                DisplayUsers();
                FillInputFields(false);
                FillCombo();
            }
            else
            {
                MessageBox.Show("Changes Not Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}

