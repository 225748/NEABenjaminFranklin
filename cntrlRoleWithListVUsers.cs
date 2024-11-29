using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEABenjaminFranklin
{
    public partial class cntrlRoleWithListVUsers : UserControl
    {
        public string RoleName { get; set; }

        public cntrlRoleWithListVUsers()
        {
            InitializeComponent();
        }

        private void cntrlRoleWithListVUsers_Load(object sender, EventArgs e)
        {
            lblRoleName.Text = RoleName;
            FillChkList();
        }
        private void FillChkList()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader Usersdr;
            string sqlCommand = "Select (FirstName & " + "', '" + "& LastName) as Name " +
                "FROM tblPeople";
            dbConnector.Connect();
            Usersdr = dbConnector.DoSQL(sqlCommand);
            while (Usersdr.Read())
            {
                lstVUsers.Items.Add(Usersdr[0].ToString());
            }

        }

    }
}
