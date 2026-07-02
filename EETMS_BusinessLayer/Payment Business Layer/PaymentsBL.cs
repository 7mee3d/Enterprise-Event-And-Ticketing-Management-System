using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using System.Data;
using EETMS_DTOs;
using static EETMS_DTOs.PaymentDTO;
using System.Collections.Generic;
using System;
namespace EETMS_BusinessLayer
{
    public class PaymentsBL
    {

        public static double GetTheTotalRevenue()
            => PaymentsQueriesDAL.GetTotalRevenue();

        public static DataTable GetAllInformationPayments()
            => PaymentsQueriesDAL.GetAllInformationPayment();

        public static DataTable GetAllInformationPaymentByNationalID(string NationalID)
          => PaymentsQueriesDAL._GetAllInformationPaymentNationalIDBy(NationalID);

        private static bool _AddNewPayment(PaymentDTO mPayment)
            => PaymentCommandsDAL.InsertNewPayment(mPayment) > clsEETMS_Constants.kZERO;

        public static bool SaveTheInformationPayment(PaymentDTO mPayment)
        {

            switch (mPayment.EnMode)
            {
                case EnModePayment._kADD_NEW_PAYMENT:
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

        public static List<string> GetAllPaymentStatus()
            => PaymentsQueriesDAL.GetAllPaymentStatus();

        public static List<string> GetAllPaymentMethods()
            => PaymentsQueriesDAL.GetAllPaymentMethods();

        private static DataTable _GetAllInformationPaymentAccordingBy(string NameStatusPaymentToBeFilter)
            => PaymentsQueriesDAL.GetAllInformationPaymentAccordingBy(NameStatusPaymentToBeFilter);

        private static DataTable _GetAllInformationPaymentMethodAccordingBy(string NamePaymentMethodFilter)
            => PaymentsQueriesDAL.GetAllInformationPaymentMethodsBy(NamePaymentMethodFilter);

        private static DataTable _GetAllInformationPaymentAccordingBy(DateTime DateFrom, DateTime DateTo)
        => PaymentsQueriesDAL.GetAllInformationPaymentFilterTwoDate(DateFrom, DateTo);

        public static DataTable GetAllInformationPaymentFilter(PaymentFilterDTO paymentFilterDTO)
        {

            switch (paymentFilterDTO.TypeMainFilter)
            {
                case "Payment Status":
                    return _GetAllInformationPaymentAccordingBy(paymentFilterDTO.TypeSubMainFilter);
                case "Payment Method":
                    return _GetAllInformationPaymentMethodAccordingBy(paymentFilterDTO.TypeSubMainFilter);
                case "Payment Date":
                    return _GetAllInformationPaymentAccordingBy(paymentFilterDTO.FromDatePayment ?? DateTime.Now, paymentFilterDTO.ToDatePayment ?? DateTime.Now);
                default:
                    return new DataTable();

            }
        }

    }
}
