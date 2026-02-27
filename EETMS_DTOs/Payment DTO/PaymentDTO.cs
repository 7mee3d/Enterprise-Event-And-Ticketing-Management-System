

using System;

namespace EETMS_DTOs
{
    public class PaymentDTO
    {

        public enum EnModePayment
        {

            _kADD_NEW_PAYMENT = 1,
            _kUPDATE_INFORMATION_PAYMENT = 2
        };

        public enum EnPaymentStatus
        {
            _kPAID = 1,
            _kPARTIALLY_PAID = 2,
            _kUNPAID = 3

        };


        public int PaymentID { get; set; }
        public int BookingID { get; set; }
        public DateTime? BookingDateTime { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public EnModePayment EnMode { get; set; }

        public PaymentDTO(int paymentID, int bookingID, DateTime? bookingDateTime, int customerID, decimal totalAmount, decimal paidAmount, string paymentMethod, string paymentStatus)
        {
            this.PaymentID = paymentID;
            this.BookingID = bookingID;
            this.BookingDateTime = bookingDateTime;
            this.CustomerID = customerID;
            this.TotalAmount = totalAmount;
            this.PaidAmount = paidAmount;
            this.PaymentMethod = paymentMethod;
            this.PaymentStatus = paymentStatus;

            EnMode = EnModePayment._kUPDATE_INFORMATION_PAYMENT;
        }


        public PaymentDTO()
        {
            this.PaymentID = default(int);
            this.BookingID = default(int);
            this.BookingDateTime = default(DateTime);
            this.CustomerID = default(int);
            this.TotalAmount = default(decimal);
            this.PaidAmount = default(decimal);
            this.PaymentMethod = default(string);
            this.PaymentStatus = default(string);

            EnMode = EnModePayment._kADD_NEW_PAYMENT;
        }
    }
}
