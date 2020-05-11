using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class AttractionRideMediator
    {
        public List<AttractionOrRide> getAllAttractionRide()
        {
            AttractionRideRepository repository = new AttractionRideRepository();
            return repository.getAllAttractionRide();
        }

        public int getLastID()
        {
            AttractionRideRepository repository = new AttractionRideRepository();
            return repository.getLastID();
        }

        public AttractionOrRide addAttractionOrRide(AttractionOrRide aor)
        {
            AttractionRideRepository repository = new AttractionRideRepository();
            return repository.addAttractionOrRide(aor);
        }

        public AttractionOrRide updateAttractionOrRide(int attractionID, AttractionOrRide aor)
        {
            AttractionRideRepository repository = new AttractionRideRepository();
            return repository.updateAttractionOrRide(attractionID, aor);
        }

        public AttractionOrRide getAttractionOrRide(int attractionID)
        {
            AttractionRideRepository repository = new AttractionRideRepository();
            return repository.getAttractionOrRide(attractionID);
        }
    }
}
