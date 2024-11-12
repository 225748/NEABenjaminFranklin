using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void btnChangeThemeColour_Click(object sender, EventArgs e)
        {
            //see code in add new rota
        }

        private void frmRotaSettings_Load(object sender, EventArgs e)
        {
            InitaliseInputFields();
        }
        private void InitaliseInputFields()
        {
            //populate combo and list
            //set the colour to theme colour
            txtRotaName.Text = RotaName;
            cmbFacility.SelectedItem = FacilityName;

        }
    }
}
