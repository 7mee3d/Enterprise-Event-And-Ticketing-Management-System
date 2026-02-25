using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_Models;
using System.Collections.Generic;
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
            => TicketsDAL.InsertNewTicketToTheEventBy(mTicketType) > clsEETMS_Constants.kZERO;

        private static bool _UpdateInformationTicketType(MTicketType mTicketType)
            => TicketsDAL.UpdateInformationTicketToTheEventBy(mTicketType) > clsEETMS_Constants.kZERO;

        public static MTicketType FindTheTicketTypeBy(int EventID, int TicketTypeID)
            => TicketsDAL.FindTheTicketTypeBy(EventID, TicketTypeID);

        public static Dictionary<int, string> GetTheAllTicketTypeBy(int IDEvent)
            => TicketsDAL.GetTheAllTicketTypeBy(IDEvent);

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
