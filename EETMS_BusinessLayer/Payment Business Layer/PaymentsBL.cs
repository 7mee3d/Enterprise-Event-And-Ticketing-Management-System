using EETMS_DataAccessLayer;
using EETMS_Models;
using System.Data;
using static EETMS_Models.MPayment;

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

        private static bool _AddNewPayment(MPayment mPayment)
            => PaymentsDAL.InsertNewPayment(mPayment) > 0;

        public static bool SaveTheInformationPayment(MPayment mPayment)
        {

            switch (mPayment.EnMode)
            {
                case MPayment.EnModePayment._kADD_NEW_PAYMENT:
                    return (_AddNewPayment(mPayment));

                default: return false;
            }
        }

        public static bool IsPaidAmountGratherThanOriginalAmount(decimal PaidAmount, decimal TotalAmount)
            => PaidAmount > TotalAmount;

        public static EnPaymentStatus GetTheStatusPayment(decimal PaidAmount, decimal TotalAmount)
        {

            if (PaidAmount == TotalAmount && (PaidAmount != 0 && TotalAmount != 0))
                return EnPaymentStatus._kPAID;
            else if (TotalAmount > PaidAmount && PaidAmount > 0)
                return EnPaymentStatus._kPARTIALLY_PAID;
            else if (PaidAmount == 0 && TotalAmount > 0)
                return EnPaymentStatus._kUNPAID;

            return EnPaymentStatus._kUNPAID;
        }

    }
}
