using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class RequestFactory
    {
        

        public Request createFinanceRequest(string title, string description)
        {
            RequestMediator mediator = new RequestMediator();

            Request request = new Request();
            request.requestID = mediator.getLastID() + 1;
            request.departmentID = Session.session.employee.departmentID;
            request.title = title;
            request.description = description;
            request.type = "Fund";
            request.response = "-";
            request.status = "Pending";

            return request;
        }

        public Request createPurchaseRequest(string title, string description)
        {
            RequestMediator mediator = new RequestMediator();

            Request request = new Request();
            request.requestID = mediator.getLastID() + 1;
            request.departmentID = Session.session.employee.departmentID;
            request.title = title;
            request.description = description;
            request.type = "Purchase";
            request.response = "-";
            request.status = "Pending";

            return request;
        }
    }
}
