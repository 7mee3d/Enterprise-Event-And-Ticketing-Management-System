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

        #region All Properties Information User 

        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string Username { get; set; }
        public string PasswordUser { get; set; }
        public string EmailUser { get; set; }
        public bool IsActiveAccount { get; set; }
        public short PermissionUser { get; set; }
        public short NumberAttempts { get; set; }

        EnModeUser enMode = EnModeUser._kADD_NEW_USER;

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
