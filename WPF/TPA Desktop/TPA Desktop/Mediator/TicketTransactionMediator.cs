using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class TicketTransactionMediator
    {
        public TicketTransaction addTicketTransaction(TicketTransaction transaction)
        {
            TicketTransactionRepository repository = new TicketTransactionRepository();
            return repository.addTicketTransaction(transaction);
        }

        public int getLastID()
        {
            TicketTransactionRepository repository = new TicketTransactionRepository();
            return repository.getLastID();
        }

        public List<TicketTransaction> getAllTicketTransaction()
        {
            TicketTransactionRepository repository = new TicketTransactionRepository();
            return repository.getAllTicketTransaction();
        }
    }
}
