using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class EmployeeMediator
    {
        public Employee getEmployee(int employeeID)
        {
            EmployeeRepository rep = new EmployeeRepository();
            return rep.getEmployee(employeeID);
        }

        public Employee getEmployee(string name, string password)
        {
            EmployeeRepository rep = new EmployeeRepository();
            return rep.getEmployee(name, password);
        }

        public Employee addEmployee(Employee newEmployee)
        {
            EmployeeRepository rep = new EmployeeRepository();
            return rep.addEmployee(newEmployee);
        }

        public dynamic getAllEmployee()
        {
            EmployeeRepository rep = new EmployeeRepository();
            return rep.getAllEmployee();
        }

        public int getLastID()
        {
            EmployeeRepository rep = new EmployeeRepository();
            return rep.getLastID();
        }

    }
}
