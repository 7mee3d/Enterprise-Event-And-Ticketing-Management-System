
namespace EETMS_Models
{
    public class MCustomer
    {

        public enum EnMode
        {

            _kADD_NEW_CUSTOMER = 1,
            _kUPDATE_INFORMATION_CUSTOMER = 2
        };


        public int CusotmerID { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string NationalID { get; set; }
        public string EmailCustomer { get; set;  }
        public string PhoneCustomer { get; set;  }
        public EnMode Emode { get; set; }


        public MCustomer()
        {
            this.CusotmerID = default(int);
            this.FirstName = default(string);
            this.MidName = default(string);
            this.LastName = default(string);
            this.NationalID = default(string);
            this.EmailCustomer = default(string);
            this.PhoneCustomer = default(string);

            Emode = EnMode._kADD_NEW_CUSTOMER;
        }

        public MCustomer(int cusotmerID, string firstName, string midName, string lastName, string nationalID, string emailCustomer, string phoneCustomer, EnMode emode)
        {

            this.CusotmerID = cusotmerID;
            this.FirstName = firstName;
            this.MidName = midName;
            this.LastName = lastName;
            this.NationalID = nationalID;
            this.EmailCustomer = emailCustomer;
            this.PhoneCustomer = phoneCustomer;

            this.Emode = EnMode._kUPDATE_INFORMATION_CUSTOMER;
        }
   
    
    }
}
