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


        public cntrlAcceptDeclineDates()
        {
            InitializeComponent();
        }

        private void cntrlAcceptDeclineDates_Load(object sender, EventArgs e)
        {
            lblDate.Text = Date;
            lblRole.Text = Role;
        }

        private void btnAcceptDate_Click(object sender, EventArgs e)
        {
            //access a public var in the main form (like ive made at top of this) to then set a value there;
        }

        private void btnDeclineDate_Click(object sender, EventArgs e)
        {
            //access a public var in the main form (like ive made at top of this) to then set a value there;
        }
    }
}
