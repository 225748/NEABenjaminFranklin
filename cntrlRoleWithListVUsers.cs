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
        public int RotaRoleNumber { get; set; }
        public List<int> AssignedRotaRoleIDs = new List<int>();
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
            string sqlCommand = "Select (FirstName & " + "', '" + "& LastName) as Name, UserID, FirstName, LastName " +
                "FROM tblPeople " +
                "ORDER BY LastName, FirstName";
            dbConnector.Connect();
            Usersdr = dbConnector.DoSQL(sqlCommand);
            while (Usersdr.Read())
            {
                lstVUsers.Items.Add(Usersdr[0].ToString());
                lstVUsers.Items[lstVUsers.Items.Count - 1].SubItems.Add(Usersdr[1].ToString());
            }

        }
        private int FindLargestID(string tableName, string keyName)//largest ID is allways the one you have just created
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlStr;
            dbConnector.Connect();
            sqlStr = $" SELECT MAX({keyName}) AS maxID FROM {tableName} ";
            dr = dbConnector.DoSQL(sqlStr);
            while (dr.Read())
            {
                return Convert.ToInt32(dr[0]);
            }
            dbConnector.Close();
            return 0;
        }
        public void AssignUsersToRotaRole()
        {
            for (int i = 0; i < lstVUsers.CheckedItems.Count; i++)
            {
                //First check if they already have been assigned this rota role, if so do nothing
                //else
                clsDBConnector dbConnector = new clsDBConnector();
                string cmdStr = $"INSERT INTO tblAssignedRotaRoles (RotaRoleNumber, UserID) " +
                    $"VALUES ({RotaRoleNumber}, '{Convert.ToInt32(lstVUsers.CheckedItems[i].SubItems[1].Text)}')";
                dbConnector.Connect();
                dbConnector.DoDML(cmdStr);
                dbConnector.Close();
                AssignedRotaRoleIDs.Add(FindLargestID("tblAssignedRotaRoles", "AssignedRotaRolesID"));
            }
        }
        

    }
}
