using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class CustomerMediator
    {
        public Customer getCustomer(string idCardNumber)
        {
            CustomerRepository repository = new CustomerRepository();
            return repository.getCustomer(idCardNumber);
        }

        public Customer addCustomer(Customer customer)
        {
            CustomerRepository repository = new CustomerRepository();
            return repository.addCustomer(customer);
        }

        public int getLastID()
        {
            CustomerRepository repository = new CustomerRepository();
            return repository.getLastID();
        }
    }
}
