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
    public partial class frmAddNewInstance : Form
    {
        public int RotaID { get; set; }

        public frmAddNewInstance(int rotaID)
        {
            InitializeComponent();
            RotaID = rotaID;
        }

        private void frmAddNewInstance_Load(object sender, EventArgs e)
        {
            FillFlp();
            dtpDate.MinDate = DateTime.Now;
        }
        private void FillFlp()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT tblRoles.RoleName " +
                "FROM((tblRota INNER JOIN " +
                "tblRotaRoles ON tblRota.RotaID = tblRotaRoles.RotaID AND tblRota.RotaID = tblRotaRoles.RotaID) INNER JOIN " +
                "tblRoles ON tblRotaRoles.RoleNumber = tblRoles.RoleNumber) " +
                $"WHERE(tblRotaRoles.RotaID = {RotaID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                cntrlRoleWithListVUsers roleWithUsersLst = new cntrlRoleWithListVUsers();
                roleWithUsersLst.RoleName = dr[0].ToString();
                flpRoles.Controls.Add(roleWithUsersLst);
            }
            dbConnector.Close();
            
        }
        private void AddNewInstance()
        {
            //assign users to roles and create an instance of this date and time
            DateTime date = new DateTime(dtpDate.Value.Year,
                                    dtpDate.Value.Month,
                                    dtpDate.Value.Day,
                                    dtpTime.Value.Hour,
                                    dtpTime.Value.Minute,
                                    0, 0);
            //for each role update assigned roles with the UserID and role number and this instance

            //Have a public method on cntrlRoleListVUsers, called from this frm, to do sql for all users for its role
            //1.Create an instance of the rota with this datetime - can be done here
            //2.Create an assignedRotaRoleID using tblRotaRoles.RoleNumber and UserID - use public in cntrl?
            //3.Create RotaInstanceRole Number using assignedRotaRoleID and RotaInstanceID - use public in cntrl?

        }

        private void btnAddInstance_Click(object sender, EventArgs e)
        {
            AddNewInstance();
        }
    }
}
