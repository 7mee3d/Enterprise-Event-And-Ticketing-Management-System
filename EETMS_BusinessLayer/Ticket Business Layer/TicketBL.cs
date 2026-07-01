using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_DTOs;
using System.Collections.Generic;
using System.Data;


namespace EETMS_BusinessLayer
{
    public class TicketBL
    {

        public static DataTable GetInformation_ID_Name_EventsInProgress()
            => TicketsQueriesDAL.GetInformation_ID_Name_EventsInProgress();

        public static DataTable GetInformationTicketForEvent(int EventID)
            => TicketsQueriesDAL.GetInformationTicketForEventBy(EventID);

        private static bool _AddNewTicketType(TicketTypeDTO mTicketType)
            => TicketCommandsDAL.InsertNewTicketToTheEventBy(mTicketType) > clsEETMS_Constants.kZERO;

        private static bool _UpdateInformationTicketType(TicketTypeDTO mTicketType)
            => TicketCommandsDAL.UpdateInformationTicketToTheEventBy(mTicketType) > clsEETMS_Constants.kZERO;

        public static TicketTypeDTO FindTheTicketTypeBy(int EventID, int TicketTypeID)
            => TicketsQueriesDAL.FindTheTicketTypeBy(EventID, TicketTypeID);

        public static Dictionary<int, string> GetTheAllTicketTypeBy(int IDEvent)
            => TicketsQueriesDAL.GetTheAllTicketTypeBy(IDEvent);

        public static bool SaveModeTicketType(TicketTypeDTO mTicketType)
        {


            switch (mTicketType.EnMode)
            {


                case TicketTypeDTO.EnModeTicketType._kADD_NEW_TICKETTYPE:
                    return _AddNewTicketType(mTicketType);

                case TicketTypeDTO.EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE:
                    return _UpdateInformationTicketType(mTicketType);

                default: return false;



            }
        }


    }
}
