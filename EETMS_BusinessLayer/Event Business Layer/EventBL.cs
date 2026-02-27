using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_DTOs;
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

        public static EventDTO FindTheEventBy(int IDEvent) => EventsDAL.FindTheEventByID(IDEvent);

        private static bool AddNewEvent(EventDTO NewInformationEvent) => EventsDAL.InsertNewEvent(NewInformationEvent) > clsEETMS_Constants.kZERO;

        private static bool UpdateInformationEvent(int IDEvent, EventDTO NewInformationEvent) => EventsDAL.UpdateInformationEvent(IDEvent, NewInformationEvent) > clsEETMS_Constants.kZERO;

        public static DataTable GetEventTicketCapacityInfoBy(int EventID)
            => EventsDAL.GetEventTicketCapacityInfoBy(EventID);

        public static bool SaveTheMode(EventDTO InformationEvent)
        {

            switch (InformationEvent.EnMode)
            {
                case EventDTO.EnModeEvent._kADD_NEW_EVENT:
                    return (AddNewEvent(InformationEvent));

                case EventDTO.EnModeEvent._kUPDATE_INFORMATION_EVENT:
                    return UpdateInformationEvent(InformationEvent.EventID, InformationEvent);
            }

            return false;
        }

        public static DataTable GetRemainingCapacityEventfoBy(int EventID)
            => EventsDAL.GetRemainingCapacityEventfoBy(EventID);


    }
}
