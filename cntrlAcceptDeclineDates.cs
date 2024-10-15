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
        public string Time { get; set; }
        public string Role { get; set; }
        public bool Accepted { get; set; }

        public cntrlAcceptDeclineDates()
        {
            InitializeComponent();
        }

        private void cntrlAcceptDeclineDates_Load(object sender, EventArgs e)
        {
            lblDate.Text = Date;
            lblTime.Text = Time;
            lblRole.Text = Role;
            btnAcceptDate.Enabled = true;
            btnDeclineDate.Enabled = true;
        }

        private void updateADstate()
        {//used for both inital button states (I.e. if user previously A/D) and updates
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
            Accepted = true;
            updateADstate();
        }

        private void btnDeclineDate_Click(object sender, EventArgs e)
        {
            Accepted = false;
            updateADstate();
        }
    }
}
