using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class HRRequestRepository
    {
        public HRRequest addHRRequest(HRRequest request)
        {
            Connection con = Connection.getConnection();
            con.db.HRRequest.Add(request);
            con.db.SaveChanges();

            return request;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            HRRequest request = (from r in con.db.HRRequest orderby r.requestID descending select r).FirstOrDefault();
            if (request == null)
            {
                return 0;
            }
            return request.requestID;
        }

        public dynamic getAllHRRequest()
        {
            Connection con = Connection.getConnection();
            if(Session.getSession().employee.departmentID == 13)
            {
                var result = from r in con.db.HRRequest
                         join e in con.db.Employee on r.employeeID equals e.employeeID
                         where r.status == "Pending"
                         select new
                         {
                             r.requestID,
                             e.name,
                             r.title,
                             r.description,
                             r.type,
                             r.status
                         };
                return result.ToList();

            }
            else
            {
                var result = from r in con.db.HRRequest
                         join e in con.db.Employee on r.employeeID equals e.employeeID
                         select new
                         {
                             r.requestID,
                             e.name,
                             r.title,
                             r.description,
                             r.type,
                             r.status
                         };

                return result.ToList();

            }

        }

        public HRRequest getHRRequest(int requestID)
        {
            Connection con = Connection.getConnection();
            return con.db.HRRequest.Find(requestID);
        }

        public HRRequest updateHRRequest(int requestID, HRRequest request)
        {
            Connection con = Connection.getConnection();
            HRRequest newRequest = con.db.HRRequest.Find(requestID);
            newRequest = request;
            con.db.SaveChanges();

            return newRequest;
        }
    }
}
