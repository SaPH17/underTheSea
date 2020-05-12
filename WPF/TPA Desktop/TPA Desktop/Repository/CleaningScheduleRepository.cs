using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class CleaningScheduleRepository
    {
        public List<CleaningSchedule> getAllCleaningSchedule()
        {
            Connection con = Connection.getConnection();
            return con.db.CleaningSchedule.ToList();
        }

        public CleaningSchedule addCleaningSchedule(CleaningSchedule cleaningSchedule)
        {
            Connection con = Connection.getConnection();
            con.db.CleaningSchedule.Add(cleaningSchedule);
            con.db.SaveChanges();

            return cleaningSchedule;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            CleaningSchedule schedule = (from c in con.db.CleaningSchedule orderby c.scheduleID descending select c).FirstOrDefault();
            if(schedule == null)
            {
                return 0;
            }
            return schedule.scheduleID;
        }

        public CleaningSchedule getCleaningSchedule(int scheduleID)
        {
            Connection con = Connection.getConnection();

            return con.db.CleaningSchedule.Find(scheduleID);
        }

        public CleaningSchedule updateCleaningSchedule(int scheduleID, CleaningSchedule cleaningSchedule)
        {
            Connection con = Connection.getConnection();

            CleaningSchedule cs = con.db.CleaningSchedule.Find(scheduleID);
            cs = cleaningSchedule;
            return cs;
        }
    }
}
