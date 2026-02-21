using EETMS_DataAccessLayer;
using EETMS_Models;
using System.Data;


namespace EETMS_BusinessLayer
{
    public class TicketBL
    {

        public static DataTable GetInformationEvent_Name_And_ID()
            => TicketsDAL.GetInformation_ID_Name_Events();

        public static DataTable GetInformationTicketForEvent(int EventID)
            => TicketsDAL.GetInformationTicketForEventBy(EventID);

        private static bool _AddNewTicketType(MTicketType mTicketType)
            => TicketsDAL.InsertNewTicketToTheEventBy(mTicketType) > 0;

        private static bool _UpdateInformationTicketType(MTicketType mTicketType)
       => TicketsDAL.UpdateInformationTicketToTheEventBy(mTicketType) > 0;

        public static MTicketType FindTheTicketTypeBy(int EventID, int TicketTypeID)
            => TicketsDAL.FindTheTicketTypeBy(EventID, TicketTypeID);

        public static bool SaveModeTicketType(MTicketType mTicketType)
        {


            switch (mTicketType.EnMode)
            {


                case MTicketType.EnModeTicketType._kADD_NEW_TICKETTYPE:
                    return _AddNewTicketType(mTicketType);

                case MTicketType.EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE:
                    return _UpdateInformationTicketType(mTicketType);

                default: return false;



            }
        }


    }
}
