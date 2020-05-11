using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class AttractionRideFactory
    {
        public AttractionOrRide createNewAttractionOrRide(string name, string type, string description)
        {
            AttractionRideMediator mediator = new AttractionRideMediator();

            AttractionOrRide attractionOrRide = new AttractionOrRide();
            attractionOrRide.attractionID = mediator.getLastID() + 1;
            attractionOrRide.name = name;
            attractionOrRide.type = type;
            attractionOrRide.description = description;
            attractionOrRide.status = "Waiting for constructing";

            return attractionOrRide;
        }
    }
}
