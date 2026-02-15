using EETMS_DataAccessLayer;
using System.Data;

namespace EETMS_BusinessLayer
{
    public class PaymentsBL
    {

        public static decimal GetTheTotalRevenue()
            => PaymentsDAL.GetTotalRevenue();

        public static DataTable GetAllInformationPayments()
            => PaymentsDAL.GetAllInformationPayment();

        public static DataTable GetAllInformationPaymentBy(string BookingID)
            => PaymentsDAL.GetAllInformationPaymentBy(BookingID);

    }
}
