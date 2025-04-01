using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEABenjaminFranklin
{
    public partial class cntrlRotaOverview : UserControl
    {
        public string RotaName { get; set; }
        public int RotaID { get; set; }
        public string FacilityName { get; set; }
        public int FacilityID { get; set; }
        public string ThemeColour { get; set; }
        public bool HostMode { get; set; }



        public cntrlRotaOverview(string rotaName, int rotaID, string facilityName, int facilityID, string themeColour, bool hostMode = true)
        {
            InitializeComponent();
            RotaName = rotaName;
            RotaID = rotaID;
            FacilityName = facilityName;
            FacilityID = facilityID;
            ThemeColour = themeColour;
            HostMode = hostMode;
        }

        private void cntrlRotaOverview_Load(object sender, EventArgs e)
        {
            int lengthLimit = 23;
            if (RotaName.Length > lengthLimit)
            { lblRotaName.Text = RotaName.Substring(0, lengthLimit - 3) + "..."; }
            else { lblRotaName.Text = RotaName; }
            lblFacility.Text = FacilityName;
            if (ThemeColour == "0") //default - no user colour set
            {
                btnThemeColour.BackColor = Color.Silver;
            }
            else
            {
                btnThemeColour.BackColor = Color.FromArgb(Convert.ToInt32(ThemeColour));
            }
            if (HostMode)
            {
                pnlHostButtons.Enabled = true;
                pnlHostButtons.Visible = true; 
                pnlUserButtons.Enabled = false;
                pnlUserButtons.Visible = false;
            }
            else
            {
                pnlHostButtons.Enabled = false;
                pnlHostButtons.Visible = false;
                pnlUserButtons.Enabled = true;
                pnlUserButtons.Visible = true;
            }
        }

        private void btnEditRotaSettings_Click(object sender, EventArgs e)
        {
            //create an instance of the edit rota form and give it required info via constructor - assign to globals within class
            frmRotaSettings frmRotaSettings = new frmRotaSettings(RotaName, RotaID, FacilityName, FacilityID, ThemeColour);
            frmRotaSettings.ShowDialog();
        }

        private void btnMangeRotaInstances_Click(object sender, EventArgs e)
        {
            //create an instance of the rota instances form and give it required info via constructor - assign to globals within class
            this.Cursor = Cursors.WaitCursor;
            frmViewManageRotaInstances frmManageRotaInstances = new frmViewManageRotaInstances(RotaName, RotaID, FacilityName, FacilityID, ThemeColour, HostMode);
            frmManageRotaInstances.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnViewRota_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmViewManageRotaInstances frmManageRotaInstances = new frmViewManageRotaInstances(RotaName, RotaID, FacilityName, FacilityID, ThemeColour, HostMode);
            frmManageRotaInstances.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
