using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_Models;
using System.Data;


namespace EETMS_BusinessLayer
{
    public class EventBL
    {


        public static DataTable GetAllInformationEvents()
        {
            return EventsDAL.GetAllInformationEvents();
        }

        public static bool DeleteTheEvent(int IDEvent) => EventsDAL.DeleteTheEventByID(IDEvent) > clsEETMS_Constants.kZERO;

        public static MEvent FindTheEventBy(int IDEvent) => EventsDAL.FindTheEventByID(IDEvent);

        private static bool AddNewEvent(MEvent NewInformationEvent) => EventsDAL.InsertNewEvent(NewInformationEvent) > clsEETMS_Constants.kZERO;

        private static bool UpdateInformationEvent(int IDEvent, MEvent NewInformationEvent) => EventsDAL.UpdateInformationEvent(IDEvent, NewInformationEvent) > clsEETMS_Constants.kZERO;

        public static DataTable GetEventTicketCapacityInfoBy(int EventID)
            => EventsDAL.GetEventTicketCapacityInfoBy(EventID);

        public static bool SaveTheMode(MEvent InformationEvent)
        {

            switch (InformationEvent.EnMode)
            {
                case MEvent.EnModeEvent._kADD_NEW_EVENT:
                    return (AddNewEvent(InformationEvent));

                case MEvent.EnModeEvent._kUPDATE_INFORMATION_EVENT:
                    return UpdateInformationEvent(InformationEvent.EventID, InformationEvent);
            }

            return false;
        }


    }
}
