using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class HotelTransactionMediator
    {
        public int getLastID()
        {
            HotelTransactionRepository repository = new HotelTransactionRepository();
            return repository.getLastID();
        }

        public HotelTransaction addHotelTransaction(HotelTransaction transaction)
        {
            HotelTransactionRepository repository = new HotelTransactionRepository();
            return repository.addHotelTransaction(transaction);
        }

        public dynamic getAllHotelTransaction()
        {
            HotelTransactionRepository repository = new HotelTransactionRepository();
            return repository.getAllHotelTransaction();
        }

        public int getHotelIncome()
        {
            HotelTransactionRepository repository = new HotelTransactionRepository();
            return repository.getHotelIncome();
        }
    }
}
