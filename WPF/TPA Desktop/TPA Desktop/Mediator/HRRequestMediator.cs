using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class HRRequestMediator
    {
        public HRRequest addRequest(HRRequest request)
        {
            HRRequestRepository repository = new HRRequestRepository();
            return repository.addHRRequest(request);
        }

        public int getLastID()
        {
            HRRequestRepository repository = new HRRequestRepository();
            return repository.getLastID();
        }

        public dynamic getAllHRRequest()
        {
            HRRequestRepository repository = new HRRequestRepository();
            return repository.getAllHRRequest();
        }

        public HRRequest getHRRequest(int requestID)
        {
            HRRequestRepository repository = new HRRequestRepository();
            return repository.getHRRequest(requestID);
        }

        public HRRequest updateHRRequest(int requestID, HRRequest request)
        {
            HRRequestRepository repository = new HRRequestRepository();
            return repository.updateHRRequest(requestID, request);
        }
    }
}
