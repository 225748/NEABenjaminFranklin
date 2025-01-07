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
    public partial class frmManageRotas : Form
    {
        public frmManageRotas()
        {
            InitializeComponent();
        }

        private void frmManageRotas_Load(object sender, EventArgs e)
        {
            FillFlpRotas();
        }
        public void RefresFlp()
        {
            FillFlpRotas();
        }
        private void FillFlpRotas()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT tblRota.RotaID, tblRota.FacilityID, tblRota.RotaName, tblRota.RotaThemeColour, tblFacility.FacilityName" +
                " FROM (tblRota INNER JOIN tblFacility ON tblRota.FacilityID = tblFacility.FacilityID)";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            flpRotas.Controls.Clear();

            while (dr.Read())
            {//dr[0].ToString()
                cntrlRotaOverview ccRotaOverview = new cntrlRotaOverview(dr[2].ToString(), Convert.ToInt32(dr[0]), dr[4].ToString(), Convert.ToInt32(dr[1]), dr[3].ToString());
                //ccRotaOverview.RotaID = Convert.ToInt32(dr[0]);
                //ccRotaOverview.FacilityID = Convert.ToInt32(dr[1]);
                //ccRotaOverview.RotaName = dr[2].ToString();
                //ccRotaOverview.ThemeColour = dr[3].ToString();
                //ccRotaOverview.FacilityName = dr[4].ToString();
                //Add sql to retrieve rota theme colour and add it to a new public in control
                ccRotaOverview.Show();
                flpRotas.Controls.Add(ccRotaOverview);
            }
            if (flpRotas.Controls.Count == 0)
            {
                //append a label saying please create a rota to manage with the rota creation menu
                Label lblNoRota = new Label();
                lblNoRota.Text = "There are no rotas to display.\nPlease create a rota to manage with the rota creation menu";
                lblNoRota.AutoSize = true;
                flpRotas.Controls.Add(lblNoRota);
            }
            dbConnector.Close();
        }
    }
}