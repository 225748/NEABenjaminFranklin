namespace NEABenjaminFranklin
{
    public class clsRoles
    {
        public string RoleName { get; set; }
        public int RoleNumber { get; set; }
        public bool CheckedInList { get; set; }
        public clsRoles(string roleName, int roleNumber, bool checkedInList = false)
        {
            RoleName = roleName;
            RoleNumber = roleNumber;
            CheckedInList = checkedInList;
        }
    }
}