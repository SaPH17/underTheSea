using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class AdvertisementMediator
    {
        public Advertisement addAdvertisement(Advertisement advertisement)
        {
            AdvertisementRepository repository = new AdvertisementRepository();
            return repository.addAdvertisement(advertisement);
        }

        public int getLastID()
        {
            AdvertisementRepository repository = new AdvertisementRepository();
            return repository.getLastID();
        }

        public List<Advertisement> getAllAdvertisement()
        {
            AdvertisementRepository repository = new AdvertisementRepository();
            return repository.getAllAdvertisement();
        }

    }
}
