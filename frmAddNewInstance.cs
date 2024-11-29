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
    }
}
