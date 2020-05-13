using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class RestaurantTransactionMediator
    {
        public RestaurantTransaction addRestaurantTransaction(RestaurantTransaction transaction)
        {
            RestaurantTransactionRepository repository = new RestaurantTransactionRepository();
            return repository.addRestaurantTransaction(transaction);
        }

        public DetailRestaurantTransaction addDetailRestaurantTransaction(int transactionID, int orderID)
        {
            RestaurantTransactionRepository repository = new RestaurantTransactionRepository();
            return repository.addDetailRestaurantTransaction(transactionID, orderID);
        }

        public int getLastID()
        {
            RestaurantTransactionRepository repository = new RestaurantTransactionRepository();
            return repository.getLastID();
        }

        public List<RestaurantTransaction> getAllRestaurantTransaction()
        {
            RestaurantTransactionRepository repository = new RestaurantTransactionRepository();
            return repository.getAllRestaurantTransaction();
        }
    }
}
