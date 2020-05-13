using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class TicketMediator
    {
        public Ticket getTicket(int ticketID)
        {
            TicketRepository repository = new TicketRepository();
            return repository.getTicket(ticketID);
        }

        public Ticket addTicket(Ticket ticket)
        {
            TicketRepository repository = new TicketRepository();
            return repository.addTicket(ticket);
        }

        public int getLastID()
        {
            TicketRepository repository = new TicketRepository();
            return repository.getLastID();
        }
    }
}
