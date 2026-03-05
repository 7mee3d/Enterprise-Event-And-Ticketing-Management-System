

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


        public enum EnStatusCapacityUsage
        {
            kLESS_THAN_50_PRESANTAGE = 1 , 
            kUSAGE_CAPACITY_BETWEEN_50_AND_90 = 2 ,
            kALMOST_FULL = 3 , 
            kSOLD_OUT = 4 
        }

        public string TypeMainFilterEvent { get; set; }
        public string TypeSubFilterEvent { get; set; }
        public EnStatusEvent NumberStatusEvent { get; set; }

    }
}
