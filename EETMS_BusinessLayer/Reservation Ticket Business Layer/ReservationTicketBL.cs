using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_DTOs;
using EETMS_DTOs.Reservation_Tickets_DTO;


namespace EETMS_BusinessLayer
{
    public class ReservationTicketBL
    {


        private static bool _AddNewReservation(ReservationTicketsDTO mReservations)
            => ReservationTicketCommandsDAL.InsertTheNewReservation(mReservations) > clsEETMS_Constants.kZERO;

        public static bool SaveTheReservatio(ReservationTicketsDTO mReservations)
        {

            switch (mReservations.ModeReservation)
            {
                case ReservationTicketsDTO.EnModeReservation._kADD_NEW_RESERVATION:
                    return (_AddNewReservation(mReservations));

                default: return false;
            }


        }

        public static bool UpdateTheInformationTicketTypesBy(int EventID, string TicketTypeName, int NewAvailableTicket)
            => ReservationTicketCommandsDAL.UpdateTheQuntityTicketsBy(EventID, TicketTypeName, NewAvailableTicket) > clsEETMS_Constants.kZERO;


    }
}
