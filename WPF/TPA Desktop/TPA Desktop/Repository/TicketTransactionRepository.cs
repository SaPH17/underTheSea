using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class TicketTransactionRepository
    {
        public TicketTransaction addTicketTransaction(TicketTransaction transaction)
        {
            Connection con = Connection.getConnection();
            con.db.TicketTransaction.Add(transaction);
            con.db.SaveChanges();

            return transaction;
        }

        public List<TicketTransaction> getAllTicketTransaction()
        {
            Connection con = Connection.getConnection();

            return con.db.TicketTransaction.ToList();
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();
            TicketTransaction transaction = (from t in con.db.TicketTransaction orderby t.transactionID descending select t).FirstOrDefault();
            if(transaction == null)
            {
                return 0;
            }
            return transaction.transactionID;
        }
    }
}
