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
        public void FillFlp() // called from the controls when they delete themselves too
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT DateStart, DateEnd, UnavailabilityID " +
                "FROM tblUnavailability " +
                $"WHERE(UserID = {UserID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                string duration = dr[0].ToString().Substring(0, 10) + " - " + dr[1].ToString().Substring(0, 10);
                cntrlUnavailability cntrlUnavailability = new cntrlUnavailability(Convert.ToInt32(dr[2].ToString()), duration);
                flpUnavailability.Controls.Add(cntrlUnavailability);
            }
            dbConnector.Close();
            if (flpUnavailability.Controls.Count == 0)
            {
                Label label = new Label();
                label.Text = "There are no unavailability durations to show";
                flpUnavailability.Controls.Add(label);
            }
        }
        private void AddUnavailability()
        {
            //Check if exists first
            bool exists = CheckForExistingUnavailability();
            if (exists)
            {
                MessageBox.Show("Unavailability already exists", "RotaConnect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //No existing unavailability so create
            try
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string cmdStr = $"INSERT INTO tblUnavailability  (UserID, StartDate, EndDate) " +
                    $"VALUES ({UserID}, '{dtpStart.Value.Date}','{dtpEnd.Value.Date}')";
                dbConnector.Connect();
                dbConnector.DoDML(cmdStr);
                dbConnector.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error adding unavailability to database\nUnavailability has not been added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckForExistingUnavailability()
        {
            //check if our unavailability matches / lies within an exisiting one
        }

        private void frmUserUnavailability_Load(object sender, EventArgs e)
        {
            FillFlp();
        }

        private void btnAddUnavailability_Click(object sender, EventArgs e)
        {
            AddUnavailability();
        }
    }
}
