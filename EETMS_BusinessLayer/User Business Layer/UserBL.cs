using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_Models;
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

        public static bool AddNewUser(MUser InformationNewUser)
            => UsersDAL.InsertNewUser(InformationNewUser) > clsEETMS_Constants.kZERO;

        public static bool UpdateInformationUser(MUser InformationNewUser)
            => UsersDAL.UpdateInformationUser(InformationNewUser.UserID, InformationNewUser) > clsEETMS_Constants.kZERO;

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

        public static MUser.EnStatusLoginUser PassLoginTheUser(string UsernameOrEmail, string Password)
        {

            MUser InfoUser = UsersDAL.FindTheUserByUserNameOrEmail(UsernameOrEmail);

            if (InfoUser == null)
                return MUser.EnStatusLoginUser._kUSER_NOT_FOUND;

            if (InfoUser.NumberAttempts <= clsEETMS_Constants.kZERO)
                return MUser.EnStatusLoginUser._kBLOCKED_USER;

            bool isValidAccountUser = (IsUserExsitsByEmail(UsernameOrEmail, Password) || IsUserExsitsByUsername(UsernameOrEmail, Password));

            if (isValidAccountUser)
            {

                InfoUser.NumberAttempts = clsEETMS_Constants.kMAX_NUMBER_ATTEMPT_LOGIN_EETMS;
                UpdateInformationUser(InfoUser);
                return MUser.EnStatusLoginUser._kSUCCESS_LOGIN;

            }
            else
            {
                if (InfoUser.NumberAttempts > clsEETMS_Constants.kZERO)
                    InfoUser.NumberAttempts -= clsEETMS_Constants.kONE;

                UpdateInformationUser(InfoUser);
                return (InfoUser.NumberAttempts > clsEETMS_Constants.kZERO) ? MUser.EnStatusLoginUser._kFAILD_LOGIN : MUser.EnStatusLoginUser._kBLOCKED_USER;

            }

        }

        public static MUser FindUser(string UsernameOrEmail)
        {
            return UsersDAL.FindTheUserByUserNameOrEmail(UsernameOrEmail);
        }

        public static MUser FindUserBy(int IDUser)
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



    }
}
