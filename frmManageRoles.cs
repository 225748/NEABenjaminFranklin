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
            DisplayRoles();
            FillCombo();
        }
        private void DisplayRoles()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT RoleName FROM tblRoles";
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
        }
    }
}
