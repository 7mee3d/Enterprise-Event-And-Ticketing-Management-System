using EETMS_DataAccessLayer;
using EETMS_Models;

namespace EETMS_BusinessLayer
{
    public class UserBL
    {


        public static bool IsUserExsitsByEmail(string Email , string Password ) =>  UsersDAL.IsExsitsTheUserByEmail(Email, Password);

        public static bool IsUserExsitsByUsername(string Username, string Password) => UsersDAL.IsExsitsTheUserByUsername(Username, Password);

       public static bool AddNewUser (MUser InformationNewUser ) => UsersDAL.InsertNewUser(InformationNewUser) > 0 ;

        public static bool UpdateInformationUser(MUser InformationNewUser) => UsersDAL.UpdateInformationUser(InformationNewUser) > 0;

        public static bool SaveInformationUserMode (MUser InformationUser)
        {


            switch (InformationUser.enMode)
            {
                case MUser.EnModeUser._kADD_NEW_USER:
                    return (AddNewUser(InformationUser)) ? true : false;

                case MUser.EnModeUser._kUPDATE_INFORMATION_USER:
                    return UpdateInformationUser(InformationUser);
            }

            return false;

        }


    }
}
