﻿using System;
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
    public partial class frmRotaSettings : Form
    {
        public string RotaName { get; set; }
        public int RotaID { get; set; }
        public string FacilityName { get; set; }
        public int FacilityID { get; set; }
        public string ThemeColour { get; set; }
        private List<clsRoles> rotaRolesList { get; set; }
        public frmRotaSettings(string rotaName, int rotaID, string facilityName, int facilityID, string themeColour)
        {
            InitializeComponent();
            RotaName = rotaName;
            RotaID = rotaID;
            FacilityName = facilityName;
            FacilityID = facilityID;
            ThemeColour = themeColour;
        }
        private void frmRotaSettings_Load(object sender, EventArgs e)
        {
            InitaliseInputFields();
        }
        private void InitaliseInputFields()
        {
            //populate combo and list
            txtRotaName.Text = RotaName;
            FillCombo();
            cmbFacility.SelectedIndex = cmbFacility.FindString(FacilityName);
            FillRolesList();
            PreSelectRoles();
            btnColourDisplay.BackColor = Color.FromArgb(Convert.ToInt32(ThemeColour));
            btnColourDisplay.Show();

        }
        private void FillCombo()//identical to one in create rota apart from no "select facility" line here
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
        }
        private void FillRolesList()//almost identical to one in create rota - apart from the sql and the while loop's contentes
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
        private void PreSelectRoles()
        {
            // work out if a given role has an associated rotarole for it (meaning its been checked for this rota)
            // if so then set its checked state to true
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT tblRoles.RoleName, tblRoles.RoleNumber " +
                "FROM((tblRota INNER JOIN tblRotaRoles ON tblRota.RotaID = tblRotaRoles.RotaID) INNER JOIN " +
                "tblRoles ON tblRotaRoles.RoleNumber = tblRoles.RoleNumber AND tblRotaRoles.RoleNumber = tblRoles.RoleNumber) " +
                $"WHERE(tblRotaRoles.RotaID = {RotaID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                for (int i = 0; i < lstVRoles.Items.Count; i++)
                {
                    if (lstVRoles.Items[i].Text == dr[0].ToString())
                    {
                        //the current role in the roles list is assigned to this database as it is in rota role
                        lstVRoles.Items[i].Checked = true;
                        rotaRolesList.Add(new clsRoles(dr[0].ToString(), Convert.ToInt32(dr[1].ToString()), true)); //add  role and number for this rota to a list to use for update, with checked = true

                    }
                    else
                    {
                        rotaRolesList.Add(new clsRoles(dr[0].ToString(), Convert.ToInt32(dr[1].ToString()))); //add role and number for this rota, not checked

                    }
                }
            }
            dbConnector.Close();
        }

        private void UpdateRota()
        {
            // validate inputs - for now directly assigning them
            string VrotaName = txtRotaName.Text;
            int VFacilityID = Convert.ToInt32(cmbFacility.SelectedValue.ToString());
            clsDBConnector dbConnector = new clsDBConnector();
            string sqlCommand = $"UPDATE tblRota" +
                $" SET RotaName = '{VrotaName}'" +
                $", RotaThemeColour = '{ThemeColour}'" +
                $", FacilityID = {VFacilityID}" +
                $" WHERE RotaID = {RotaID}";
            dbConnector.Connect();
            dbConnector.DoSQL(sqlCommand);
            dbConnector.Close();

            ////////////////////////////
            //THIS BIT IS NOT TESTED YET
            ////////////////////////////

            //now check for each role in the Vlist if it is assigned to this rota by using the list created by the sql which fills the vlistbox with assigned roles
            for (int i = 0; i < lstVRoles.Items.Count; i++)
            {
                if (lstVRoles.Items[i].Checked == true && rotaRolesList[i].CheckedInList == true) //checked in list and database
                {
                    //do nothing
                }
                else if (lstVRoles.Items[i].Checked == true && rotaRolesList[i].CheckedInList == false)//checked in list not in database
                {
                    //add to database
                    dbConnector = new clsDBConnector();
                    string cmdStr = $"INSERT INTO tblRotaRoles (RotaID, RoleNumber) " +
                        $"VALUES ({RotaID}, {rotaRolesList[i].RoleNumber})";
                    dbConnector.Connect();
                    dbConnector.DoDML(cmdStr);
                    dbConnector.Close();
                }
                else if (lstVRoles.Items[i].Checked == false && rotaRolesList[i].CheckedInList == true)//checked in database but not list
                {
                    //delete from database
                    dbConnector = new clsDBConnector();
                    string cmdStr = $"DELETE FROM tblRotaRoles WHERE RotaID = {RotaID} AND RoleNummber = {rotaRolesList[i].RoleNumber}";
                    dbConnector.Connect();
                    dbConnector.DoSQL(sqlCommand);
                }
                else
                {
                    //not in database or checked in list - do nothing
                }
            }
        }


        private void btnChangeThemeColour_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            //colorDialog.AllowFullOpen = false; restricts to system colours
            colorDialog.ShowDialog();
            btnChangeThemeColour.Text = "Change Rota Theme Colour";
            ThemeColour = colorDialog.Color.ToArgb().ToString();
            btnColourDisplay.BackColor = colorDialog.Color;
            btnColourDisplay.Show();
        }

        private void btnUpdateRota_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteRota_Click(object sender, EventArgs e)
        {

        }
    }
}
