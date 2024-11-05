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
    public partial class frmHostLandingPage : Form
    {
        public frmHostLandingPage()
        {
            InitializeComponent();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser addNewUser = new frmAddNewUser();
            addNewUser.Show();
            //show not show dialogue here as i want it to close if the parent form closes
            //also why this form doesnt close too - dont want it
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.Show();
        }

        private void btnVMCRoles_Click(object sender, EventArgs e)
        {
            frmManageRoles frmManageRoles = new frmManageRoles();
            frmManageRoles.Show();
        }
    }
}
