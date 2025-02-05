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
        private string Date { get; set; }
        private string Time { get; set; }
        private string RoleName { get; set; }
        private string RotaName { get; set; }

        private int RotaID { get; set; }
        private int InstanceID { get; set; }
        private string RotaInstanceRoleNumber { get; set; }
        private int UserID  { get; set; }


        public bool Accepted { get; set; }

        public cntrlAcceptDeclineDates(string date, string time, string roleName, string rotaName, int rotaID, int instanceID, int rotaInstanceRoleNumber, int userID)
        {
            InitializeComponent();
        }

        private void cntrlAcceptDeclineDates_Load(object sender, EventArgs e)
        {
            lblDate.Text = Date;
            lblTime.Text = Time;
            lblRole.Text = RoleName;
            lblRotaName.Text = RotaName;
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
