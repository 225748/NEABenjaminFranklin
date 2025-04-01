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
    public partial class cntrlUnavailability : UserControl
    {
        private int UnavailabilityID { get; set; }
        private bool HostMode { get; set; }
        public cntrlUnavailability(int unavailabilityID, string duration, bool hostMode = false)
        {
            InitializeComponent();
            UnavailabilityID = unavailabilityID;
            labelDates.Text = duration;
            HostMode = hostMode; 
        }
        private void cntrlUnavailability_Load(object sender, EventArgs e)
        {
            if (HostMode) //don't want to let hosts delete users unavailability
            {
                btnDelete.Visible = false;
                btnDelete.Enabled = false;
                this.Size = new Size(148, this.Height);//make control shorter as no delete button
            }
            else
            {
                btnDelete.Visible = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            string sqlCommand = $"DELETE FROM tblUnavailability WHERE UnavailabilityID = {UnavailabilityID}";
            dbConnector.Connect();
            dbConnector.DoSQL(sqlCommand);
            MessageBox.Show("Unavailability Deleted", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            (Application.OpenForms["frmUnavailability"] as frmUnavailability).FillFlp();
        }

    }
}
