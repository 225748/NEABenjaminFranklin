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
            fillFlpRotas();
        }

        private void fillFlpRotas()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            //string sqlCommand = "SELECT tblRota.RotaID, tblRota.FacilityID, tblRota.RotaName, tblFacility.FacilityName" +
            //" FROM (tblRota INNER JOIN tblFacility)" +
            //" WHERE tblRota.FacilityID = tblFacility.FacilityID" +
            //" ORDER BY RotaNumber";
            string sqlCommand = "SELECT tblRota.RotaID, tblRota.FacilityID, tblRota.RotaName, tblFacility.FacilityName" +
                " FROM (tblRota INNER JOIN tblFacility ON tblRota.FacilityID = tblFacility.FacilityID)";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            flpRotas.Controls.Clear();

            while (dr.Read()) // change this so all the sub items are added using a nested loop
            {//dr[0].ToString()
                cntrlRotaOverview ccRotaOverview = new cntrlRotaOverview();
                ccRotaOverview.RotaID = Convert.ToInt32(dr[0]);
                ccRotaOverview.FacilityID = Convert.ToInt32(dr[1]);
                ccRotaOverview.RotaName = dr[2].ToString();
                ccRotaOverview.FacilityName = dr[3].ToString();
                ccRotaOverview.Show();
                flpRotas.Controls.Add(ccRotaOverview);
            }
            if (!dr.Read())
            {
                //append a label saying please create a rota to manage wit the rota creation menu
            }
            dbConnector.Close();
        }
    }
}