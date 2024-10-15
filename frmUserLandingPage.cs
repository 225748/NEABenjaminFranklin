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
    public partial class frmUserLandingPage : Form
    {
        public frmUserLandingPage()
        {
            InitializeComponent();
        }

        private void frmUserLandingPage_Load(object sender, EventArgs e)
        {
            List<string> userRotaDates = new List<string> { "12/10/2024", "19/10/2024", "30/03/2026", "12/09/2040" };

            foreach (string date in userRotaDates)
            {
                cntrlAcceptDeclineDates ADModule = new cntrlAcceptDeclineDates();
                ADModule.Name = $"ADModule {date}";
                ADModule.Tag = ADModule.Name;
                ADModule.Date = date;
                ADModule.Show();
                flpDates.Controls.Add(ADModule);
            }

        }
    }
}
