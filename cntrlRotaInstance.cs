using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEABenjaminFranklin
{
    public partial class cntrlRotaInstance : UserControl
    {

        public string RotaDate { get; set; }
        public string RotaTime { get; set; }
        public List<int> RoleNumbers = new List<int>();

        public cntrlRotaInstance(string rotaDate, string rotaTime, List<int> roleNumbers)
        {
            InitializeComponent();
            RotaDate = rotaDate;
            RotaTime = rotaTime;
            foreach (int role in roleNumbers)
            {
                RoleNumbers.Add(role);
            }
            InitaliseTextFields();
            FillFlp();
        }
        public void InitaliseTextFields()
        {
            lblDate.Text = RotaDate;
            lblTime.Text = RotaTime;
        }
        public void FillFlp()
        {
            // See onenote design for plan
            // Fill this with a label for the role (use the list for number and sql it) then labels for each assigned user
            // if no assigned user - fill with "no user assigned" label
            // Repeat for all roles for this rota
            
        }
    }
}
