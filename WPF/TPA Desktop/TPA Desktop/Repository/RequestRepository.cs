using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class RequestRepository
    {
        public Request addRequest(Request request)
        {
            Connection con = Connection.getConnection();
            con.db.Request.Add(request);
            con.db.SaveChanges();

            return request;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            Request request =  (from r in con.db.Request orderby r.requestID descending select r).FirstOrDefault();
            if(request == null)
            {
                return 0;
            }
            return request.requestID;
        }

        public dynamic getAllRequest(string type)
        {
            Connection con = Connection.getConnection();

            var result = from r in con.db.Request
                         join d in con.db.Department on r.departmentID equals d.departmentID
                         where r.type == type && r.status == "Pending"
                         select new
                         {
                             r.requestID,
                             d.departmentName,
                             r.title,
                             r.description,
                             r.type,
                             r.status,
                             r.response
                         };
            return result.ToList();
        }

        public dynamic getAllRequest(int departmentID)
        {
            Connection con = Connection.getConnection();

            var result = from r in con.db.Request
                         join d in con.db.Department on r.departmentID equals d.departmentID
                         where r.departmentID == departmentID
                         select new
                         {
                             r.requestID,
                             d.departmentName,
                             r.title,
                             r.description,
                             r.type,
                             r.status,
                             r.response
                         };
            return result.ToList();
        }

        public Request getRequest(int requestID)
        {
            Connection con = Connection.getConnection();

            return con.db.Request.Find(requestID);
        }

        public Request updateRequest(int requestID, Request request)
        {
            Connection con = Connection.getConnection();

            Request newRequest = con.db.Request.Find(requestID);
            newRequest = request;
            con.db.SaveChanges();

            return newRequest;
        }
    }
}
