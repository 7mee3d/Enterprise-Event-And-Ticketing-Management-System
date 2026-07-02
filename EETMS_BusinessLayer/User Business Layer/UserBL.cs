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
            => UsersQueriesDAL.IsExsitsTheUserByEmail(Email, Password);

        public static bool IsUserExsitsByUsername(string Username, string Password)
            => UsersQueriesDAL.IsExsitsTheUserByUsername(Username, Password);

        public static bool AddNewUser(UserDTO InformationNewUser)
            => UserCommandsDAL.InsertNewUser(InformationNewUser) > clsEETMS_Constants.kZERO;

        public static bool UpdateInformationUser(UserDTO InformationNewUser)
            => UserCommandsDAL.UpdateInformationUser(InformationNewUser.UserID, InformationNewUser) > clsEETMS_Constants.kZERO;

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

            UserDTO InfoUser = UsersQueriesDAL.FindTheUserByUserNameOrEmail(UsernameOrEmail);

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
            return UsersQueriesDAL.FindTheUserByUserNameOrEmail(UsernameOrEmail);
        }

        public static UserDTO FindUserBy(int IDUser)
            => UsersQueriesDAL.FindTheUserBy(IDUser);

        public static int GetTotalUsers()
            => UsersQueriesDAL.GetTheTotalUsers();

        public static int GetTheAvtiveAdmin()
            => UsersQueriesDAL.GetTheTotalActiveAdmin();

        public static int GetTheBlockedUser()
            => UsersQueriesDAL.GetTheTotalBlockedUsers();

        public static DataTable GetAllInformationUsers()
            => UsersQueriesDAL.GetAllInformationUsers();

        public static bool DeleteTheUserBy(int IDUser)
            => UserCommandsDAL.DeleteTheUserBy(IDUser) > clsEETMS_Constants.kZERO;

        public static bool UpdateInformationActiveAccountUserBy(int UserID, UserDTO mUser)
            => UserCommandsDAL.UpdateInformationUserActiveAccountInactiveBy(UserID, mUser) > 0;

        public static DataTable GetAllUsersAfterSearchBy(string SearchTheUserByNameOrUsername)
            => UsersQueriesDAL.GetAllAfterSearchUsersBy(SearchTheUserByNameOrUsername);

        public static DataTable GetAllStatusType()
            => UsersQueriesDAL.GetAllStatus();

        public static DataTable GetTheUsersAccordingSelectFilter(UserFilterDTO userFilterDTO)
        {

            switch (userFilterDTO.MainNameFilter)
            {
                case "Status":
                    if (userFilterDTO.SubFilter == "Active")
                        return UsersQueriesDAL.GetTheUserActiveAccount("Active");
                    else
                        return UsersQueriesDAL.GetTheUserActiveAccount("Inactive");

                case "Roles":
                    return UsersQueriesDAL.GetUserAccordingheRoleName(userFilterDTO.SubFilter);

                case "Last Login For Day":
                    return UsersQueriesDAL.GetUserAccordingrTheLastLoginForDay(Convert.ToInt32(userFilterDTO.SubFilter));

                default: return new DataTable();
            }

        }

        public static bool IsUserExistsBy(string Username)
            => UsersQueriesDAL.IsUserExistsBy(Username);

        public static bool IsEmailExists(string EmailAddress)
            => UsersQueriesDAL.IsEmailExists(EmailAddress);
    }
}
