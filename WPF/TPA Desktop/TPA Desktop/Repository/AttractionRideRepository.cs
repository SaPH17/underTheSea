using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class AttractionRideRepository
    {
        public List<AttractionOrRide> getAllAttractionRide()
        {
            Connection con = Connection.getConnection();
            return (from a in con.db.AttractionOrRide where a.status != "Inactive" select a).ToList();
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            AttractionOrRide aor = (from a in con.db.AttractionOrRide orderby a.attractionID descending select a).FirstOrDefault();
            if(aor == null)
            {
                return 0;
            }
            return aor.attractionID;
        }

        public AttractionOrRide addAttractionOrRide(AttractionOrRide aor)
        {
            Connection con = Connection.getConnection();

            con.db.AttractionOrRide.Add(aor);
            con.db.SaveChanges();

            return aor;
        }

        public AttractionOrRide updateAttractionOrRide(int attractionID, AttractionOrRide aor)
        {
            Connection con = Connection.getConnection();

            AttractionOrRide newAor = con.db.AttractionOrRide.Find(attractionID);
            newAor = aor;
            con.db.SaveChanges();

            return newAor;
        }

        public AttractionOrRide getAttractionOrRide(int attractionID)
        {
            Connection con = Connection.getConnection();

            return con.db.AttractionOrRide.Find(attractionID);
        }
    }
}
