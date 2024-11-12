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

        private void frmCreateNewRota_Load(object sender, EventArgs e)
        {
            FillCombo();
            FillCheckedList();
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
        private void FillCheckedList()
        {
            chklstRoles.Items.Clear();
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT RoleName, RoleNumber FROM tblRoles ORDER BY RoleName";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                chklstRoles.Items.Add(dr[0].ToString());
                //lstRoles.Items.Add(dr[0].ToString(), dr[1].ToString());
            }
            if (!dr.Read())
            {
                chklstRoles.Text = "Please create a role to begin assigning";
            }
            dbConnector.Close();
        }
        private string GetRotaID(string rotaName, string rotaThemeColour, int facilityID)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "Select RotaID FROM tblRota" +
                $" WHERE RotaName = '{rotaName}'" +
                $" AND RotaThemeColour = '{rotaThemeColour}" +
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
        private void CreateRota()
        {
            bool succsessfulCreation = false;
            //yet to code roles into this
            //need to validate all inputs for presence checks including roles
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string rotaName = txtRotaName.Text.Replace("'", "''"); // Replace single quotes - sql thinks it is the end of a string
                string cmdStr = $"INSERT INTO tblRota (RotaName, RotaThemeColour, FacilityID) " +
                    $"VALUES ('{rotaName}', '{themeColour}', {Convert.ToInt32(cmbFacility.SelectedValue.ToString())})";
                dbConnector.Connect();
                dbConnector.DoDML(cmdStr);

                ////need to get rotaID to insert roles into tbl rota roles
                //string rotaID = GetRotaID(txtRotaName.Text, themeColour, Convert.ToInt32(cmbFacility.SelectedValue));
                //for (int i = 0; i < lstRoles.Items.Count; i++)
                //{
                //    if (lstRoles.Items[i].Checked == true)
                //    {
                //        //MessageBox.Show(lstRoles.Items[i].Text, lstRoles.Items[i].ImageKey);
                //        cmdStr = $"INSERT INTO tblRotaRoles (RotaID, RoleNumber) " +
                //            $"VALUES ({rotaID}, {lstRoles.Items[i].ImageKey})";
                //        dbConnector.DoDML(cmdStr);
                //    }
                //}//doesnt work - despite what error says its to do with formatting of the statement but not sql formatting

                dbConnector.Close();
                succsessfulCreation = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error adding rota to database\n Rota has not been created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
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
