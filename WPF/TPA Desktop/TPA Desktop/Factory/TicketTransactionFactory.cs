using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class TicketTransactionFactory
    {
        public TicketTransaction createNewTicketTransaction(int ticketID)
        {
            TicketTransactionMediator mediator = new TicketTransactionMediator();

            TicketTransaction transaction = new TicketTransaction();
            transaction.transactionID = mediator.getLastID() + 1;
            transaction.ticketID = ticketID;
            transaction.purchaseDate = DateTime.Now;
            transaction.employeeID = Session.getSession().employee.employeeID;

            return transaction;

        }
    }
}
