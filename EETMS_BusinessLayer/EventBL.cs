using EETMS_DataAccessLayer;
using System.Data;


namespace EETMS_BusinessLayer
{
    public class EventBL
    {


        public static DataTable GetAllInformationEvents()
        {
            return EventsDAL.GetAllInformationEventsWithOtherTable_Country_Category();
        }

        public static bool DeleteTheEvent(int IDEvent) => EventsDAL.DeleteTheEventByID(IDEvent) > 0 ;
        
    }
}
