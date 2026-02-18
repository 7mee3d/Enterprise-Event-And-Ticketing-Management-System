
using EETMS_DataAccessLayer;
using EETMS_Models;
using System.Collections.Generic;

namespace EETMS_BusinessLayer
{
    public class ReservationPaymentBL
    {

        public static List<MReservationPayment> GetAllInformationReservationPayment()
            => ReservationPaymentDAL.GetAllInformationMReservationPayment();

        public static MReservationPayment GetAllInformationReservationPaymentByReservationID(int ReservationID)
      => ReservationPaymentDAL.GetAllInformationMReservationPaymentByReservationID(ReservationID);
    }
}
