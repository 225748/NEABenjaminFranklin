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
    public partial class frmPasswordReset : Form
    {
        private int UserID { get; set; }
        public frmPasswordReset(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }

        private void frmPasswordReset_Load(object sender, EventArgs e)
        {
            DisplayEmail();
        }

        private void DisplayEmail()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT Email " +
                "FROM tblPeople " +
                $"WHERE(UserID = {UserID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                lblUsersEmail.Text = dr[0].ToString();
            }
            dbConnector.Close();
        }

        private void ResetPassword()
        {
            clsPasswordHasher passwordHasher = new clsPasswordHasher();
            string hashedPassword = passwordHasher.HashPassword(txtNewPass.Text, UserID);

            //update their stored hash with this new one
            //change the need reset bool/flag in database to 0

            clsDBConnector dbConnector = new clsDBConnector();
            string sqlCommand = $"UPDATE tblPeople " +
                $"SET HashedPassword = '{hashedPassword}', NeedPasswordReset = false " +
                $"WHERE(tblPeople.UserID = {UserID})";
            dbConnector.Connect();
            dbConnector.DoSQL(sqlCommand);
            dbConnector.Close();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            //first check if the 2 pswds match
            if (txtNewPass.Text == txtConfirm.Text)
            {
                var promptResult = MessageBox.Show("Are you sure you wish to update your password?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (promptResult == DialogResult.OK)
                {
                    ResetPassword();
                    MessageBox.Show("Password Changed\nPlease login with your new password", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Changes not saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Passwords do not match\nPlease try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
