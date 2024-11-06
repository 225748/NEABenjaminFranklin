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
    public partial class cntrlRotaOverview : UserControl
    {
        public string RotaName { get; set; }
        public int RotaID { get; set; }
        public string FacilityName { get; set; }
        public int FacilityID {  get; set; }
        public string ThemeColour { get; set; }



        public cntrlRotaOverview()
        {
            InitializeComponent();
        }

        private void cntrlRotaOverview_Load(object sender, EventArgs e)
        {
            if (RotaName.Length > 15) //15 chars fit nicely into control
            {lblRotaName.Text = RotaName.Substring(0, 9) + "...";}
            else { lblRotaName.Text = RotaName; }
            lblFacility.Text = FacilityName;
            btnThemeColour.BackColor = Color.FromArgb(Convert.ToInt32(ThemeColour));
            btnThemeColour.ForeColor = Color.FromArgb(Convert.ToInt32(ThemeColour));
        }

        private void btnEditRotaSettings_Click(object sender, EventArgs e)
        {
            //create an instance of the edit rota form and give it this info - use publics? - may need to put rota ID into this as a public
        }

        private void btnMangeRotaInstances_Click(object sender, EventArgs e)
        {
            //create an instance of the rota instances form and give it this info - use publics? - may need to put rota ID into this as a public

        }
    }
}
