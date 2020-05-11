using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class AdvertisementFactory
    {
        public Advertisement createNewAdvertisement(string title, string desc)
        {
            AdvertisementMediator mediator = new AdvertisementMediator();

            Advertisement advertisement = new Advertisement();
            advertisement.advertisementID = mediator.getLastID() + 1;
            advertisement.title = title;
            advertisement.description = desc;

            return advertisement;
        }
    }
}
