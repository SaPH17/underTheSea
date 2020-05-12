using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class CustomerRepository
    {
        public Customer getCustomer(string idCardNumber)
        {
            Connection con = Connection.getConnection();

            Customer customer = (from c in con.db.Customer
                                 where c.idCardNumber == idCardNumber select c).FirstOrDefault();

            return customer;
        }

        public Customer addCustomer(Customer customer)
        {
            Connection con = Connection.getConnection();

            con.db.Customer.Add(customer);
            con.db.SaveChanges();

            return customer;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            Customer customer = (from c in con.db.Customer orderby c.customerID descending select c).FirstOrDefault();

            if(customer == null)
            {
                return 0;
            }
            return customer.customerID;
        }
    }
}
