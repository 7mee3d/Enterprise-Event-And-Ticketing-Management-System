using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_Models;
using System.Data;
using System.Data.SqlClient;

namespace EETMS_BusinessLayer
{
    public class CustomerBL
    {

        public static DataTable GetAllInformationCustomer()
        {
            return CustomerDAL.GetAllCustomersInformation();
        }

        public static DataTable GetAllInformationCustomerWithPhoneAndEmail()
        {
            return CustomerDAL.GetAllCustomersInformationJoinesPhoneAndEmail();
        }

        public static CustomerDTO FindCustomer(int CustomerID)
        {
            return CustomerDAL.FindTheCustomerReturingAllInformation(CustomerID);
        }

        private static bool _AddNewCustomer(CustomerDTO NewCustomer)
        {
            return CustomerDAL.InsertNewCustomer(NewCustomer) > clsEETMS_Constants.kZERO;
        }

        private static bool _UpdateInformationCustomer(int IDCustomer, CustomerDTO NewInfromationCustomer)
        {
            return CustomerDAL.UpdateInformationCustomer(IDCustomer, NewInfromationCustomer) > clsEETMS_Constants.kZERO;
        }

        public static bool DeleteTheCustomer(int IDCustomer)
        {
            return CustomerDAL.DeleteTheCustomer(IDCustomer);

        }

        public static bool Save(CustomerDTO NewCustomer)
        {

            switch (NewCustomer.Emode)
            {


                case CustomerDTO.EnMode._kADD_NEW_CUSTOMER:
                    if (_AddNewCustomer(NewCustomer: NewCustomer))
                        return true;
                    else return false;


                case CustomerDTO.EnMode._kUPDATE_INFORMATION_CUSTOMER:
                    return _UpdateInformationCustomer(

                                                      IDCustomer: NewCustomer.CusotmerID,
                                                      NewInfromationCustomer: NewCustomer

                                                      );

            }

            return false;
        }

        public static DataTable AllInformationCustomerAfterSearch(string StrToBeSearch)
        {
            return CustomerDAL.SearchTheCustomerFirstNameOrMidOrLast_OR_NationalID(StrToBeSearch);
        }

        public static bool _IsTheNameCustomerExsistsBy(CustomerDTO mCustomerName)
            => CustomerDAL.FindTheCustomerBy(mCustomerName);
    }
}
