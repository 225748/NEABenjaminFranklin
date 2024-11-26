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
    public partial class frmManageFacilities : Form
    {
        public frmManageFacilities()
        {
            InitializeComponent();
        }

        private void frmManageFacilities_Load(object sender, EventArgs e)
        {
            CenterToParent();
            ResetForm();
        }
        private void ResetForm()
        {
            DisplayFacilities();
            FillCombo();
            txtFacilityName.Clear();
            btnUpdateFacility.Enabled = false;
            btnDeleteFacility.Enabled = false;
        }
        private void DisplayFacilities()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT FacilityName FROM tblFacility ORDER BY FacilityName";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            lstVFacility.Items.Clear();

            while (dr.Read())
            {
                lstVFacility.Items.Add(dr[0].ToString());
            }
            dbConnector.Close();
        }
        private void FillCombo()
        {
            clsDBConnector dBConnector = new clsDBConnector();
            dBConnector.Connect();
            string sqlCommand = "SELECT FacilityID, FacilityName FROM tblFacility";
            OleDbDataAdapter da = new OleDbDataAdapter(sqlCommand, dBConnector.GetConnectionString());
            DataSet ds = new DataSet();
            da.Fill(ds, "tblFacility");
            cmbFacility.DisplayMember = "FacilityName";
            cmbFacility.ValueMember = "FacilityID";
            cmbFacility.DataSource = ds.Tables["tblFacility"];
            cmbFacility.Text = "-- Select a Facility to modify --";
        }

        private void cmbFacility_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = $"SELECT FacilityName FROM tblFacility WHERE FacilityID = {cmbFacility.SelectedValue}";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                txtFacilityName.Text = dr[0].ToString();
            }
            btnUpdateFacility.Enabled = true;
            btnDeleteFacility.Enabled = true;
        }
        private void AddFacility(string facilityName)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            string cmdStr = $"INSERT INTO tblFacility (FacilityName) " +
                $"VALUES ('{facilityName}')";
            dbConnector.Connect();
            dbConnector.DoDML(cmdStr);
            dbConnector.Close();
            ResetForm();
        }
        private void UpdateFacility(string facilityID, string facilityName)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            string sqlCommand = $"UPDATE tblFacility" +
                $" SET FacilityName = '{facilityName}'" +
                $" WHERE FacilityID = {facilityID}";
            dbConnector.Connect();
            dbConnector.DoSQL(sqlCommand);
            MessageBox.Show("Facility Updated", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();
        }
        private void DeleteFacility(string facilityID)
        {
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string sqlCommand = $"DELETE FROM tblFacility WHERE FacilityID = {cmbFacility.SelectedValue}";
                dbConnector.Connect();
                dbConnector.DoSQL(sqlCommand);
                MessageBox.Show("Facility Deleted", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Facility not deleted", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewFacility_Click(object sender, EventArgs e)
        {
            var promptResult = MessageBox.Show("Are you sure you wish to add this Facility", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (promptResult == DialogResult.OK)
            {
                //validate the text field - for now skipping
                string validatedFacilityName = txtFacilityName.Text;
                AddFacility(validatedFacilityName);
            }
            else
            {
                MessageBox.Show("Facility Not Created", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdateFacility_Click(object sender, EventArgs e)
        {
            var promptResult = MessageBox.Show("Are you sure you wish to make these changes", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (promptResult == DialogResult.OK)
            {
                //validate the text field - for now skipping
                string validatedFacilityName = txtFacilityName.Text;
                UpdateFacility(cmbFacility.SelectedValue.ToString(), validatedFacilityName);
            }
            else
            {
                MessageBox.Show("Changes Not Saved", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteFacility_Click(object sender, EventArgs e)
        {
            var promptResult = MessageBox.Show("This action is irreversible", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (promptResult == DialogResult.OK)
            {
                DeleteFacility(cmbFacility.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Facility not deleted", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
