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
}
