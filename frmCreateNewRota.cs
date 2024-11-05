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
    public partial class frmCreateNewRota : Form
    {
        public frmCreateNewRota()
        {
            InitializeComponent();
        }

        private void frmCreateNewRota_Load(object sender, EventArgs e)
        {
            FillCombo();
            FillCheckedList();
        }
        private void FillCombo()
        {
            clsDBConnector dBConnector = new clsDBConnector();
            dBConnector.Connect();
            string sqlString = "SELECT FacilityName, FacilityID FROM tblFacility ORDER BY FacilityName ";
            OleDbDataAdapter da = new OleDbDataAdapter(sqlString, dBConnector.GetConnectionString());
            DataSet ds = new DataSet();
            da.Fill(ds, "tblFacility");
            cmbFacility.DisplayMember = "FacilityName";
            cmbFacility.ValueMember = "FacilityID";
            cmbFacility.DataSource = ds.Tables["tblFacility"];
            cmbFacility.Text = "-- Select a Venue --";
        }
        private void FillCheckedList()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT RoleName FROM tblRoles ORDER BY RoleName";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            chklstRoles.Items.Clear();

            while (dr.Read())
            {
                chklstRoles.Items.Add(dr[0].ToString());
            }
            if (!dr.Read())
            {
                chklstRoles.Text = "Please create a role to begin assigning";
            }
            dbConnector.Close();
        }
    }
}
