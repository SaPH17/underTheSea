using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Factory;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class RestaurantTransactionRepository
    {
        public RestaurantTransaction addRestaurantTransaction(RestaurantTransaction transaction)
        {
            Connection con = Connection.getConnection();

            con.db.RestaurantTransaction.Add(transaction);
            con.db.SaveChanges();

            return transaction;
        }

        public DetailRestaurantTransaction addDetailRestaurantTransaction(int transactionID, int orderID)
        {
            RestaurantTransactionFactory factory = new RestaurantTransactionFactory();
            Connection con = Connection.getConnection();
            DetailRestaurantTransaction transaction = null;

            List<OrderDetail> orderDetails = (from o in con.db.OrderDetail where o.orderID == orderID select o).ToList();
            foreach(OrderDetail o in orderDetails)
            {
                transaction = con.db.DetailRestaurantTransaction.Add(factory.createNewDetailRestaurantTransaction(transactionID, o.foodID, (int)o.quantity));
            }
            con.db.SaveChanges();

            return transaction;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            RestaurantTransaction transaction = (from t in con.db.RestaurantTransaction
                                                 orderby t.transactionID descending
                                                 select t).FirstOrDefault();

            if(transaction == null)
            {
                return 0;
            }
            return transaction.transactionID;
        }

        public List<RestaurantTransaction> getAllRestaurantTransaction()
        {
            Connection con = Connection.getConnection();
            return con.db.RestaurantTransaction.ToList();
        }

        public dynamic getAllDetailRestaurantTransaction(int transactionID)
        {
            Connection con = Connection.getConnection();

            var result = (from t in con.db.DetailRestaurantTransaction
                          join f in con.db.Food on t.foodID equals f.foodID
                          where t.transactionID == transactionID select new
                          {
                              t.transactionID,
                              f.name,
                              f.price,
                              t.quantity
                          });
            return result.ToList();
        }

        public int getRestaurantIncome()
        {
            Connection con = Connection.getConnection();
            int temp = 0;
            List<DetailRestaurantTransaction> transactions = con.db.DetailRestaurantTransaction.ToList();

            foreach (DetailRestaurantTransaction t in transactions)
            {
                temp += (int)(con.db.Food.Find(t.foodID).price * t.quantity);
            }

            return temp;
        }
    }
}
