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

        public dynamic getAllHotelTransaction()
        {
            Connection con = Connection.getConnection();
            var result = (from t in con.db.HotelTransaction
                          join r in con.db.Room on t.roomID equals r.roomID
                          select new
                          {
                              t.transactionID,
                              t.employeeID,
                              t.customerID,
                              r.roomID,
                              r.price,
                              t.checkInDate,
                              t.checkOutDate
                          });


            return result.ToList();
        }

        public int getHotelIncome()
        {
            Connection con = Connection.getConnection();
            int temp = 0;
            List<HotelTransaction> hotelTransactions = con.db.HotelTransaction.ToList();

            foreach(HotelTransaction t in hotelTransactions)
            {
                temp += (int) con.db.Room.Find(t.roomID).price;
            }

            return temp;
        }
    }
}
