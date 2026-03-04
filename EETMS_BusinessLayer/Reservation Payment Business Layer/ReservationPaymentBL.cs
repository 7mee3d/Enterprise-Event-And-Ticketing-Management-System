
using EETMS_DataAccessLayer;
using EETMS_DTOs;
using System.Collections.Generic;

namespace EETMS_BusinessLayer
{
    public class ReservationPaymentBL
    {

        public static List<ReservationPaymentDTO> GetAllInformationReservationPayment()
            => ReservationPaymentQueriesDAL.GetAllInformationMReservationPayment();

        public static ReservationPaymentDTO GetAllInformationReservationPaymentByReservationID(int ReservationID)
      => ReservationPaymentQueriesDAL.GetAllInformationMReservationPaymentByReservationID(ReservationID);
    }
}
