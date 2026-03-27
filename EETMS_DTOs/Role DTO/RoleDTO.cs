

namespace EETMS_DTOs
{
    public class RoleDTO
    {

        public enum EnModeRole
        {
            kADD_NEW_ROLE = 1,
            kUPDATE_INFORMATION_ROLE = 2
        };

        public enum EnPermssionsType
        {
            kDASHBOARD = 1,
            kCATEGORY_MANAGMENT = 2,
            kEVENTS_MANAGMENT = 4,
            kCUSTOMER = 8,
            kRESERVATION = 16,
            kPAYMENT = 32,
            kREPORT = 64,
            kUSERS_MANAGMENT = 128,
            kROLES_MANAGMENT = 256
        }

        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string DescripationRole { get; set; }
        public bool isActiveRole { get; set; } = true;
        public int PermssionsRole { get; set; }
        public EnModeRole ModeRole { get; set; }

        public RoleDTO()
        {
            this.RoleID = default(int);
            this.RoleName = default(string);
            this.DescripationRole = default(string);
            this.PermssionsRole = default(int);

            this.ModeRole = EnModeRole.kADD_NEW_ROLE;

        }


    }
}
