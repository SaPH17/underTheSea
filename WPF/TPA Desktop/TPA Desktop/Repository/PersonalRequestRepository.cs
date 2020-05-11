using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class PersonalRequestRepository
    {
        public dynamic getAllPersonalRequest(string type)
        {
            Connection con = Connection.getConnection();
            
            var result = from r in con.db.PersonalRequest
                         join e in con.db.Employee on r.employeeID equals e.employeeID
                         join d in con.db.Department on r.departmentID equals d.departmentID
                         where r.type == type && r.status == "Pending"
                         select new
                         {
                             r.requestID,
                             e.name,
                             d.departmentName,
                             r.title,
                             r.description,
                             r.type,
                             r.status
                         };
            return result.ToList();
        }

        public dynamic getAllPersonalRequest(int employeeID)
        {
            Connection con = Connection.getConnection();

            var result = from r in con.db.PersonalRequest
                         join e in con.db.Employee on r.employeeID equals e.employeeID
                         join d in con.db.Department on r.departmentID equals d.departmentID
                         where r.employeeID == employeeID
                         select new
                         {
                             r.requestID,
                             e.name,
                             d.departmentName,
                             r.type,
                             r.title,
                             r.description,
                             r.status,
                             r.response
                         };
            return result.ToList();
        }

        public PersonalRequest getPersonalRequest(int requestID)
        {
            Connection con = Connection.getConnection();

            return con.db.PersonalRequest.Find(requestID);
        }

        public PersonalRequest updatePersonalRequest(int requestID, PersonalRequest request)
        {
            Connection con = Connection.getConnection();

            PersonalRequest newRequest = con.db.PersonalRequest.Find(requestID);
            newRequest = request;
            con.db.SaveChanges();

            return newRequest;
        }

        public PersonalRequest addPersonalRequest(PersonalRequest request)
        {
            Connection con = Connection.getConnection();

            con.db.PersonalRequest.Add(request);
            con.db.SaveChanges();

            return request;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            PersonalRequest request = (from r in con.db.PersonalRequest orderby r.requestID descending select r).FirstOrDefault();
            if (request == null)
            {
                return 0;
            }
            return request.requestID;
        }
    }
}
