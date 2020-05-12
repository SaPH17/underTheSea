using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class MaintenanceScheduleRepository
    {
        public dynamic getAllMaintenanceSchedule()
        {
            Connection con = Connection.getConnection();

            var result = (from s in con.db.MaintenanceSchedule
                          join a in con.db.AttractionOrRide on s.attractionID equals a.attractionID
                          where s.status == "Not Done"
                          select new
                          {
                              s.scheduleID,
                              a.attractionID,
                              a.name,
                              s.scheduleDate,
                              s.status
                          });

            return result.ToList();
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            MaintenanceSchedule schedule = (from m in con.db.MaintenanceSchedule orderby m.scheduleID descending select m).FirstOrDefault();
            if (schedule == null)
            {
                return 0;
            }
            return schedule.scheduleID;
        }

        public MaintenanceSchedule addMaintenanceSchedule(MaintenanceSchedule schedule)
        {
            Connection con = Connection.getConnection();

            con.db.MaintenanceSchedule.Add(schedule);
            con.db.SaveChanges();

            return schedule;
        }

        public MaintenanceSchedule updateMaintenanceSchedule(int scheduleID, MaintenanceSchedule schedule)
        {
            Connection con = Connection.getConnection();

            MaintenanceSchedule newSchedule = con.db.MaintenanceSchedule.Find(scheduleID);
            newSchedule = schedule;

            con.db.SaveChanges();

            return newSchedule;
        }

        public MaintenanceSchedule getMaintenanceSchedule(int scheduleID)
        {
            Connection con = Connection.getConnection();

            return con.db.MaintenanceSchedule.Find(scheduleID);
        }
    }
}
