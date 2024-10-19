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

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This action is irreversible", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (DialogResult != DialogResult.OK)
            {
                MessageBox.Show("User not deleted","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                //do delete
            }
            //clear and update list view box, clear all inputs to textboxes
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you wish to make these changes", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult != DialogResult.OK)
            {
                MessageBox.Show("Changes Not Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //do update
            }
            //clear and update list view box, clear all inputs to textboxes
        }
    }
}

