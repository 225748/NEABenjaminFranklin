using System;

namespace NEABenjaminFranklin
{
    public class clsUser
    {//when a user logs in, assign their info to this class so their userID (and other bits if needed) can be used in sql statments
        public int userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dob { get; set; }
        public string email { get; set; }
        public bool hostRole { get; set; }

        //These bits are for various other uses of user
        public int chkListIndex { get; set; } //cntrlRoleWithListVUsers

        public int AssignedRotaRoleID { get; set; } //frmAddEditNewInstance
        public bool CheckedinListV { get; set; } //frmAddEditNewInstance


    }
}

