
using System;


namespace EETMS_Models
{
    public class MEvent
    {
        public enum EnModeEvent
        {
            _kADD_NEW_EVENT = 1 , 
            _kUPDATE_INFORMATION_EVENT = 2 
        }


        #region All Properties Event Information 
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime? DateTimeEvent { get; set; }
        public int DurationEvent { get; set; }
        public int MaxCapacity { get; set; }
        public string Street { get; set; }
        public int CountryID { get; set; }
        public int CategoryID { get; set; }
        public string Discripation { get; set; }
        public EnModeEvent EnMode { get; set; }


        public MEvent(int eventID, string eventName, DateTime? dateTimeEvent, int durationEvent, int maxCapacity, string street, int countryID, int categoryID, string discripation)
        {
            this.EventID = eventID;
            this.EventName = eventName;
            this.DateTimeEvent = dateTimeEvent;
            this.DurationEvent = durationEvent;
            this.MaxCapacity = maxCapacity;
            this.Street = street;
            this.CountryID = countryID;
            this.CategoryID = categoryID;
            this.Discripation = discripation;

            this.EnMode = EnModeEvent._kUPDATE_INFORMATION_EVENT; 

        }

        public MEvent()
        {
            this.EventID = default(int);
            this.EventName = default(string);
            this.DateTimeEvent = default(DateTime);
            this.DurationEvent = default(int);
            this.MaxCapacity = default(short);
            this.Street = default(string);
            this.CountryID = default(int);
            this.CategoryID = default(int);
            this.Discripation = default(string);

            this.EnMode = EnModeEvent._kADD_NEW_EVENT;
        }

        #endregion


    }
}