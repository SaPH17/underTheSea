using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class MaintenanceLogFactory
    {
        public MaintenanceLog createNewMaintenanceLog(int scheduleID, int employeeID, string title, string desc)
        {
            MaintenanceLogMediator mediator = new MaintenanceLogMediator();
            MaintenanceLog log = new MaintenanceLog();
            log.maintenanceLogID = mediator.getLastID() + 1;
            log.scheduleID = scheduleID;
            log.employeeID = employeeID;
            log.title = title;
            log.description = desc;

            return log;
        }
    }
}
