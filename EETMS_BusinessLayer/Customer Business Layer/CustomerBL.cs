using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_Models;
using System.Data;

namespace EETMS_BusinessLayer
{
    public class CustomerBL
    {

        public static DataTable GetAllInformationCustomer()
        {
            return CustomerQueriesDAL.GetAllCustomersInformation();
        }

        public static DataTable GetAllInformationCustomerWithPhoneAndEmail()
        {
            return CustomerQueriesDAL.GetAllCustomersInformationJoinesPhoneAndEmail();
        }

        public static CustomerDTO FindCustomer(int CustomerID)
        {
            return CustomerQueriesDAL.FindTheCustomerReturingAllInformation(CustomerID);
        }

        private static bool _AddNewCustomer(CustomerDTO NewCustomer)
        {
            return CustomerCommandsDAL.InsertNewCustomer(NewCustomer) > clsEETMS_Constants.kZERO;
        }

        private static bool _UpdateInformationCustomer(int IDCustomer, CustomerDTO NewInfromationCustomer)
        {
            return CustomerCommandsDAL.UpdateInformationCustomer(IDCustomer, NewInfromationCustomer) > clsEETMS_Constants.kZERO;
        }

        public static bool DeleteTheCustomer(int IDCustomer)
        {
            return CustomerCommandsDAL.DeleteTheCustomer(IDCustomer);

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
            return CustomerQueriesDAL.SearchTheCustomerFirstNameOrMidOrLast_OR_NationalID(StrToBeSearch);
        }

        public static bool _IsTheNameCustomerExsistsBy(CustomerDTO mCustomerName)
            => CustomerQueriesDAL.FindTheCustomerBy(mCustomerName);

        public static bool _IsTheNationalIDCustomerExsistsBy(string NationalID)
           => CustomerQueriesDAL.IsCustomerNationalIDExsits(NationalID);
    }
}
