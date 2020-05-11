using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class EmployeeFactory
    {
        public Employee createNewEmployee(string name, string password, int salary, DateTime? dateOfBirth, string department)
        {
            if(department == "Attraction Department")
            {
                return createNewAttractionDepartment(name, password, salary, dateOfBirth);
            }
            else if(department == "Maintenance Department")
            {
                return createNewMaintenanceDepartment(name, password, salary, dateOfBirth);
            }
            else if (department == "Ride and Attraction Creative Department")
            {
                return createNewCreativeDepartment(name, password, salary, dateOfBirth);
            }
            else if (department == "Construction Department")
            {
                return createNewConstructionDepartment(name, password, salary, dateOfBirth);
            }
            else if (department == "Dining Room Division")
            {
                return createNewDiningRoomDivision(name, password, salary, dateOfBirth);
            }
            else if (department == "Kitchen Division")
            {
                return createNewKitchenDivision(name, password, salary, dateOfBirth);
            }
            else if (department == "Purchasing Department")
            {
                return createNewPurchaseDepartment(name, password, salary, dateOfBirth);
            }
            else if (department == "Accounting and Finance Department")
            {
                return createNewAccountingFinanceDepartment(name, password, salary, dateOfBirth);
            }
            else if (department == "Front Office Division")
            {
                return createNewFrontOfficeDivision(name, password, salary, dateOfBirth);
            }
            else if (department == "House Keeping Division")
            {
                return createNewHouseKeepingDivision(name, password, salary, dateOfBirth);
            }
            else if (department == "Sales and Marketing Department")
            {
                return createNewSalesMarketingDepartment(name, password, salary, dateOfBirth);
            }
            else if (department == "Human Resource Department")
            {
                return createNewHumanResourceDepartment(name, password, salary, dateOfBirth);
            }
            else if (department == "Manager")
            {
                return createNewManager(name, password, salary, dateOfBirth);
            }
            else
            {
                return null;
            }
        }

        public Employee createNewAttractionDepartment(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee =  new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 1;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;            
        }

        public Employee createNewMaintenanceDepartment(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee = new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 2;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;
        }

        public Employee createNewCreativeDepartment(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee = new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 3;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;
        }

        public Employee createNewConstructionDepartment(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee = new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 4;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;
        }

        public Employee createNewDiningRoomDivision(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee = new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 5;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;
        }

        public Employee createNewKitchenDivision(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee = new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 6;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;
        }

        public Employee createNewPurchaseDepartment(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee = new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 7;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;
        }

        public Employee createNewAccountingFinanceDepartment(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee = new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 8;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;
        }

        public Employee createNewFrontOfficeDivision(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee = new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 9;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;
        }

        public Employee createNewHouseKeepingDivision(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee = new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 10;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;
        }

        public Employee createNewSalesMarketingDepartment(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee = new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 11;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;
        }

        public Employee createNewHumanResourceDepartment(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee = new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 12;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;
        }

        public Employee createNewManager(string name, string password, int salary, DateTime? dateOfBirth)
        {
            EmployeeMediator mediator = new EmployeeMediator();
            Employee newEmployee = new Employee(); ;
            newEmployee.employeeID = mediator.getLastID() + 1;
            newEmployee.departmentID = 13;
            newEmployee.name = name;
            newEmployee.password = password;
            newEmployee.salary = salary;
            newEmployee.dateOfBirth = dateOfBirth;
            newEmployee.status = "Active";
            return newEmployee;
        }
    }
}
