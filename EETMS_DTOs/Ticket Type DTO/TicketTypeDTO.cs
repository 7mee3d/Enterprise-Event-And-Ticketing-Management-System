
namespace EETMS_DTOs
{
    public class TicketTypeDTO
    {

        public enum EnModeTicketType
        {

            _kADD_NEW_TICKETTYPE = 1,
            _kUPDATE_INFOMRATION_TICKETTYPE = 2

        };

        public int TicketTypeID { get; set; }
        public string TicketTypeName { get; set; }
        public int Quantity { get; set; }
        public int Available { get; set; }
        public decimal Price { get; set; }
        public int EventID { get; set; }
        public EnModeTicketType EnMode { get; set; }

        public TicketTypeDTO(int ticketTypeID, string ticketTypeName, int quantity, int available, decimal price, int eventID)
        {
            this.TicketTypeID = ticketTypeID;
            this.TicketTypeName = ticketTypeName;
            this.Quantity = quantity;
            this.Available = available;
            this.Price = price;
            this.EventID = eventID;
            this.EnMode = EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE;
        }

        public TicketTypeDTO()
        {
            this.TicketTypeID = default(int);
            this.TicketTypeName = default(string);
            this.Quantity = default(int);
            this.Available = default(int);
            this.Price = default(decimal);
            this.EventID = default(int);
            this.EnMode = EnModeTicketType._kADD_NEW_TICKETTYPE;
        }


    }
}
