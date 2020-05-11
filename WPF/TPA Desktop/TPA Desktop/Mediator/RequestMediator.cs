using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class RequestMediator
    {
        public Request addRequest(Request request)
        {
            RequestRepository repository = new RequestRepository();
            return repository.addRequest(request);
        }

        public int getLastID()
        {
            RequestRepository repository = new RequestRepository();
            return repository.getLastID();
        }

        public dynamic getAllRequest(string type)
        {
            RequestRepository repository = new RequestRepository();
            return repository.getAllRequest(type);
        }
            
        public dynamic getAllRequest(int departmentID)
        {
            RequestRepository repository = new RequestRepository();
            return repository.getAllRequest(departmentID);
        }

        public Request getRequest(int requestID)
        {
            RequestRepository repository = new RequestRepository();
            return repository.getRequest(requestID);
        }

        public Request updateRequest(int requestID, Request request)
        {
            RequestRepository repository = new RequestRepository();
            return repository.updateRequest(requestID, request);
        }
    }
}
