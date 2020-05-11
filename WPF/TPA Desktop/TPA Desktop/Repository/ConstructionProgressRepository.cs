using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class ConstructionProgressRepository
    {
        public dynamic getAllConstructionProgress()
        {
            Connection con = Connection.getConnection();

            var result = from c in con.db.ConstructionProgress
                         join a in con.db.AttractionOrRide on c.attractionID equals a.attractionID
                         select new
                         {
                             c.progressID,
                             a.attractionID,
                             a.name,
                             c.title,
                             c.description,
                             c.progressDate
                         };
            return result.ToList();
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            ConstructionProgress cp = (from c in con.db.ConstructionProgress orderby c.progressID descending select c).FirstOrDefault();
            if(cp == null)
            {
                return 0;
            }
            return cp.progressID;
        }

        public ConstructionProgress addConstructionProgress(ConstructionProgress cp)
        {
            Connection con = Connection.getConnection();

            con.db.ConstructionProgress.Add(cp);
            con.db.SaveChanges();

            return cp;
        }
    }
}
