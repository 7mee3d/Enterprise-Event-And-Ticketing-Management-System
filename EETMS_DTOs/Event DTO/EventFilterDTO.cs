

namespace EETMS_DTOs
{
    public class EventFilterDTO
    {

        public enum EnStatusEvent
        {
            kNONE_FILTER = 0,
            kFULLY_BOOKED_EVENT = 1,
            kLIVE_EVENT = 2,
            kDRAFT_EVENT = 3
        };


        public string TypeMainFilterEvent { get; set; }
        public string TypeSubFilterEvent { get; set; }
        public EnStatusEvent NumberStatusEvent { get; set; }

    }
}
