using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NEABenjaminFranklin
{
    public partial class frmCreateNewRota : Form
    {
        public frmCreateNewRota()
        {
            InitializeComponent();
        }
        private string themeColour { get; set; }
        //private List<clsRoles> roleList { get; set; } - not used
        // private List<string> selectedRoles { get; set; } - not used

        private void frmCreateNewRota_Load(object sender, EventArgs e)
        {
            FillCombo();
            FillRolesList();
            btnThemeColour.Text = "Set Rota Theme Colour";
            themeColour = "0";
            btnColourDisplay.Visible = false;
        }
        private void FillCombo()
        {
            clsDBConnector dBConnector = new clsDBConnector();
            dBConnector.Connect();
            string sqlString = "SELECT FacilityName, FacilityID FROM tblFacility ORDER BY FacilityName ";
            OleDbDataAdapter da = new OleDbDataAdapter(sqlString, dBConnector.GetConnectionString());
            DataSet ds = new DataSet();
            da.Fill(ds, "tblFacility");
            cmbFacility.DisplayMember = "FacilityName";
            cmbFacility.ValueMember = "FacilityID";
            cmbFacility.DataSource = ds.Tables["tblFacility"];
            cmbFacility.Text = "-- Select a Venue --";
        }

        private void FillRolesList()
        {
            lstVRoles.Items.Clear();
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "Select RoleName, RoleNumber FROM tblRoles ORDER BY RoleName";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                lstVRoles.Items.Add(dr[0].ToString());
                lstVRoles.Items[lstVRoles.Items.Count - 1].SubItems.Add(dr[1].ToString());
            }
            dbConnector.Close();
        }
        private string GetRotaID(string rotaName, string rotaThemeColour, int facilityID)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            rotaName = rotaName.Replace("'", "''"); // Replace single quotes - sql thinks it is the end of a string
            string sqlCommand = "Select RotaID FROM tblRota" +
                $" WHERE RotaName = '{rotaName}'" +
                $" AND RotaThemeColour = '{rotaThemeColour}'" +
                $" AND FacilityID = {facilityID}";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            string sqlReturn = "";
            while (dr.Read())
            {
                sqlReturn = sqlReturn + dr[0].ToString();
            }
            if (sqlReturn == "")
            {
                return null;
            }
            else
            {
                return sqlReturn;
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

        private void CreateRota()
        {
            bool succsessfulCreation = false;
            //need to validate all inputs for presence checks including roles

            clsDBConnector dbConnector = new clsDBConnector();
            string cmdStr;
            string rotaName = txtRotaName.Text.Replace("'", "''"); // Replace single quotes - sql thinks it is the end of a string
            cmdStr = $"INSERT INTO tblRota (RotaName, RotaThemeColour, FacilityID) " +
                $"VALUES ('{rotaName}', '{themeColour}', {Convert.ToInt32(cmbFacility.SelectedValue.ToString())})";
            dbConnector.Connect();
             dbConnector.DoDML(cmdStr);
            dbConnector.Close();

            //Now that rota has been created, create its roles in tblrotaroles
            //Old Code
            //int rotaID = Convert.ToInt32(GetRotaID(rotaName, themeColour, Convert.ToInt32(cmbFacility.SelectedValue.ToString())));

            int rotaID = FindLargestID("tblRota", "RotaID"); // - migrated getting userID to this method - max ID is allways the one you have just made
            for (int i = 0; i < lstVRoles.Items.Count; i++)
            {
                if (lstVRoles.Items[i].Checked == true)
                {
                    int roleNumber = Convert.ToInt32(lstVRoles.Items[i].SubItems[1].Text);
                    dbConnector = new clsDBConnector();
                    cmdStr = $"INSERT INTO tblRotaRoles (RotaID, RoleNumber) " +
                        $"VALUES ({rotaID}, {roleNumber})";
                    dbConnector.Connect();
                    dbConnector.DoDML(cmdStr);
                }
            }

            dbConnector.Close();
            succsessfulCreation = true;
            if (succsessfulCreation)
            {
                MessageBox.Show("Rota Created Successfully", "RotaConnect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();

        }
        private void btnThemeColour_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            //colorDialog.AllowFullOpen = false; restricts to system colours
            colorDialog.ShowDialog();
            btnThemeColour.Text = "Change Rota Theme Colour";
            themeColour = colorDialog.Color.ToArgb().ToString();
            btnColourDisplay.BackColor = colorDialog.Color;
            btnColourDisplay.Show();
        }

        private void btnCreateRota_Click(object sender, EventArgs e)
        {
            CreateRota();
        }

    }
}
