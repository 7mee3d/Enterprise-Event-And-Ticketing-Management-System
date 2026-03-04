using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_DTOs;


namespace EETMS_BusinessLayer
{
    public class ReservationBL
    {


        private static bool _AddNewReservation(ReservationsDTO mReservations)
            => ReservationCommandsDAL.InsertTheNewReservation(mReservations) > clsEETMS_Constants.kZERO;

        public static bool SaveTheReservatio(ReservationsDTO mReservations)
        {

            switch (mReservations.EnModeR)
            {
                case ReservationsDTO.EnModeReservation._kADD_NEW_RESERVATION:
                    return (_AddNewReservation(mReservations));

                default: return false;
            }


        }

        public static bool UpdateTheInformationTicketTypesBy(int EventID, string TicketTypeName, int NewAvailableTicket)
            => ReservationCommandsDAL.UpdateTheQuntityTicketsBy(EventID, TicketTypeName, NewAvailableTicket) > clsEETMS_Constants.kZERO;


    }
}
