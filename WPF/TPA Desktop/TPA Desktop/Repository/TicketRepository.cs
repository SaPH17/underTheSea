using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class TicketRepository
    {
        public Ticket getTicket(int ticketID)
        {
            Connection con = Connection.getConnection();
            return con.db.Ticket.Find(ticketID);
        }

        public Ticket addTicket(Ticket ticket)
        {
            Connection con = Connection.getConnection();
            con.db.Ticket.Add(ticket);
            con.db.SaveChanges();

            return ticket;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();
            Ticket ticket = (from t in con.db.Ticket orderby t.ticketID descending select t).FirstOrDefault();
            if(ticket == null)
            {
                return 0;
            }
            return ticket.ticketID;
        }
    }
}
