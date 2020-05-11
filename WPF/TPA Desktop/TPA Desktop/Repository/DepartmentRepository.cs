using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class DepartmentRepository
    {
        public Department getDepartment(int departmentID)
        {
            Connection con = Connection.getConnection();
            return con.db.Department.Find(departmentID);
        }
    }
}
