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
    public partial class frmAddNewInstance : Form
    {
        public int RotaID { get; set; }
        public string RotaName { get; set; }
        public string ThemeColour { get; set; }

        public frmAddNewInstance(int rotaID, string rotaName, string themeColour)
        {
            InitializeComponent();
            RotaID = rotaID;
            RotaName = rotaName;
            ThemeColour = themeColour; 
        }

        private void frmAddNewInstance_Load(object sender, EventArgs e)
        {
            FillFlp();
            dtpDate.MinDate = DateTime.Now;
            dtpTime.CustomFormat = "HH:mm"; //Captial HH for 24HR NOT for mins as that becomes month
            dtpTime.Format = DateTimePickerFormat.Custom;
            dtpTime.ShowUpDown = true;
            int lengthLimit = 20;
            if (RotaName.Length > lengthLimit)
            { lblRotaName.Text = RotaName.Substring(0, lengthLimit - 3) + "..."; }
            else { lblRotaName.Text = RotaName; }
            lblRotaName.Text = RotaName;
            if (ThemeColour == "0") //default - no user colour set
            {
                btnThemeColour.BackColor = Color.Silver;
            }
            else
            {
                btnThemeColour.BackColor = Color.FromArgb(Convert.ToInt32(ThemeColour));
            }
        }
        private void FillFlp()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT tblRoles.RoleName, tblRotaRoles.RotaRoleNumber " +
                "FROM((tblRota INNER JOIN " +
                "tblRotaRoles ON tblRota.RotaID = tblRotaRoles.RotaID AND tblRota.RotaID = tblRotaRoles.RotaID) INNER JOIN " +
                "tblRoles ON tblRotaRoles.RoleNumber = tblRoles.RoleNumber) " +
                $"WHERE(tblRotaRoles.RotaID = {RotaID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                cntrlRoleWithListVUsers cntrlroleWithUsersList = new cntrlRoleWithListVUsers();
                cntrlroleWithUsersList.RoleName = dr[0].ToString();
                cntrlroleWithUsersList.RotaRoleNumber = Convert.ToInt32(dr[1]);
                cntrlroleWithUsersList.RotaID = RotaID;
                flpRoles.Controls.Add(cntrlroleWithUsersList);
            }
            dbConnector.Close();
            
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

        private bool CheckForExistingInstance(int rotaID, DateTime dateTime)
        {
            //MessageBox.Show(dateTime.ToString("MM/dd/yyyy HH:mm:00"));
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT RotaInstanceID " +
                "FROM tblRotaInstance " +
                $"WHERE (RotaID = {rotaID}) " +
                $"AND (RotaInstanceDateTime = #{dateTime.ToString("MM/dd/yyyy HH:mm:00")}#)"; //Convert date to us format with time
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                return true;
            }
            dbConnector.Close();
            return false;
        }

        private void AddNewInstance()
        {
            //assign users to roles and create an instance of this date and time
            DateTime dateTime = new DateTime(dtpDate.Value.Year,
                                    dtpDate.Value.Month,
                                    dtpDate.Value.Day,
                                    dtpTime.Value.Hour,
                                    dtpTime.Value.Minute,
                                    0, 0);


            //Need to do// -------
            //1. --- Check if this datetime  of this specific rota already exisits, if so dont do any more of these steps
            bool exists = CheckForExistingInstance(RotaID, dateTime);

            if (exists)
            {
                MessageBox.Show("An instance of this rota for this date and time already exists, please select another date/time", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                //1a.Create an instance of the rota with this datetime

                clsDBConnector dbConnector = new clsDBConnector();
                string cmdStr = $"INSERT INTO tblRotaInstance (RotaID, RotaInstanceDateTime) " +
                    $"VALUES ({RotaID}, '{Convert.ToString(dateTime)}')";
                dbConnector.Connect();
                dbConnector.DoDML(cmdStr);
                dbConnector.Close();
                int rotaInstanceID = FindLargestID("tblRotaInstance", "RotaInstanceID");

                foreach (cntrlRoleWithListVUsers cntrl in flpRoles.Controls)
                {
                    //2 check if an assigned rota role id for this user id, role and this rota already exsist, if so do not add one - do this in the cntrl
                    //2a.Create an assignedRotaRoleID using tblRotaRoles.RoleNumber and UserID for each role control
                    cntrl.AssignUsersToRotaRole();

                    //For a new instance we dont need to check if an instance role already exists - when editing you will need to check
                    //3.Create RotaInstanceRole Number using assignedRotaRoleID pulled from each control and RotaInstanceID from local var
                    for (int i = 0; i < cntrl.AssignedRotaRoleIDs.Count; i++)
                    {
                        dbConnector = new clsDBConnector();
                        cmdStr = $"INSERT INTO tblRotaInstanceRoles (RotaInstanceID, AssignedRotaRolesID) " +
                            $"VALUES ({rotaInstanceID}, {cntrl.AssignedRotaRoleIDs[i]})";
                        dbConnector.Connect();
                        dbConnector.DoDML(cmdStr);
                        dbConnector.Close();
                    }
                }

                //Check if successfull ----- to do
                MessageBox.Show("Date Added and User(s) Assigned Successfully", "Rota Connect Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddInstance_Click(object sender, EventArgs e)
        {
            AddNewInstance();
            this.Close();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            //Not working correctly - forcing time and not allowing user to update
            //if (dtpDate.Value.ToString("HH:mm") == DateTime.Now.ToString("HH:mm"))//set min time to now if date is also today, else allow any time
            //{
            //    dtpTime.MinDate = DateTime.Now;
            //}
            //else
            //{
            //    DateTime dateTime = new DateTime(DateTime.Now.Year,
            //            DateTime.Now.Month,
            //            DateTime.Now.Day,
            //            0,
            //            0,
            //            0, 0);
            //    dtpTime.MinDate = dateTime;
            //}
        }
    }
}
