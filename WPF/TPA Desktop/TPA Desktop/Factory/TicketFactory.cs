using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class TicketFactory
    {
        public Ticket generateTicket()
        {
            TicketMediator mediator = new TicketMediator();

            Ticket ticket = new Ticket();
            ticket.ticketID = mediator.getLastID() + 1;
            ticket.dateCreated = DateTime.Now;

            return ticket;
        }

    }
}
