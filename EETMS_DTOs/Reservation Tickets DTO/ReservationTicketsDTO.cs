
namespace EETMS_DTOs.Reservation_Tickets_DTO
{
    public class ReservationTicketsDTO
    {

        public enum EnModeReservation
        {
            _kADD_NEW_RESERVATION = 1,
            _kUPDATE_INFORMATION_RESERVATION = 2
        };

        public int ReservationTicketID { set; get; }
        public decimal Price { set; get; }
        public decimal Quantity { set; get; }
        public int TicketTypeID { set; get; }
        public int ReservationID { set; get; }
        public double Tax { get; set; }
        public EnModeReservation ModeReservation { set; get; }

        public ReservationTicketsDTO()
        {
            ReservationTicketID = default;
            Price = default;
            Quantity = default;
            TicketTypeID = default;
            ReservationID = default;
            Tax = default;
            ModeReservation = EnModeReservation._kADD_NEW_RESERVATION;
        }
    }
}
