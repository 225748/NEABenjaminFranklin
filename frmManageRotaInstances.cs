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
    public partial class frmManageRotaInstances : Form
    {
        public string RotaName { get; set; }
        public int RotaID { get; set; }
        public string FacilityName { get; set; }
        public int FacilityID { get; set; }
        public string ThemeColour { get; set; }

        public frmManageRotaInstances(string rotaName, int rotaID, string facilityName, int facilityID, string themeColour)
        {
            InitializeComponent();
            RotaName = rotaName;
            RotaID = rotaID;
            FacilityName = facilityName;
            FacilityID = facilityID;
            ThemeColour = themeColour;
        }

        private void frmManageRotaInstance_Load(object sender, EventArgs e)
        {
            InitaliseTextFields();
            FillFlpInstances();
        }

        private void InitaliseTextFields()
        {
            int lengthLimit = 20;
            if (FacilityName.Length > lengthLimit)
            { lblFacility.Text = FacilityName.Substring(0, lengthLimit - 3) + "..."; }
            else { lblFacility.Text = FacilityName; }
            lblRotaName.Text = RotaName;
            if (ThemeColour == "0") //default - no user colour set
            {
                btnThemeColour.BackColor = Color.Silver;
            }
            else
            {
                btnThemeColour.BackColor = Color.FromArgb(Convert.ToInt32(ThemeColour));
            }
        }

        private void FillFlpInstances()
        {

            //code below is tesiting for now
            //Do SQL TO get InstanceID, date and time and role numbers for rota
            string instanceDate = "10/12/2024";
            string instanceTime = "9:00";
            int instanceID = 0;
            //List<int> roleNumbers = new List<int>(new int[] { 2, 3, 5, 6, 7, 8 }); //pull from database, this is just for testing

            cntrlRotaInstance cntrlRotaInstance = new cntrlRotaInstance(RotaID, instanceDate, instanceTime, instanceID);
            flpInstances.Controls.Add(cntrlRotaInstance);
        }

        private void btnAddInstance_Click(object sender, EventArgs e)
        {
            frmAddNewInstance frmAddNewInstance = new frmAddNewInstance(RotaID);
            frmAddNewInstance.ShowDialog();
        }
    }
}
