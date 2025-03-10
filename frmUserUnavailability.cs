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
    public partial class frmUserUnavailability : Form
    {
        public int UserID { get; set; }
        public frmUserUnavailability(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }
        private void frmUserUnavailability_Load(object sender, EventArgs e)
        {
            FillFlp();
            dtpStart.MinDate = DateTime.Now;
            dtpEnd.MinDate = DateTime.Now;
        }
        public void FillFlp() // called from the controls when they delete themselves too
        {
            flpUnavailability.Controls.Clear();
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT DateStart, DateEnd, UnavailabilityID " +
                "FROM tblUnavailability " +
                $"WHERE(UserID = {UserID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                DateTime DateEnd = Convert.ToDateTime(dr[1].ToString());
                if (DateEnd >= DateTime.Today.Date)
                {
                    string duration = dr[0].ToString().Substring(0, 10) + " - " + dr[1].ToString().Substring(0, 10);
                    cntrlUnavailability cntrlUnavailability = new cntrlUnavailability(Convert.ToInt32(dr[2].ToString()), duration);
                    flpUnavailability.Controls.Add(cntrlUnavailability);
                }
            }
            dbConnector.Close();
            if (flpUnavailability.Controls.Count == 0)
            {
                //This label is not being shown properly - its cuts it off
                lblNoToShow.Visible = true;
                Label label = new Label();
                label.Text = "There are no existing unavailability durations to display";
                label.Visible = true;
                label.MinimumSize = new System.Drawing.Size(270, 13);
                flpUnavailability.Controls.Add(label);
            }
            else
            {
                lblNoToShow.Visible = false;
            }
        }
        private void AddUnavailability()
        {
            //Check if exists first
            bool exists = CheckForExistingUnavailability(dtpStart.Value.Date, dtpEnd.Value.Date, UserID);
            if (exists)
            {
                MessageBox.Show("This unavailability conflicts with an exisiting unavailability period.\n\n" +
                    "Please review your existing unavailability", "RotaConnect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Check if start date is before today
            if (dtpStart.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Unavailability can not be added for the past", "RotaConnect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Check if end date is before start date
            if (dtpEnd.Value.Date < dtpStart.Value.Date)
            {
                MessageBox.Show("End date cannot be before the start date", "RotaConnect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //No existing unavailability so create
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string cmdStr = $"INSERT INTO tblUnavailability  (UserID, DateStart, DateEnd) " +
                    $"VALUES ({UserID}, '{dtpStart.Value.Date}','{dtpEnd.Value.Date}')";
                dbConnector.Connect();
                dbConnector.DoDML(cmdStr);
                dbConnector.Close();
                MessageBox.Show("Unavailability Added", "RotaConnect Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error adding unavailability to database\nUnavailability has not been added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FillFlp();//refresh the flp
        }

        private bool CheckForExistingUnavailability(DateTime proposedStart, DateTime proposedEnd, int userID)
        {
            //check if our unavailability matches / lies within an exisiting one
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT DateStart, DateEnd " +
                "FROM tblUnavailability " +
                $"WHERE(UserID = {userID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            bool conflict = false;
            while (dr.Read())
            {
                DateTime existingStart = Convert.ToDateTime(dr[0]);
                DateTime existingEnd = Convert.ToDateTime(dr[1]);
                if (proposedStart >= existingStart && proposedStart <= existingEnd)
                {
                    conflict = true;
                }
                else if (proposedEnd >= existingStart && proposedEnd <= existingEnd)
                {
                    conflict = true;
                }
                else if (existingStart >= proposedStart && existingEnd <= proposedEnd)
                {
                    conflict=true;
                }
            }
            return conflict;
        }


        private void btnAddUnavailability_Click(object sender, EventArgs e)
        {
            AddUnavailability();
        }
    }
}
