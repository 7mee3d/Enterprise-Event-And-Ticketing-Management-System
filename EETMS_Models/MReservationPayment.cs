

namespace EETMS_Models
{
    public class MReservationPayment
    {

        public int ReservationID { get; set; }
        public string FullName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Remaining { get; set; }
        public string DisplayComboBox => $"BK-{ReservationID} - {FullName}";

        public MReservationPayment(int reservationID, string fullName, decimal totalAmount, decimal paidAmount, decimal remaining)
        {
            this.ReservationID = reservationID;
            this.FullName = fullName;
            this.TotalAmount = totalAmount;
            this.PaidAmount = paidAmount;
            this.Remaining = remaining;
        }


        public MReservationPayment()
        {
            this.ReservationID = default(int);
            this.FullName = default(string);
            this.TotalAmount = default(decimal);
            this.PaidAmount = default(decimal);
            this.Remaining = default(decimal);
        }
    }
}
