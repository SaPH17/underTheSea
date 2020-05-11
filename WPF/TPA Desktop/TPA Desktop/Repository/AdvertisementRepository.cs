using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class AdvertisementRepository
    {
        public Advertisement addAdvertisement(Advertisement advertisement)
        {
            Connection con = Connection.getConnection();
            con.db.Advertisement.Add(advertisement);
            con.db.SaveChanges();

            return advertisement;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();
            Advertisement advertisement = (from a in con.db.Advertisement orderby a.advertisementID descending select a).FirstOrDefault();

            if(advertisement == null)
            {
                return 0;
            }
            else
            {
                return advertisement.advertisementID;                
            }
        }

        public List<Advertisement> getAllAdvertisement()
        {
            Connection con = Connection.getConnection();
            return con.db.Advertisement.ToList();
        }
    }
}
