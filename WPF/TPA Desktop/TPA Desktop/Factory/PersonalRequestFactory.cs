using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class PersonalRequestFactory
    {
        public PersonalRequest createLeaveRequest(string title, string description)
        {
            PersonalRequestMediator mediator = new PersonalRequestMediator();

            PersonalRequest request = new PersonalRequest();
            request.requestID = mediator.getLastID() + 1;
            request.departmentID = Session.session.employee.departmentID;
            request.employeeID = Session.session.employee.employeeID;
            request.title = title;
            request.description = description;
            request.type = "Leave";
            request.response = "-";
            request.status = "Pending";

            return request;
        }

        public PersonalRequest createResignRequest(string title, string description)
        {
            PersonalRequestMediator mediator = new PersonalRequestMediator();

            PersonalRequest request = new PersonalRequest();
            request.requestID = mediator.getLastID() + 1;
            request.departmentID = Session.session.employee.departmentID;
            request.employeeID = Session.session.employee.employeeID;
            request.title = title;
            request.description = description;
            request.type = "Resign";
            request.response = "-";
            request.status = "Pending";

            return request;
        }
    }
}
