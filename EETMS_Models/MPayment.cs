

using System;

namespace EETMS_Models
{
    public class MPayment
    {

        public int PaymentID { get; set; }
        public int BookingID { get; set; }
        public DateTime? BookingDateTime { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }

        public MPayment(int paymentID, int bookingID, DateTime? bookingDateTime, int customerID, decimal totalAmount, decimal paidAmount, string paymentMethod, string paymentStatus)
        {
            this.PaymentID = paymentID;
            this.BookingID = bookingID;
            this.BookingDateTime = bookingDateTime;
            this.CustomerID = customerID;
            this.TotalAmount = totalAmount;
            this.PaidAmount = paidAmount;
            this.PaymentMethod = paymentMethod;
            this.PaymentStatus = paymentStatus;
        }


        public MPayment()
        {
            this.PaymentID = default(int);
            this.BookingID = default(int);
            this.BookingDateTime = default(DateTime);
            this.CustomerID = default(int);
            this.TotalAmount = default(decimal);
            this.PaidAmount = default(decimal);
            this.PaymentMethod = default(string);
            this.PaymentStatus = default(string);
        }
    }
}
