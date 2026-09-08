using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_DTOs;
using System.Data;
using static EETMS_DTOs.EventFilterDTO;


namespace EETMS_BusinessLayer
{
    public class EventBL
    {


        public static DataTable GetAllInformationEvents()
            => EventsQueriesDAL.GetAllInformationEvents();

        public static bool DeleteTheEvent(int IDEvent)
            => EventCommandsDAL.DeleteTheEventByID(IDEvent) > clsEETMS_Constants.kZERO;

        public static EventDTO FindTheEventBy(int IDEvent)
            => EventsQueriesDAL.FindTheEventByID(IDEvent);

        private static bool AddNewEvent(EventDTO NewInformationEvent)
            => EventCommandsDAL.InsertNewEvent(NewInformationEvent) > clsEETMS_Constants.kZERO;

        private static bool UpdateInformationEvent(int IDEvent, EventDTO NewInformationEvent)
            => EventCommandsDAL.UpdateInformationEvent(IDEvent, NewInformationEvent) > clsEETMS_Constants.kZERO;

        public static DataTable GetEventTicketCapacityInfoBy(int EventID)
            => EventsQueriesDAL.GetEventTicketCapacityInfoBy(EventID);

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
            => EventsQueriesDAL.GetRemainingCapacityEventfoBy(EventID);

        public static DataTable AllEventsAfterSearchBy(string EventName)
            => EventsQueriesDAL.GetTheAllEventsAccordingTheSearchBy(EventName);

        private static DataTable _GetAllEventsAccordingTheStatusBy(string TypeTheFilterStatusEvent)
        {

            switch (TypeTheFilterStatusEvent)
            {
                case "Fully Booked":
                    return EventsQueriesDAL.GetAllInfromationEventFilterBy((int)EnStatusEvent.kFULLY_BOOKED_EVENT);
                case "Live":
                    return EventsQueriesDAL.GetAllInfromationEventFilterBy((int)EnStatusEvent.kLIVE_EVENT);
                case "Draft":
                    return EventsQueriesDAL.GetAllInfromationEventFilterBy((int)EnStatusEvent.kDRAFT_EVENT);

                default:
                    return new DataTable();

            }
        }

        private static DataTable _GetAllEventAccordingUsageCapacityBy(string TypeFilterUsageCapacity)
        {

            switch (TypeFilterUsageCapacity)
            {

                case "Less Than 50%":
                    return EventsQueriesDAL.GetAllEventAccordingByCapacityUsageLessThan50Percent();
                case "50% - 90%":
                    return EventsQueriesDAL.GetAllEventAccordingByCapacityUsageBetween50And90Percent();
                case "Almost Full":
                    return EventsQueriesDAL.GetAllEventAccordingByCapacityUsageBetween90And99Percent();
                case "Sold Out":
                    return EventsQueriesDAL.GetAllEventAccordingByCapacityUsageSoldOut();

                default: return GetAllInformationEvents();

            }

        }

        private static DataTable _GetAllInformatioNEventCategoryAccordingBy(string CategoryName)
            => EventsQueriesDAL.GetAllEventAccordingCategoryBy(CategoryName);

        private static DataTable _GetAllInformationEventCustomOptions(EventFilterDTO eventFilterDTO)
            => EventsQueriesDAL.GetAllInformationEventAccrodingStatusAndCategoryAndCountryAndCapacityAndLocationBy(eventFilterDTO);

        public static DataTable GetAllInformationEventAccordingBy(EventFilterDTO eventFilterDTO)
        {

            switch (eventFilterDTO.TypeMainFilterEvent)
            {

                case "Event Progress":
                    return _GetAllEventsAccordingTheStatusBy(eventFilterDTO.TypeSubFilterEvent);
                case "Category":
                    return _GetAllInformatioNEventCategoryAccordingBy(eventFilterDTO.TypeSubFilterEvent);
                case "Capacity Usage":
                    return _GetAllEventAccordingUsageCapacityBy(eventFilterDTO.TypeSubFilterEvent);
                case "Location":
                    return GetAllEventsAccrodingCountryAndStreetBy(eventFilterDTO.CountryName, eventFilterDTO.Street);
                case "Custom":
                    return _GetAllInformationEventCustomOptions(eventFilterDTO);


                default: return GetAllInformationEvents();
            }
        }

        private static DataTable GetAllEventsAccrodingCountryAndStreetBy(string CountryName, string Street)
            => EventsQueriesDAL.GetAllInformationEventAccrodingCountryAndStreetBy(CountryName, Street);

        public static bool FindTheEventBy(string EventName)
            => EventsQueriesDAL.IsTheEventExsitsOrNotBy(EventName);

    }
}
