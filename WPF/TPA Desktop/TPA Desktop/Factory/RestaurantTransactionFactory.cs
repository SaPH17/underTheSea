using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class RestaurantTransactionFactory
    {
        public RestaurantTransaction createNewRestaurantTransaction(int seatID)
        {
            RestaurantTransactionMediator mediator = new RestaurantTransactionMediator();

            RestaurantTransaction transaction = new RestaurantTransaction();
            transaction.transactionID = mediator.getLastID() + 1;
            transaction.employeeID = Session.getSession().employee.employeeID;
            transaction.seatID = seatID;
            transaction.purchaseDate = DateTime.Now;

            return transaction;
        }

        public DetailRestaurantTransaction createNewDetailRestaurantTransaction(int transactionID, int foodID, int quantity)
        {
            DetailRestaurantTransaction transaction = new DetailRestaurantTransaction();
            transaction.transactionID = transactionID;
            transaction.foodID = foodID;
            transaction.quantity = quantity;

            return transaction;
        }
    }
}
