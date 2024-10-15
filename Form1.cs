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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHostLogin_Click(object sender, EventArgs e)
        {
            //for testing
            bool validCredentials = true;

            //bool validCredentials = false;
            //check for email in database
            //if present hash pasword and compare to hash stored
            //if the same open the host view
            //else print incorrect password
            //else print We couldn't find your account
            if (validCredentials)
            {
                this.Hide();
                frmHostLandingPage hostLandingPage = new frmHostLandingPage();
                hostLandingPage.ShowDialog();
                this.Close();

            }
           
        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            //for testing
            bool validCredentials = true;

            //bool validCredentials = false;
            //check for email in database
            //if present hash pasword and compare to hash stored
            //if the same open the host view
            //else print incorrect password
            //else print We couldn't find your account
            if (validCredentials)
            {
                this.Hide();
                frmUserLandingPage userLandingPage = new frmUserLandingPage();
                userLandingPage.ShowDialog();
                this.Close();

            }
        }
    }
}
