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
    public partial class frmUserLandingPage : Form
    {
        public int UserID { get; set; }

        public frmUserLandingPage(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }

        private void frmUserLandingPage_Load(object sender, EventArgs e)
        {
            InitaliseForm(); //treat this function as the form load - it is used as a reset called from other functions
        }

        private void InitaliseForm()
        {
            FillADDates();
            FillFlpRotas();
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

        private void FillADDates()
        {
            //Filled list with testing values for now - fill lists from databases, be sure to include provision for no role
            //
            //In actual implementation, use a list of objects of a class and read it in a loop and then create a cc object for each
            List<string> userRotaDates = new List<string> { "12/10/2024", "19/10/2024", "30/03/2026", "12/09/2040" };
            List<string> userRotaRoles = new List<string> { "Sound", "Door Team", "Visuals", "NO ROLE" };
            List<string> userRotaTimes = new List<string> { "10am", "10am", "4pm", "3pm" };

            for (int i = 0; i < userRotaDates.Count(); i++)
            {
                cntrlAcceptDeclineDates ADModule = new cntrlAcceptDeclineDates();
                ADModule.Name = $"ADModule {i}";
                ADModule.Tag = ADModule.Name;
                ADModule.Date = userRotaDates[i];
                ADModule.Role = userRotaRoles[i];
                ADModule.Time = userRotaTimes[i];
                ADModule.Show();
                flpDates.Controls.Add(ADModule);
                
            }
            // check for no dates (like the no roles bit in create new rota)
        }
        private void FillFlpRotas()
        {
            //Add controls for the rotas this user currently has at least one instancerolenum in

            //Testing control
            cntrlRotaOverview cntrlRotaOverview = new cntrlRotaOverview("Pizza Planet", 17, "Auditorium", 1, "-510201", false);
            flpRotas.Controls.Add(cntrlRotaOverview);
        }

    }
}
