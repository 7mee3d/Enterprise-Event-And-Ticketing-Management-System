using EETMS_DataAccessLayer;
using System.Data;


namespace EETMS_BusinessLayer
{
    public class TicketBL
    {

        public static DataTable GetInformationEvent_Name_And_ID()
            => TicketsDAL.GetInformation_ID_Name_Events();

        public static DataTable GetInformationTicketForEvent(int EventID)
            => TicketsDAL.GetInformationTicketForEventBy(EventID);
    }
}
