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
        private string themeColour {  get; set; }

        private void frmCreateNewRota_Load(object sender, EventArgs e)
        {
            FillCombo();
            FillCheckedList();
            btnThemeColour.Text = "Set Rota Theme Colour";
            themeColour = "0";
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

        private void CreateRota()
        {
            //yet to code roles into this
            //need to validate all inputs for presence checks including roles

            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string cmdStr = $"INSERT INTO tblRota " +
                    $"(FacilityID, RotaName, RotaThemeColour) " +
                    $"VALUES ({cmbFacility.SelectedValue.ToString()}, '{txtRotaName.Text}','{themeColour}')";
                dbConnector.Connect();
                dbConnector.DoDML(cmdStr);
                dbConnector.Close();
                //NOW SQL THE ROLES TABLE TO CREATE - PULL THE ROTAID FIRST


            }
            catch (Exception)
            {
                MessageBox.Show("Error adding rota to database\n Rota has not been created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            this.Close();

        }
        private void btnThemeColour_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            //colorDialog.AllowFullOpen = false; restricts to system colours
            colorDialog.ShowDialog();
            btnThemeColour.Text = "Change Rota Theme Colour";
            themeColour = colorDialog.Color.ToArgb().ToString();
        }

        private void btnCreateRota_Click(object sender, EventArgs e)
        {
            CreateRota();
        }
    }
}
