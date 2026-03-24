

using System;

namespace EETMS_DTOs
{
    public class ReservationsDTO
    {

        public enum EnModeReservation
        {
            _kADD_NEW_RESERVATION = 1,
            _kUPDATE_INFORMATION_RESERVATION = 2
        };

        public int ReservationID { get; set; }
        public DateTime? BookingDateTime { get; set; }
        public int CustomerID { get; set; }
        public EnModeReservation EnModeR { get; set; } = EnModeReservation._kADD_NEW_RESERVATION;

        public ReservationsDTO(int reservationID, DateTime? bookingDateTime, int quantity, int ticketTypeID, int customerID)
        {
            this.ReservationID = reservationID;
            this.BookingDateTime = bookingDateTime;
            this.CustomerID = customerID;

            this.EnModeR = EnModeReservation._kUPDATE_INFORMATION_RESERVATION;
        }


        public ReservationsDTO()
        {
            this.ReservationID = default(int);
            this.BookingDateTime = default(DateTime);
            this.CustomerID = default(int);
        }


    }
}
