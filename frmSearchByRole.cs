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
    public partial class frmSearchByRole : Form
    {
        private bool AllowListFill { get; set; }
        public frmSearchByRole()
        {
            InitializeComponent();
        }
        private void frmSearchByRole_Load(object sender, EventArgs e)
        {
            AllowListFill = false;
            FillCombo();
            cmbRoles.Text = "-- Select a Role -- ";
            AllowListFill = true;
        }
        private void DisplayUsers(int roleNum) //displays all users who have been assigned to this role
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT DISTINCT tblPeople.FirstName, tblPeople.LastName " +
                "FROM(((tblAssignedRotaRoles INNER JOIN " +
                "tblPeople ON tblAssignedRotaRoles.UserID = tblPeople.UserID) INNER JOIN " +
                "tblRotaRoles ON tblAssignedRotaRoles.RotaRoleNumber = tblRotaRoles.RotaRoleNumber) INNER JOIN " +
                "tblRoles ON tblRotaRoles.RoleNumber = tblRoles.RoleNumber) " +
                $"WHERE(tblRoles.RoleNumber = {roleNum}) " +
                "ORDER BY LastName, FirstName";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            lstUsers.Items.Clear();

            while (dr.Read())
            {
                lstUsers.Items.Add(dr[1].ToString());
                lstUsers.Items[lstUsers.Items.Count - 1].SubItems.Add(dr[0].ToString());
            }
            dbConnector.Close();
        }
        private void FillCombo() //Fills combo with a list of all roles
        {
            clsDBConnector dBConnector = new clsDBConnector();
            dBConnector.Connect();
            string sqlString = "SELECT RoleNumber, RoleName FROM tblRoles ORDER BY RoleName ";
            OleDbDataAdapter da = new OleDbDataAdapter(sqlString, dBConnector.GetConnectionString());
            DataSet ds = new DataSet();
            da.Fill(ds, "tblRoles");
            cmbRoles.DisplayMember = "RoleName";
            cmbRoles.ValueMember = "RoleNumber";
            cmbRoles.DataSource = ds.Tables["tblRoles"];
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AllowListFill)
            {
                DisplayUsers(Convert.ToInt32(cmbRoles.SelectedValue));
            }
        }
    }
}
