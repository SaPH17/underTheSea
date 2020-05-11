using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class DepartmentMediator
    {
        public Department getDepartment(int departmentID)
        {
            return new DepartmentRepository().getDepartment(departmentID);
        }
    }
}
