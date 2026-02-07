using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EETMS_Models
{
    public  class MUser
    {

        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string Username { get; set; }
        public string PasswordUser { get; set; }
        public string EmailUser { get; set; }
        public bool IsActiveAccount { get; set; }
        public short PermissionUser { get; set; }
        public short NumberAttempts { get; set; }

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
        }
    }
}
