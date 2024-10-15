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
            //Filled list with testing values for now - fill lists from databases, be sure to include provision for no role
            List<string> userRotaDates = new List<string> { "12/10/2024", "19/10/2024", "30/03/2026", "12/09/2040" };
            List<string> userRotaRoles = new List<string> { "Sound", "Door Team", "Visuals","NO ROLE" };
            List<string> userRotaTimes = new List<string> { "10am", "10am", "4pm", "3pm" };

            for (int i = 0; i < userRotaDates.Count(); i++)
            {
                cntrlAcceptDeclineDates ADModule = new cntrlAcceptDeclineDates();
                ADModule.Name = $"ADModule {i}";
                ADModule.Tag = ADModule.Name;
                ADModule.Date = userRotaDates[i];
                ADModule.Role = userRotaRoles[i];
                ADModule.Time = userRotaTimes[i];
                ADModule.Show();
                flpDates.Controls.Add(ADModule);
            }

        }
    }
}
