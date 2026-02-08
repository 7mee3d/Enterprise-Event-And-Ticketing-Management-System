using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EETMS_Models
{
    public  class MUser
    {

        public enum EnModeUser
        {
            _kADD_NEW_USER = 1 ,
            _kUPDATE_INFORMATION_USER = 2 
        };


        public enum EnStatusLoginUser
        {
            _kSUCCESS_LOGIN =  1,
            _kFAILD_LOGIN = 2 , 
            _kBLOCKED_USER = 3 , 
            _kUSER_NOT_FOUND = 4,

        }

        #region All Properties Information User 

        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string Username { get; set; }
        public string PasswordUser { get; set; }
        public string EmailUser { get; set; }
        public bool IsActiveAccount { get; set; }
        public int PermissionUser { get; set; }
        public int NumberAttempts { get; set; }
        public EnModeUser enMode { get; set;  } = EnModeUser._kADD_NEW_USER;

        #endregion

        #region Constractors User class 

        public MUser(int userID, string userFullName, string username, string passwordUser, string emailUser, bool isActiveAccount, short permissionUser, short numberAttempts)
        {
            UserID = userID;
            UserFullName = userFullName;
            Username = username;
            PasswordUser = passwordUser;
            EmailUser = emailUser;
            IsActiveAccount = isActiveAccount;
            PermissionUser = permissionUser;
            NumberAttempts = numberAttempts;
            this.enMode = EnModeUser._kUPDATE_INFORMATION_USER;
        }

        public MUser()
        {
            this.UserID = default(int);
            this.UserFullName = default(string);
            this.Username = default(string);
            this.PasswordUser = default(string);
            this.EmailUser = default(string);
            this.IsActiveAccount = default(bool);
            this.PermissionUser = default(short);
            this.NumberAttempts = default(short);
             this.enMode = EnModeUser._kADD_NEW_USER;
        }


        #endregion 


    }
}
