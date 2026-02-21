
using System;

public class TicketEventArgs : EventArgs
{

    public int EventID;
    public int TicketTypeID;

    public TicketEventArgs(int eventId, int ticketTypeId)
    {
        this.EventID = eventId;
        this.TicketTypeID = ticketTypeId;
    }

}

