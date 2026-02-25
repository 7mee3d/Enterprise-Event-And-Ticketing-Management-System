using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_Models;


namespace EETMS_BusinessLayer
{
    public class ReservationBL
    {


        private static bool _AddNewReservation(MReservations mReservations)
            => ReservationDAL.InsertTheNewReservation(mReservations) > clsEETMS_Constants.kZERO;

        public static bool SaveTheReservatio(MReservations mReservations)
        {

            switch (mReservations.EnModeR)
            {
                case MReservations.EnModeReservation._kADD_NEW_RESERVATION:
                    return (_AddNewReservation(mReservations));

                default: return false;
            }


        }

        public static bool UpdateTheInformationTicketTypesBy(int EventID, string TicketTypeName, int NewAvailableTicket)
            => ReservationDAL.UpdateTheQuntityTicketsBy(EventID, TicketTypeName, NewAvailableTicket) > clsEETMS_Constants.kZERO;


    }
}
