using EETMS_DataAccessLayer; 

namespace EETMS_BusinessLayer
{
    public class UserBL
    {


        public static bool IsUserExsitsByEmail(string Email , string Password )
        {
            return UsersDAL.IsExsitsTheUserByEmail(Email, Password);
        }

        public static bool IsUserExsitsByUsername(string Username, string Password)
        {
            return UsersDAL.IsExsitsTheUserByUsername(Username, Password);
        }
    }
}
