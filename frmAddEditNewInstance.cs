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
    public partial class frmAddEditNewInstance : Form
    {
        public int RotaID { get; set; }
        public string RotaName { get; set; }
        public string ThemeColour { get; set; }
        public bool EditMode { get; set; }
        private List<string> UnassignableUsers = new List<string>();
        //IF edit mode
        public int EditModeInstanceID { get; set; }
        public DateTime EditModeDateTime { get; set; }
        public int HostID { get; set; }
        public bool DateTimeChanged { get; set; }

        public frmAddEditNewInstance(int rotaID, string rotaName = "", string themeColour = "", bool editMode = false, int InstanceIDIfEditMode = 0, string ifEditModeInstanceDateTime = "")
        {
            InitializeComponent();
            RotaID = rotaID;

            //If we have only been given rotaID, do sql to get name and theme colour - provision for the cntrlRotaInstance creating an object of this
            //As the cntrl itself is not given this info

            if (rotaName == "" | themeColour == "")
            {
                clsDBConnector dbConnector = new clsDBConnector();
                OleDbDataReader dr;
                string sqlCommand = "SELECT RotaName, RotaThemeColour " +
                    "FROM tblRota " +
                    $"WHERE RotaID = {rotaID}";
                dbConnector.Connect();
                dr = dbConnector.DoSQL(sqlCommand);

                while (dr.Read())
                {
                    RotaName = dr[0].ToString();
                    ThemeColour = dr[1].ToString();
                }
                dbConnector.Close();
            }
            else
            {
                RotaName = rotaName;
                ThemeColour = themeColour;
            }
            EditMode = editMode;
            EditModeInstanceID = InstanceIDIfEditMode;
            //Pull the host's id from the landing page which is the second form to open
            HostID = (Application.OpenForms[1] as frmHostLandingPage).UserID;

            DateTimeChanged = false;

            if (ifEditModeInstanceDateTime != "")
            {
                EditModeDateTime = Convert.ToDateTime(ifEditModeInstanceDateTime);
            }
        }

        private void frmAddNewInstance_Load(object sender, EventArgs e)
        {
            FillFlp();
            //dtpDate.MinDate = DateTime.Now; //Not for now as makes issues for the update
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

            if (EditMode)
            {

                this.Text = "Update / Delete Instance";
                dtpDate.Value = Convert.ToDateTime(EditModeDateTime.Date.ToString());
                dtpTime.Value = Convert.ToDateTime(EditModeDateTime.TimeOfDay.ToString());
                pnlEditMode.Enabled = true;
                pnlEditMode.Show();
                btnAddInstance.Enabled = false;
                btnAddInstance.Hide();
            }
            else
            {
                this.Text = "Add New Instance";
                pnlEditMode.Enabled = false;
                pnlEditMode.Hide();
                btnAddInstance.Enabled = true;
                btnAddInstance.Show();
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
                if (EditMode)
                {//Need to fill with currently selected users
                    cntrlroleWithUsersList.PreSelectUsers = true;
                    cntrlroleWithUsersList.InstanceID = EditModeInstanceID;
                }
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
            int ret = 0;
            while (dr.Read())
            {
                ret = Convert.ToInt32(dr[0]);
            }
            dbConnector.Close();
            return ret;
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
            bool ret = false;
            while (dr.Read())
            {
                ret = true;
            }
            dbConnector.Close();
            return ret;
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
                    //1a,2,2a done in cntrl.AssignUsersToRotaRole

                    //1a see if user has conflicting unavailability
                    //2 check if an assigned rota role id for this user id, role and this rota already exsist, if so do not add one - do this in the cntrl
                    //2a.Create an assignedRotaRoleID using tblRotaRoles.RoleNumber and UserID for each role control
                   
                    cntrl.AssignUsersToRotaRole(rotaInstanceID);

                    //For a new instance we dont need to check if an instance role already exists - when editing you will need to check
                    //3.Create RotaInstanceRole Number using assignedRotaRoleID pulled from each control and RotaInstanceID from local var
                    for (int i = 0; i < cntrl.AssignedRotaRoleIDs.Count; i++)
                    {
                        dbConnector = new clsDBConnector();
                        cmdStr = $"INSERT INTO tblRotaInstanceRoles (RotaInstanceID, AssignedRotaRolesID, AssignedByID) " +
                            $"VALUES ({rotaInstanceID}, {cntrl.AssignedRotaRoleIDs[i]}, {HostID})";
                        dbConnector.Connect();
                        dbConnector.DoDML(cmdStr);
                        dbConnector.Close();
                        Email(HostID, rotaInstanceID, cntrl.AssignedRotaRoleIDs[i]);
                    }
                    //Check if this control had any unassignable users (due to unavailability)
                    //If so, add them to our master list to output in one go at the end (instead of each control outputting their own)
                    foreach (string fullName in cntrl.UnassignableUsers)
                    {
                        UnassignableUsers.Add(fullName);
                    }
                    this.Cursor = Cursors.Default;
                }

                MessageBox.Show("Date Added and User(s) Assigned Successfully", "Rota Connect Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //If we have some unassignable users (due to unavailability), then put them into a string and output
                if (UnassignableUsers.Count != 0 )
                {
                    string unassigned = "";
                    foreach (string fullName in UnassignableUsers)
                    {
                        unassigned += fullName + ", ";
                    }
                    unassigned = unassigned.Remove(unassigned.Length - 2); //remove the last ", " (removes everything after the last full name)
                    MessageBox.Show($"The following user/s have not been assigned due to unavailability\n{unassigned}", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private int CheckForExistingRotaInstanceRoleNumber(int assignedRotaRoleID, int instanceID)//Used in edit mode
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT RotaInstanceRoleNumber " +
                "FROM tblRotaInstanceRoles " +
                $"WHERE(RotaInstanceID = {instanceID}) AND(AssignedRotaRolesID = {assignedRotaRoleID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            int ret = 0;
            while (dr.Read())
            {
                ret = Convert.ToInt32(dr[0].ToString());
            }
            dbConnector.Close();
            return ret;
        }

        public bool CheckForUnavailabiliyConflict(int userID, int rotaInstanceID) //also called from the controls for add
        {
            //Get this instance's date
            DateTime instanceDateTime = GetInstanceDateTime(rotaInstanceID).Date;

            //Check against user unavailability
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
                DateTime StartDate = Convert.ToDateTime(dr[0].ToString());
                DateTime EndDate = Convert.ToDateTime(dr[1].ToString());
                if (instanceDateTime >= StartDate && instanceDateTime <= EndDate)
                {
                    conflict = true;
                }
            }
            dbConnector.Close();
            return conflict;
        }
        private DateTime GetInstanceDateTime(int rotaInstanceID)
        {
            DateTime instanceDateTime = DateTime.Now; //creating the object, don't worry about its value here

            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT RotaInstanceDateTime " +
                "FROM tblRotaInstance " +
                $"WHERE(RotaInstanceID = {rotaInstanceID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                instanceDateTime = Convert.ToDateTime(dr[0].ToString());
            }
            dbConnector.Close();
            return instanceDateTime;
        }

        private void UpdateDateTimeDifference(int rotaInstanceID)
        {
            DateTime instanceDateTime = DateTime.Now; //creating the object, don't worry about its value here
            instanceDateTime = GetInstanceDateTime(rotaInstanceID);

            //Check if datetime has changed from what is stored
            string requiredUpdate = "";
            if (instanceDateTime.Date.ToString() != dtpDate.Value.Date.ToString())
            {
                requiredUpdate = requiredUpdate + "date";
            }
            if (instanceDateTime.TimeOfDay.ToString() != dtpTime.Value.TimeOfDay.ToString())
            {
                requiredUpdate = requiredUpdate + "time";
            }

            if (requiredUpdate != "")
            {
                DateTime newDateTime = Convert.ToDateTime(dtpDate.Value.Date.ToString().Substring(0, 10) + " " + dtpTime.Value.TimeOfDay);

                clsDBConnector dbConnector = new clsDBConnector();
                string cmdStr = "UPDATE tblRotaInstance " +
                $"SET RotaInstanceDateTime = '{newDateTime}' " +
                $"WHERE (RotaInstanceID = {rotaInstanceID})";
                dbConnector.Connect();
                dbConnector.DoDML(cmdStr);
                dbConnector.Close();

                //set the public so email system knows to send emails to those already assigned as the date and or time has changed
                DateTimeChanged = true;
            }
        }

        private void UpdateInstance(int rotaInstanceID)
        {
            //as email takes a while - discourages people from spam clicking
            this.Cursor = Cursors.WaitCursor;

            //Check if date and time are different to that which is stored, if so - update
            UpdateDateTimeDifference(rotaInstanceID);

            //For every cntrl in flproles, get each userID in its lstVUsers and see if checked
            foreach (cntrlRoleWithListVUsers cntrlRoleWithListVUsers in flpRoles.Controls)
            {
                List<clsUser> desiredUpdatelst = new List<clsUser>();
                List<clsUser> needRotaInstRoleNum = new List<clsUser>();
                //  - remember lstVusers is the actual lists
                //  THEREFORE it is want the user wants as the update
                //  userslist is a list of checked users in a class list upon creation
                //  THEREFORE it can be used to compare as a comparison to see what has changed


                for (int i = 0; i < cntrlRoleWithListVUsers.lstVUsers.Items.Count; i++)
                {//sub items of this list is userID
                    //This code gets userID of each user in a cntrl's listV and whether is it checked or not and assigns to an update list
                    clsUser user = new clsUser();
                    user.userID = Convert.ToInt32(cntrlRoleWithListVUsers.lstVUsers.Items[i].SubItems[1].Text);
                    if (cntrlRoleWithListVUsers.lstVUsers.Items[i].Checked == true)
                    {
                        user.CheckedinListV = true;
                    }
                    else
                    {
                        user.CheckedinListV = false;
                    }
                    desiredUpdatelst.Add(user); //list containing all userIDs and whether they are checked or not
                }
                //Assigning to list and then reading from it to prevent too many nested loops

                //If checked then see if there is an exisitng AssignedRotaRoleNunber for that user (done in control as above i believe)
                foreach (clsUser user in desiredUpdatelst)
                { 
                    if (user.CheckedinListV == true)
                    {
                        bool unavailable = CheckForUnavailabiliyConflict(user.userID, rotaInstanceID);
                        var result = DialogResult.No;//initalised here to use later
                        if (unavailable)
                        {
                            //Get their full name
                            string fullName = "";
                            clsDBConnector dbConnector = new clsDBConnector();
                            OleDbDataReader dr;
                            string sqlCommand = "SELECT FirstName, LastName " +
                                "FROM tblPeople " +
                                $"WHERE UserID = {user.userID}";
                            dbConnector.Connect();
                            dr = dbConnector.DoSQL(sqlCommand);
                            while (dr.Read())
                            {
                                fullName = (dr[0].ToString() + " " + dr[1].ToString());
                            }
                            dbConnector.Close();

                            //Get role name for dialog message
                            string roleName = cntrlRoleWithListVUsers.RoleName;

                            result = MessageBox.Show($"{fullName} has conflicting unavailability with this date.\n" +
                                                    "Would you like to ignore this unavailability and assign them anyways?\n" +
                                                    $"(Currently Assigned to: {roleName})" +
                                                    "", "Unavailability Conflict", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.No)
                            {
                                //append their name to a list to read out at end
                                UnassignableUsers.Add(fullName);
                            }

                            //if they still want to assign, proceed as usual
                        }
                        if (!unavailable | result == DialogResult.Yes)
                        {//allows for all available users or users we have chosen to ignore their unavailability to continue with assignment

                            user.assignedRotaRoleID = cntrlRoleWithListVUsers.CheckForExistingAssignmentByUserID(user.userID);
                            if (user.assignedRotaRoleID != 0) //There is one, and it has been returned
                            {
                                //If so check if there is an existing RotaInstanceRoleNumber for that AssignedRotaRoleNunber and InstanceID


                                int rotaInstanceRoleNumber = CheckForExistingRotaInstanceRoleNumber(user.assignedRotaRoleID, EditModeInstanceID);


                                //If so do nothing as it started as checked and has ended as checked
                                //But if the date time has changed then send out a new assignement email to those assigned
                                if (DateTimeChanged == true)
                                {
                                    Email(HostID, rotaInstanceID, user.assignedRotaRoleID);
                                }

                                //If there isn't, add them to a list of people needing to be added to the Instance with their assRotaRoleNum
                                //started unchecked (not assigned to instance) but have has this assigned rota role before
                                if (rotaInstanceRoleNumber == 0) //0  returned as no RIRN found
                                {
                                    needRotaInstRoleNum.Add(user);
                                }
                            }
                            else //0 has been returned therefore there isnt an existing assRotaRoleID
                            {//checked but no AssignedRotaRoleNumber, make one and then add them to the list of people needing a RIRN
                             //They Started unchecked and have never had this assigned rota role before

                                clsDBConnector dbConnector = new clsDBConnector();
                                string cmdStr = $"INSERT INTO tblAssignedRotaRoles (RotaRoleNumber, UserID) " +
                                    $"VALUES ({cntrlRoleWithListVUsers.RotaRoleNumber}, '{user.userID}')";
                                dbConnector.Connect();
                                dbConnector.DoDML(cmdStr);
                                dbConnector.Close();
                                user.assignedRotaRoleID = FindLargestID("tblAssignedRotaRoles", "AssignedRotaRolesID"); //Gets their new assRotaRoleID
                                needRotaInstRoleNum.Add(user);
                            }
                        }
                    }
                    else//not checked
                    {//If not checked, see if they have an exsiting AssignedRotaRoleNunber for this role and rota
                        user.assignedRotaRoleID = cntrlRoleWithListVUsers.CheckForExistingAssignmentByUserID(user.userID);
                        if (user.assignedRotaRoleID != 0)//There is one, and it has been returned
                        {
                            //Check if they were assigned to this instance by checking for RotaInstanceRoleNumber for that AssignedRotaRoleNunber and InstanceID
                            int rotaInstanceRoleNumber = CheckForExistingRotaInstanceRoleNumber(user.assignedRotaRoleID, EditModeInstanceID);
                            if (rotaInstanceRoleNumber != 0)//There is a RotaInstanceRole Number, delete it (remove them from this instance)
                            {
                                clsDBConnector dbConnector = new clsDBConnector();
                                string sqlCommand = $"DELETE FROM tblRotaInstanceRoles " +
                                    $"WHERE RotaInstanceID = {rotaInstanceID} AND AssignedRotaRolesID = {user.assignedRotaRoleID}";
                                dbConnector.Connect();
                                dbConnector.DoSQL(sqlCommand);
                                dbConnector.Close();
                            }
                            //If a RIRN = 0 do nothing (They've had the role before but were never assigned to it for this specific instance hence 0)
                        }
                        //No assRotaRoleID, do nothing (They've never had the role before on this rota and therefore are not assigned to it)
                    }
                }
                //For everyone in the list to be be assigned RotaInstanceRoleNumber, use their AssignedRotaRoleNunber and the InstanceID
                //They started unchecked but we want to add them.
                foreach (clsUser user in needRotaInstRoleNum)
                {
                    clsDBConnector dbConnector = new clsDBConnector();
                    string cmdStr = $"INSERT INTO tblRotaInstanceRoles (RotaInstanceID, AssignedRotaRolesID, AssignedByID) " +
                        $"VALUES({rotaInstanceID},{user.assignedRotaRoleID}, {HostID})";
                    dbConnector.Connect();
                    dbConnector.DoDML(cmdStr);
                    dbConnector.Close();
                    Email(HostID, rotaInstanceID, user.assignedRotaRoleID);
                }
            }

            if (UnassignableUsers.Count != 0)
            {
                string unassigned = "";
                foreach (string fullName in UnassignableUsers)
                {
                    unassigned += fullName + ", ";
                }
                unassigned = unassigned.Remove(unassigned.Length - 2); //remove the last ", " (removes everything after the last full name)
                MessageBox.Show($"The following user/s have not been assigned due to unavailability\n{unassigned}", "Rota Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Email(int hostID, int rotaInstanceID, int assignedRotaRolesID) //NOT TESTED YET!
        {
            //If start date is before today probably best not to email them
            if (dtpDate.Value < DateTime.Today.Date)
            {
                MessageBox.Show("Before Today");
                return;
            }

            //Get name of host
            string hostFullName = "";
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlCommand = "SELECT FirstName, LastName " +
                "FROM tblPeople " +
                $"WHERE UserID = {hostID}";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                hostFullName = dr[0].ToString() + " " + dr[1].ToString();
            }
            dbConnector.Close();

            //Get user email
            string emailAddress = "";
            dbConnector = new clsDBConnector();
            sqlCommand = "SELECT tblPeople.Email " +
                "FROM(tblAssignedRotaRoles INNER JOIN " +
                "tblPeople ON tblAssignedRotaRoles.UserID = tblPeople.UserID) " +
                $"WHERE(tblAssignedRotaRoles.AssignedRotaRolesID = {assignedRotaRolesID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                emailAddress = dr[0].ToString();
            }
            dbConnector.Close();

            //Get rotaName, date, time, role
            string rotaName = ""; string date = ""; string time = ""; string role = ""; string firstName = "";
            dbConnector = new clsDBConnector();
            sqlCommand = "SELECT tblRotaInstance.RotaInstanceDateTime, tblRota.RotaName, " +
                "tblRoles.RoleName, tblPeople.FirstName " +
                "FROM ((((((tblRotaInstanceRoles INNER JOIN " +
                "tblRotaInstance ON tblRotaInstanceRoles.RotaInstanceID = tblRotaInstance.RotaInstanceID) INNER JOIN " +
                "tblRota ON tblRotaInstance.RotaID = tblRota.RotaID) INNER JOIN " +
                "tblAssignedRotaRoles ON tblRotaInstanceRoles.AssignedRotaRolesID = tblAssignedRotaRoles.AssignedRotaRolesID) INNER JOIN " +
                "tblRotaRoles ON tblRota.RotaID = tblRotaRoles.RotaID AND tblRotaRoles.RotaRoleNumber = tblAssignedRotaRoles.RotaRoleNumber) INNER JOIN " +
                "tblRoles ON tblRotaRoles.RoleNumber = tblRoles.RoleNumber) INNER JOIN " +
                "tblPeople ON tblAssignedRotaRoles.UserID = tblPeople.UserID) " +
                $"WHERE(tblRotaInstanceRoles.AssignedRotaRolesID = {assignedRotaRolesID}) AND (tblRotaInstanceRoles.RotaInstanceID = {rotaInstanceID})";
            dbConnector.Connect();
            dr = dbConnector.DoSQL(sqlCommand);
            while (dr.Read())
            {
                date = dr[0].ToString().Substring(0, 10);
                time = dr[0].ToString().Substring(11, 5);
                rotaName = dr[1].ToString();
                role = dr[2].ToString();
                firstName = dr[3].ToString();
            }
            dbConnector.Close();

            //Email
            clsEmailManager emailManager = new clsEmailManager();

            //Retrieve template
            string templateFilePath = (AppDomain.CurrentDomain.BaseDirectory + "/Html_Email_Templates/newRotaAssignment.html");//directs to its own debug folder and then the file

            //Make an array of variables to replace in the html template
            clshtmlVariable[] variableReplacements = new clshtmlVariable[6];//num of unique variables in html template

            //for every unique variable in the template do this
            variableReplacements[0] = new clshtmlVariable("{firstName}", firstName);
            variableReplacements[1] = new clshtmlVariable("{rota}", rotaName);
            variableReplacements[2] = new clshtmlVariable("{date}", date);
            variableReplacements[3] = new clshtmlVariable("{time}", time);
            variableReplacements[4] = new clshtmlVariable("{role}", role);
            variableReplacements[5] = new clshtmlVariable("{hostFullName}", hostFullName);


            string htmlBody = emailManager.ReadAndPopulateEmailTemplate(templateFilePath, variableReplacements);
            try
            {
                emailManager.SendEmail(emailAddress, htmlBody, $"Your new {rotaName} rota assignment!");
            }
            catch (Exception)
            {
                //didn't send
            }
        }

        private void DeleteInstance(int rotaInstanceID)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            string sqlCommand = $"DELETE FROM tblRotaInstance " +
                $"WHERE RotaInstanceID = {rotaInstanceID}";
            dbConnector.Connect();
            dbConnector.DoSQL(sqlCommand);
            dbConnector.Close();
        }

        private void btnAddInstance_Click(object sender, EventArgs e)
        {
            //email takes a while the more people it needs to send to - discourages people from spam clicking
            this.Cursor = Cursors.WaitCursor;
            AddNewInstance();
            this.Cursor = Cursors.Default;
            (Application.OpenForms["frmViewManageRotaInstances"] as frmViewManageRotaInstances).RefreshFlp();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            UpdateInstance(EditModeInstanceID);
            this.Cursor = Cursors.Default;
            (Application.OpenForms["frmViewManageRotaInstances"] as frmViewManageRotaInstances).RefreshFlp();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteInstance(EditModeInstanceID);
            (Application.OpenForms["frmViewManageRotaInstances"] as frmViewManageRotaInstances).RefreshFlp();
            this.Close();
        }
    }
}
