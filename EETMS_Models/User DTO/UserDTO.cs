using System;


namespace EETMS_DTOs
{
    public class UserDTO
    {
        /*
          public struct stRoleUser
           {
               int RoleID;
               string RoleName;
               int Permssions;

               public stRoleUser (int parameter = 0)
               {
                   RoleID = default;
                   RoleName = default;
                   Permssions = default; 
               }
           }
        */

        public enum EnModeUser
        {
            _kADD_NEW_USER = 1,
            _kUPDATE_INFORMATION_USER = 2
        };

        public enum EnStatusLoginUser
        {
            _kSUCCESS_LOGIN = 1,
            _kFAILD_LOGIN = 2,
            _kBLOCKED_USER = 3,
            _kUSER_NOT_FOUND = 4,

        }



        #region All Properties Information User 

        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string Username { get; set; }
        public string PasswordUser { get; set; }
        public string EmailUser { get; set; }
        public bool IsActiveAccount { get; set; } = true;
        public int RoleID { get; set; }
        public int NumberAttempts { get; set; }
        public EnModeUser enMode { get; set; } = EnModeUser._kADD_NEW_USER;
        public string RoleName { get; set; }
        public string ImagePath { get; set; }
        public DateTime LastLoginUser { get; set; } = DateTime.Now;


        #endregion

        #region Constractors User class 

        public UserDTO(int userID, string userFullName, string username, string passwordUser, string emailUser, bool isActiveAccount, int RoleID, short numberAttempts)
        {
            UserID = userID;
            UserFullName = userFullName;
            Username = username;
            PasswordUser = passwordUser;
            EmailUser = emailUser;
            IsActiveAccount = isActiveAccount;
            this.RoleID = RoleID;
            NumberAttempts = numberAttempts;
            this.enMode = EnModeUser._kUPDATE_INFORMATION_USER;
        }

        public UserDTO()
        {
            this.UserID = default(int);
            this.UserFullName = default(string);
            this.Username = default(string);
            this.PasswordUser = default(string);
            this.EmailUser = default(string);
            this.IsActiveAccount = default(bool);
            this.RoleID = default(short);
            this.NumberAttempts = default(short);
            this.ImagePath = default(string);
            this.enMode = EnModeUser._kADD_NEW_USER;
        }


        #endregion 


    }
}
