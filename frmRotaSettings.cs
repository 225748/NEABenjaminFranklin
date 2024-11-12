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
    public partial class frmRotaSettings : Form
    {
        public string RotaName { get; set; }
        public int RotaID { get; set; }
        public string FacilityName { get; set; }
        public int FacilityID { get; set; }
        public string ThemeColour { get; set; }
        public frmRotaSettings(string rotaName, int rotaID, string facilityName, int facilityID, string themeColour)
        {
            InitializeComponent();
            RotaName = rotaName;
            RotaID = rotaID;
            FacilityName = facilityName;
            FacilityID = facilityID;
            ThemeColour = themeColour;
        }
        private void frmRotaSettings_Load(object sender, EventArgs e)
        {
            InitaliseInputFields();
        }
        private void InitaliseInputFields()
        {
            //populate combo and list
            txtRotaName.Text = RotaName;
            FillCombo();
            cmbFacility.SelectedIndex = cmbFacility.FindString(FacilityName);
            FillRolesList();
            PreSelectRoles();
            btnColourDisplay.BackColor = Color.FromArgb(Convert.ToInt32(ThemeColour));
            btnColourDisplay.Show();

        }
        private void FillCombo()//identical to one in create rota apart from no "select facility" line here
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
        }
        private void FillRolesList()//identical to one in create rota
        {
            lstVRoles.Items.Clear();
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "Select RoleName, RoleNumber FROM tblRoles ORDER BY RoleName";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                lstVRoles.Items.Add(dr[0].ToString());
                lstVRoles.Items[lstVRoles.Items.Count - 1].SubItems.Add(dr[1].ToString());
            }
            dbConnector.Close();
        }
        private void PreSelectRoles()
        {
               // work out if a given role has an associated rotarole for it (meaning its been checked for this rota)
               // if so then set its checked state to true
               //can possibly do this using an agregate query in the fill list function and get rid of this function
        }



        private void btnChangeThemeColour_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            //colorDialog.AllowFullOpen = false; restricts to system colours
            colorDialog.ShowDialog();
            btnChangeThemeColour.Text = "Change Rota Theme Colour";
            ThemeColour = colorDialog.Color.ToArgb().ToString();
            btnColourDisplay.BackColor = colorDialog.Color;
            btnColourDisplay.Show();
        }

    }
}
