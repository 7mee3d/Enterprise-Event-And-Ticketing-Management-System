using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_DTOs;
using System;
using System.Data;

namespace EETMS_BusinessLayer
{
    public sealed class UserBL
    {


        public static bool IsUserExsitsByEmail(string Email, string Password)
            => UsersDAL.IsExsitsTheUserByEmail(Email, Password);

        public static bool IsUserExsitsByUsername(string Username, string Password)
            => UsersDAL.IsExsitsTheUserByUsername(Username, Password);

        public static bool AddNewUser(UserDTO InformationNewUser)
            => UsersDAL.InsertNewUser(InformationNewUser) > clsEETMS_Constants.kZERO;

        public static bool UpdateInformationUser(UserDTO InformationNewUser)
            => UsersDAL.UpdateInformationUser(InformationNewUser.UserID, InformationNewUser) > clsEETMS_Constants.kZERO;

        public static bool SaveInformationUserMode(UserDTO InformationUser, bool IsUpdateActiveAccountUser = false)
        {

            if (!IsUpdateActiveAccountUser)
                switch (InformationUser.enMode)
                {
                    case UserDTO.EnModeUser._kADD_NEW_USER:
                        return (AddNewUser(InformationUser)) ? true : false;

                    case UserDTO.EnModeUser._kUPDATE_INFORMATION_USER:
                        return UpdateInformationUser(InformationUser);
                }
            else
                return UpdateInformationActiveAccountUserBy(InformationUser.UserID, InformationUser);

            return false;


        }

        public static UserDTO.EnStatusLoginUser PassLoginTheUser(string UsernameOrEmail, string Password)
        {

            UserDTO InfoUser = UsersDAL.FindTheUserByUserNameOrEmail(UsernameOrEmail);

            if (InfoUser == null)
                return UserDTO.EnStatusLoginUser._kUSER_NOT_FOUND;

            if (!InfoUser.IsActiveAccount)
                return UserDTO.EnStatusLoginUser._kBLOCKED_USER;

            if (InfoUser.NumberAttempts <= clsEETMS_Constants.kZERO)
                return UserDTO.EnStatusLoginUser._kBLOCKED_USER;

            InfoUser.LastLoginUser = DateTime.Now;

            bool isValidAccountUser = (IsUserExsitsByEmail(UsernameOrEmail, Password) || IsUserExsitsByUsername(UsernameOrEmail, Password));

            if (isValidAccountUser)
            {

                InfoUser.NumberAttempts = clsEETMS_Constants.kMAX_NUMBER_ATTEMPT_LOGIN_EETMS;


                UpdateInformationUser(InfoUser);
                return UserDTO.EnStatusLoginUser._kSUCCESS_LOGIN;

            }
            else
            {
                if (InfoUser.NumberAttempts > clsEETMS_Constants.kZERO)
                    InfoUser.NumberAttempts -= clsEETMS_Constants.kONE;

                UpdateInformationUser(InfoUser);
                return (InfoUser.NumberAttempts > clsEETMS_Constants.kZERO) ? UserDTO.EnStatusLoginUser._kFAILD_LOGIN : UserDTO.EnStatusLoginUser._kBLOCKED_USER;

            }

        }

        public static UserDTO FindUser(string UsernameOrEmail)
        {
            return UsersDAL.FindTheUserByUserNameOrEmail(UsernameOrEmail);
        }

        public static UserDTO FindUserBy(int IDUser)
            => UsersDAL.FindTheUserBy(IDUser);

        public static int GetTotalUsers()
            => UsersDAL.GetTheTotalUsers();

        public static int GetTheAvtiveAdmin()
            => UsersDAL.GetTheTotalActiveAdmin();

        public static int GetTheBlockedUser()
            => UsersDAL.GetTheTotalBlockedUsers();

        public static DataTable GetAllInformationUsers()
            => UsersDAL.GetAllInformationUsers();

        public static bool DeleteTheUserBy(int IDUser)
            => UsersDAL.DeleteTheUserBy(IDUser) > clsEETMS_Constants.kZERO;

        public static bool UpdateInformationActiveAccountUserBy(int UserID, UserDTO mUser)
            => UsersDAL.UpdateInformationUserActiveAccountInactiveBy(UserID, mUser) > 0;

        public static DataTable GetAllUsersAfterSearchBy(string SearchTheUserByNameOrUsername)
            => UsersDAL.GetAllAfterSearchUsersBy(SearchTheUserByNameOrUsername);


    }
}
