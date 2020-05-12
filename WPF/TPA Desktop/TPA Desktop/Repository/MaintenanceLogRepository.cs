using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class MaintenanceLogRepository
    {
        public dynamic getAllMaintenanceLog()
        {
            Connection con = Connection.getConnection();

            var result = (from l in con.db.MaintenanceLog
                          join s in con.db.MaintenanceSchedule on l.scheduleID equals s.scheduleID
                          join e in con.db.Employee on l.employeeID equals e.employeeID
                          select new
                          {
                              l.maintenanceLogID,
                              s.attractionID,
                              l.scheduleID,
                              e.name,
                              l.title,
                              l.description
                          });

            return result.ToList();
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            MaintenanceLog ml = (from m in con.db.MaintenanceLog orderby m.maintenanceLogID descending select m).FirstOrDefault();

            if (ml == null)
            {
                return 0;
            }
            return ml.maintenanceLogID;

        }

        public MaintenanceLog addMaintenanceLog(MaintenanceLog log)
        {
            Connection con = Connection.getConnection();

            con.db.MaintenanceLog.Add(log);
            con.db.SaveChanges();

            return log;
        }
    }
}
