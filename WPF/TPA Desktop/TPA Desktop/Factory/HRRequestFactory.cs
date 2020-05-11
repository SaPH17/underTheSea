using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class HRRequestFactory
    {
        public HRRequest createRaiseRequest(string title, string description, int employeeID)
        {
            HRRequestMediator mediator = new HRRequestMediator();

            HRRequest request = new HRRequest();
            request.requestID = mediator.getLastID() + 1;
            request.employeeID = employeeID;
            request.title = title;
            request.description = description;
            request.type = "Raise";
            request.response = "-";
            request.status = "Pending";

            return request;
        }

        public HRRequest createFireRequest(string title, string description, int employeeID)
        {
            HRRequestMediator mediator = new HRRequestMediator();

            HRRequest request = new HRRequest();
            request.requestID = mediator.getLastID() + 1;
            request.employeeID = employeeID;
            request.title = title;
            request.description = description;
            request.type = "Fire";
            request.response = "-";
            request.status = "Pending";

            return request;
        }
    }
}
