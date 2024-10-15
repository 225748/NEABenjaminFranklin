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
    public partial class cntrlAcceptDeclineDates : UserControl
    {
        public string Date { get; set; }
        public string Role { get; set; }
        public bool Accepted { get; set; }

        public cntrlAcceptDeclineDates()
        {
            InitializeComponent();
        }

        private void cntrlAcceptDeclineDates_Load(object sender, EventArgs e)
        {
            lblDate.Text = Date;
            lblRole.Text = Role;
            btnAcceptDate.Enabled = true;
            btnDeclineDate.Enabled = true;
        }

        private void updateADstate()
        {
            if (Accepted)
            {
                btnAcceptDate.BackColor = Color.FromArgb(50, 255, 190);
                btnAcceptDate.Text = "Accepted";
                btnDeclineDate.BackColor = Color.Empty;
                btnDeclineDate.Text = "Decline";
            }
            else
            {
                btnDeclineDate.BackColor = Color.FromArgb(255, 128, 128);
                btnDeclineDate.Text = "Declined";
                btnAcceptDate.BackColor = Color.Empty;
                btnAcceptDate.Text = "Accept";
            }
        }

        private void btnAcceptDate_Click(object sender, EventArgs e)
        {
            //access a public var in the main form (like ive made at top of this) to then set a value there;

            //Once pressed, change state to accepted and overide state of decline button (if it was declined)
            Accepted = true;
            updateADstate();

        }

        private void btnDeclineDate_Click(object sender, EventArgs e)
        {
            //access a public var in the main form (like ive made at top of this) to then set a value there;
            //Once pressed, change state to accepted and overide state of decline button (if it was declined)
            Accepted = false;
            updateADstate();

        }
    }
}
