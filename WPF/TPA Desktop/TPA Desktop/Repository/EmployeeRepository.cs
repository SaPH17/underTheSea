using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class EmployeeRepository
    {
        public Employee getEmployee(int employeeID)
        {
            Connection con = Connection.getConnection();
            Employee employee = con.db.Employee.Find(employeeID);
            return employee;
        }

        public Employee getEmployee(string name, string password)
        {
            Connection con = Connection.getConnection();
            Employee employee = (from e in con.db.Employee where e.name == name 
                                    && e.password == password && e.status != "Inactive" select e).FirstOrDefault();
            return employee;
        }

        public dynamic getAllEmployee()
        {
            Connection con = Connection.getConnection();

            var result =  from e in con.db.Employee
                   join d in con.db.Department on e.departmentID equals d.departmentID
                   where e.status != "Inactive"
                   select new
                   {
                       e.employeeID,
                       e.name,
                       d.departmentName,
                       e.salary,
                       e.dateOfBirth
                   };
            return result.ToList();
        }

        public Employee addEmployee(Employee newEmployee)
        {
            Connection con = Connection.getConnection();
            con.db.Employee.Add(newEmployee);
            con.db.SaveChanges();
            return newEmployee;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            Employee employee = (from e in con.db.Employee orderby e.employeeID descending select e).FirstOrDefault();

            if(employee == null)
            {
                return 0;
            }
            return employee.employeeID;
        }

        public Employee updateEmployee(int employeeID, Employee employee)
        {
            Connection con = Connection.getConnection();

            Employee e = con.db.Employee.Find(employeeID);
            e = employee;
            con.db.SaveChanges();
            return e;
        }

    }
}
