using EETMS_DataAccessLayer;
using EETMS_DTOs;

namespace EETMS_BusinessLayer
{
    public class ReservationBL
    {

        private static bool _AddNewReservation(ReservationsDTO reservationsDTO)
            => ReservationCommandsDAL.InsertTheNewReservation(reservationsDTO) > 0;

        public static bool SaveTheInformationReservationMode(ReservationsDTO reservationsDTO)
        {

            switch (reservationsDTO.EnModeR)
            {
                case ReservationsDTO.EnModeReservation._kADD_NEW_RESERVATION:
                    return _AddNewReservation(reservationsDTO);
                default:
                    return false;
            }
        }


    }
}
