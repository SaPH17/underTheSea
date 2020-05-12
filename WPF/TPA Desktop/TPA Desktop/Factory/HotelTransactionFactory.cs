using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class HotelTransactionFactory
    {
        public HotelTransaction createNewHotelTransaction(int customerID, int roomID, DateTime? checkInDate, DateTime? checkOutDate)
        {
            HotelTransactionMediator mediator = new HotelTransactionMediator();
            HotelTransaction transaction = new HotelTransaction();
            transaction.transactionID = mediator.getLastID() + 1;
            transaction.customerID = customerID;
            transaction.employeeID = Session.getSession().employee.employeeID;
            transaction.roomID = roomID;
            transaction.checkInDate = checkInDate;
            transaction.checkOutDate = checkOutDate;

            return transaction;
        }
    }
}
