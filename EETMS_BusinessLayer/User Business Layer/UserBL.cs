using EETMS_DataAccessLayer;
using EETMS_Models;
using static EETMS_Models.MUser;

namespace EETMS_BusinessLayer
{
    public class UserBL
    {


        public static bool IsUserExsitsByEmail(string Email, string Password)
            => UsersDAL.IsExsitsTheUserByEmail(Email, Password);

        public static bool IsUserExsitsByUsername(string Username, string Password)
            => UsersDAL.IsExsitsTheUserByUsername(Username, Password);

        public static bool AddNewUser(MUser InformationNewUser)
            => UsersDAL.InsertNewUser(InformationNewUser) > 0;

        public static bool UpdateInformationUser(MUser InformationNewUser)
            => UsersDAL.UpdateInformationUser(InformationNewUser.UserID, InformationNewUser) > 0;

        public static bool SaveInformationUserMode(MUser InformationUser)
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

        public static EnStatusLoginUser PassLoginTheUser(string UsernameOrEmail, string Password)
        {

            MUser InfoUser = UsersDAL.FindTheUserByUserNameOrEmail(UsernameOrEmail);

            if (InfoUser == null)
                return EnStatusLoginUser._kUSER_NOT_FOUND;

            if (InfoUser.NumberAttempts <= 0)
                return EnStatusLoginUser._kBLOCKED_USER;

            bool isValidAccountUser = (IsUserExsitsByEmail(UsernameOrEmail, Password) || IsUserExsitsByUsername(UsernameOrEmail, Password));

            if (isValidAccountUser)
            {

                InfoUser.NumberAttempts = 3;
                UpdateInformationUser(InfoUser);
                return EnStatusLoginUser._kSUCCESS_LOGIN;

            }
            else
            {
                if (InfoUser.NumberAttempts > 0)
                    InfoUser.NumberAttempts -= 1;

                UpdateInformationUser(InfoUser);
                return (InfoUser.NumberAttempts > 0) ? EnStatusLoginUser._kFAILD_LOGIN : EnStatusLoginUser._kBLOCKED_USER;

            }

        }

        public static MUser FindUser(string UsernameOrEmail)
        {
            return UsersDAL.FindTheUserByUserNameOrEmail(UsernameOrEmail);
        }

        public static int GetTotalUsers()
            => UsersDAL.GetTheTotalUsers();

        public static int GetTheAvtiveAdmin()
            => UsersDAL.GetTheTotalActiveAdmin();

        public static int GetTheBlockedUser()
            => UsersDAL.GetTheTotalBlockedUsers();

    }
}
