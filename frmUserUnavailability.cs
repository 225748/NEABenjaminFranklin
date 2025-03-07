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
    public partial class frmUserUnavailability : Form
    { 
        public int UserID { get; set; }
        public frmUserUnavailability(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }
    }
}
