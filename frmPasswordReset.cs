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
        public frmPasswordReset(int UserID)
        {
            InitializeComponent();
            UserID = UserID;
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

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CODE THIS!");
        }

        //get salt, then on reset password press, use the class for hashing to hash new password,
        //update db and display new pass (not the hash) to user
    }
}
