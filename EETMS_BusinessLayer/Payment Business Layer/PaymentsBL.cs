using EETMS_BusinessLayer.EETMS_Constants;
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
            => PaymentsDAL.InsertNewPayment(mPayment) > clsEETMS_Constants.kZERO;

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

            if (PaidAmount == TotalAmount && (PaidAmount != clsEETMS_Constants.kZERO && TotalAmount != clsEETMS_Constants.kZERO))
                return EnPaymentStatus._kPAID;
            else if (TotalAmount > PaidAmount && PaidAmount > clsEETMS_Constants.kZERO)
                return EnPaymentStatus._kPARTIALLY_PAID;
            else if (PaidAmount == clsEETMS_Constants.kZERO && TotalAmount > clsEETMS_Constants.kZERO)
                return EnPaymentStatus._kUNPAID;

            return EnPaymentStatus._kUNPAID;
        }

    }
}
