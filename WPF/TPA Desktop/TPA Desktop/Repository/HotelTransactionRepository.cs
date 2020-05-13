using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class HotelTransactionRepository
    {
        public int getLastID()
        {
            Connection con = Connection.getConnection();

            HotelTransaction transaction = (from t in con.db.HotelTransaction orderby t.transactionID descending select t).FirstOrDefault();
            if(transaction == null)
            {
                return 0;
            }
            return transaction.transactionID;
        }

        public HotelTransaction addHotelTransaction(HotelTransaction transaction)
        {
            Connection con = Connection.getConnection();
            con.db.HotelTransaction.Add(transaction);
            con.db.SaveChanges();

            return transaction;

        }

        public List<HotelTransaction> getAllHotelTransaction()
        {
            Connection con = Connection.getConnection();
            return con.db.HotelTransaction.ToList();
        }
    }
}
