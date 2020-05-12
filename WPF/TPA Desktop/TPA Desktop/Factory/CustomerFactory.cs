using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class CustomerFactory
    {
        public Customer createNewCustomer(string idCardNumber, string name, DateTime? dateOfBirth, string address, string gender)
        {
            CustomerMediator mediator = new CustomerMediator();
            Customer customer = new Customer();
            customer.customerID = mediator.getLastID() + 1;
            customer.idCardNumber = idCardNumber;
            customer.name = name;
            customer.dateOfBirth = dateOfBirth;
            customer.address = address;
            customer.gender = gender;
            customer.status = "Active";

            return customer;
        }
    }
}
