using System.Data;
using System.Data.SqlClient;
using EETMS_DataAccessLayer;
using EETMS_Models;

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

        public static MCustomer FindCustomer(int CustomerID)
        {
            return CustomerDAL.FindTheCustomerReturingAllInformation(CustomerID);
        }

        private static bool _AddNewCustomer(MCustomer NewCustomer)
        {
            return CustomerDAL.InsertNewCustomer(NewCustomer) > 0;
        }
        private static bool _UpdateInformationCustomer(int IDCustomer , MCustomer NewInfromationCustomer)
        {
            return CustomerDAL.UpdateInformationCustomer(IDCustomer , NewInfromationCustomer) > 0;
        }

        public static bool DeleteTheCustomer(int IDCustomer)
        {
            return CustomerDAL.DeleteTheCustomer(IDCustomer);

        }

        public static bool Save(MCustomer NewCustomer)
        {

            switch (NewCustomer.Emode)
            {


                case MCustomer.EnMode._kADD_NEW_CUSTOMER:
                    if (_AddNewCustomer(NewCustomer : NewCustomer))
                        return true;
                    else return false;


                case MCustomer.EnMode._kUPDATE_INFORMATION_CUSTOMER:
                    return _UpdateInformationCustomer(

                                                      IDCustomer             : NewCustomer.CusotmerID ,
                                                      NewInfromationCustomer : NewCustomer

                                                      );

            }

            return false;
        }


        public static DataTable AllInformationCustomerAfterSearch (string StrToBeSearch)
        {
            return CustomerDAL.SearchTheCustomerFirstNameOrMidOrLast_OR_NationalID(StrToBeSearch);
        }


    }
}
