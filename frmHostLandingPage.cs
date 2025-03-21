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
    public partial class frmHostLandingPage : Form
    {
        public int UserID { get; set; }

        public frmHostLandingPage(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }
        private void frmHostLandingPage_Load(object sender, EventArgs e)
        {
            lblFullName.Text = GetUserFullName(UserID);
        }
        private string GetUserFullName(int userID)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT FirstName, LastName " +
                "FROM tblPeople " +
                $"WHERE (UserID = {userID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);

            while (dr.Read())
            {
                return dr[0].ToString() + " " + dr[1].ToString();
            }
            dbConnector.Close();
            return "";
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser addNewUser = new frmAddNewUser();
            addNewUser.ShowDialog();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();
        }

        private void btnVMCRoles_Click(object sender, EventArgs e)
        {
            frmManageRoles frmManageRoles = new frmManageRoles();
            frmManageRoles.ShowDialog();
        }

        private void btnCreateRota_Click(object sender, EventArgs e)
        {
            frmCreateNewRota frmCreateNewRota = new frmCreateNewRota();
            frmCreateNewRota.ShowDialog();
        }

        private void btnManageRotas_Click(object sender, EventArgs e)
        {
            frmManageRotas frmManageRotas = new frmManageRotas();
            frmManageRotas.ShowDialog();
        }

        private void btnManageFacilities_Click(object sender, EventArgs e)
        {
            frmManageFacilities frmManageFacilities = new frmManageFacilities();
            frmManageFacilities.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Restart();
            Environment.Exit(0);
            //as forms were not closing when opening new ones, log out wouldn't reset the form indexes
            //problem with that is to access hostID for new assignment email, it uses forms index
            //frmInitial frmInitial = new frmInitial();
            //frmInitial.ShowDialog();
            //this.Close();
        }

        private void btnPasswordReset_Click(object sender, EventArgs e)
        {
            frmInitiatePasswordReset frmInitiatePasswordReset = new frmInitiatePasswordReset();
            frmInitiatePasswordReset.ShowDialog();
        }

        private void btnUnavailability_Click(object sender, EventArgs e)
        {
            frmUnavailability frmUnavailability = new frmUnavailability(UserID, true);
            frmUnavailability.ShowDialog();
        }

        private void btnSByRole_Click(object sender, EventArgs e)
        {
            frmSearchByRole frmSearchByRole = new frmSearchByRole();
            frmSearchByRole.ShowDialog();
        }
    }
    
}
