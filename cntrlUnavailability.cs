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
        public cntrlUnavailability(int unavailabilityID, string duration)
        {
            InitializeComponent();
            UnavailabilityID = unavailabilityID;
            labelDates.Text = duration;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            string sqlCommand = $"DELETE FROM tblUnavailability WHERE UnavailabilityID = {UnavailabilityID}";
            dbConnector.Connect();
            dbConnector.DoSQL(sqlCommand);
            MessageBox.Show("Unavailability Deleted", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            (Application.OpenForms["frmUserUnavailability"] as frmUserUnavailability).FillFlp();
        }
    }
}
