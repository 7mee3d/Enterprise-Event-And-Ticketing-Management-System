

using System;

namespace EETMS_Models
{
    public class MReservations
    {

        public enum EnModeReservation
        {
            _kADD_NEW_RESERVATION = 1,
            _kUPDATE_INFORMATION_RESERVATION = 2
        };

        public int ReservationID { get; set; }
        public DateTime? BookingDateTime { get; set; }
        public int Quantity { get; set; }
        public int TicketTypeID { get; set; }
        public int CustomerID { get; set; }
        public EnModeReservation EnModeR { get; set; } = EnModeReservation._kADD_NEW_RESERVATION;

        public MReservations(int reservationID, DateTime? bookingDateTime, int quantity, int ticketTypeID, int customerID)
        {
            this.ReservationID = reservationID;
            this.BookingDateTime = bookingDateTime;
            this.Quantity = quantity;
            this.TicketTypeID = ticketTypeID;
            this.CustomerID = customerID;

            this.EnModeR = EnModeReservation._kUPDATE_INFORMATION_RESERVATION;
        }


        public MReservations()
        {
            this.ReservationID = default(int);
            this.BookingDateTime = default(DateTime);
            this.Quantity = default(int);
            this.TicketTypeID = default(int);
            this.CustomerID = default(int);
        }


    }
}
