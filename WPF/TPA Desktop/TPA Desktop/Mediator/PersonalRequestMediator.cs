using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class PersonalRequestMediator
    {
        public dynamic getAllPersonalRequest(string type)
        {
            PersonalRequestRepository repository = new PersonalRequestRepository();
            return repository.getAllPersonalRequest(type);
        }

        public dynamic getAllPersonalRequest(int employeeID)
        {
            PersonalRequestRepository repository = new PersonalRequestRepository();
            return repository.getAllPersonalRequest(employeeID);
        }

        public PersonalRequest getPersonalRequest(int requestID)
        {
            PersonalRequestRepository repository = new PersonalRequestRepository();
            return repository.getPersonalRequest(requestID);
        }

        public PersonalRequest updatePersonalRequest(int requestID, PersonalRequest request)
        {
            PersonalRequestRepository repository = new PersonalRequestRepository();
            return repository.updatePersonalRequest(requestID, request);
        }

        public PersonalRequest addPersonalRequest(PersonalRequest request)
        {
            PersonalRequestRepository repository = new PersonalRequestRepository();
            return repository.addPersonalRequest(request);
        }

        public int getLastID()
        {
            PersonalRequestRepository repository = new PersonalRequestRepository();
            return repository.getLastID();
        }
    }
}
