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
    public partial class frmManageRotaInstances : Form
    {
        public string RotaName { get; set; }
        public int RotaID { get; set; }
        public string FacilityName { get; set; }
        public int FacilityID { get; set; }
        public string ThemeColour { get; set; }

        public frmManageRotaInstances(string rotaName, int rotaID, string facilityName, int facilityID, string themeColour)
        {
            InitializeComponent();
            RotaName = rotaName;
            RotaID = rotaID;
            FacilityName = facilityName;
            FacilityID = facilityID;
            ThemeColour = themeColour;
        }

        private void frmManageRotaInstance_Load(object sender, EventArgs e)
        {
            InitaliseTextFields();
            FillFlpInstances();
        }

        private void InitaliseTextFields()
        {
            int lengthLimit = 20;
            if (FacilityName.Length > lengthLimit)
            { lblFacility.Text = FacilityName.Substring(0, lengthLimit - 3) + "..."; }
            else { lblFacility.Text = FacilityName; }
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

        private void FillFlpInstances()
        {

            //code below is tesiting for now
            //Do SQL TO get InstanceID, date and time and role numbers for rota
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            //select instance date, time and ID for this rota ID
            string sqlCommand = "SELECT RotaInstanceDateTime, RotaInstanceID " +
                "FROM tblRotaInstance " +
                $"WHERE(RotaID = {RotaID}) " +
                $"ORDER BY RotaInstanceDateTime";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            flpInstances.Controls.Clear();

            while (dr.Read())
            {
                string instanceDate = dr[0].ToString().Substring(0,10);
                string instanceTime = dr[0].ToString().Substring(11, 5);
                cntrlRotaInstance cntrlRotaInstance = new cntrlRotaInstance(RotaID, instanceDate, instanceTime, Convert.ToInt32(dr[1].ToString()));
                cntrlRotaInstance.Show();
                flpInstances.Controls.Add(cntrlRotaInstance);
            }
            if (flpInstances.Controls.Count == 0)
            {
                Label lblNoInstance = new Label();
                lblNoInstance.Text = "There are no instances to display.\nPlease create an instance to manage with the instance creation menu";
                lblNoInstance.AutoSize = true;
                flpInstances.Controls.Add(lblNoInstance);
            }
            dbConnector.Close();
        }


        private void btnAddInstance_Click(object sender, EventArgs e)
        {
            frmAddNewInstance frmAddNewInstance = new frmAddNewInstance(RotaID, RotaName, ThemeColour);
            frmAddNewInstance.ShowDialog();
        }
    }
}
