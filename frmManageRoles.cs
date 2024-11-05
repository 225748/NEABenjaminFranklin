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
    public partial class frmManageRoles : Form
    {
        public frmManageRoles()
        {
            InitializeComponent();
        }

        private void frmManageRoles_Load(object sender, EventArgs e)
        {
            CenterToParent();
            ResetForm();
        }
        private void ResetForm()
        {
            DisplayRoles();
            FillCombo();
            txtRoleName.Clear();
            btnUpdateRole.Enabled = false;
            btnDeleteRole.Enabled = false;
        }
        private void DisplayRoles()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT RoleName FROM tblRoles ORDER BY RoleName";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            lstVRoles.Items.Clear();

            while (dr.Read())
            {
                lstVRoles.Items.Add(dr[0].ToString());
            }
            dbConnector.Close();
        }
        private void FillCombo()
        {
            clsDBConnector dBConnector = new clsDBConnector();
            dBConnector.Connect();
            string sqlCommand = "SELECT RoleNumber, RoleName FROM tblRoles";
            OleDbDataAdapter da = new OleDbDataAdapter(sqlCommand, dBConnector.GetConnectionString());
            DataSet ds = new DataSet();
            da.Fill(ds, "tblRoles");
            cmbRoles.DisplayMember = "RoleName";
            cmbRoles.ValueMember = "RoleNumber";
            cmbRoles.DataSource = ds.Tables["tblRoles"];
            cmbRoles.Text = "-- Select a role to modify --";
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtRoleName.Text = cmbRoles.SelectedText;
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = $"SELECT RoleName FROM tblRoles WHERE RoleNumber = {cmbRoles.SelectedValue}";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                txtRoleName.Text = dr[0].ToString();
            }
            btnUpdateRole.Enabled = true;
            btnDeleteRole.Enabled = true;
        }

        private void AddRole(string roleName)
        {
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string cmdStr = $"INSERT INTO tblRoles  (RoleName) " +
                    $"VALUES ('{roleName}')";
                dbConnector.Connect();
                dbConnector.DoDML(cmdStr);
                dbConnector.Close();
                MessageBox.Show("Role successfully created", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Error adding role to database\nRole has not been created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void UpdateRole(string roleNumber, string roleName)
        {
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string sqlCommand = $"UPDATE tblRoles" +
                    $" SET RoleName = '{roleName}'" +
                    $" WHERE RoleNumber = {roleNumber}";
                dbConnector.Connect();
                dbConnector.DoSQL(sqlCommand);
                MessageBox.Show("Role Updated", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Changes not updated", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteRole(string roleNumber)
        {
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string sqlCommand = $"DELETE FROM tblRoles WHERE RoleNumber = {cmbRoles.SelectedValue}";
                dbConnector.Connect();
                dbConnector.DoSQL(sqlCommand);
                MessageBox.Show("Role Deleted", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Role not deleted", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnAddNewRole_Click(object sender, EventArgs e)
        {
            var promptResult = MessageBox.Show("Are you sure you wish to add this role", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (promptResult == DialogResult.OK)
            {
                //validate the text field - for now skipping
                string validatedRoleName = txtRoleName.Text;
                AddRole(validatedRoleName);
            }
            else
            {
                MessageBox.Show("Role Not Created", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdateRole_Click(object sender, EventArgs e)
        {

            var promptResult = MessageBox.Show("Are you sure you wish to make these changes", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (promptResult == DialogResult.OK)
            {
                //validate the text field - for now skipping
                string validatedRoleName = txtRoleName.Text;
                UpdateRole(cmbRoles.SelectedValue.ToString(),validatedRoleName);
            }
            else
            {
                MessageBox.Show("Changes Not Saved", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            var promptResult = MessageBox.Show("This action is irreversible", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (promptResult == DialogResult.OK)
            {

                DeleteRole(cmbRoles.SelectedValue.ToString()); //no!!!
            }
            else
            {
                MessageBox.Show("Role not deleted", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
