using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class MaintenanceScheduleFactory
    {
        public MaintenanceSchedule createNewMaintenanceSchedule(int attractionID, DateTime? scheduleDate)
        {
            MaintenanceScheduleMediator mediator = new MaintenanceScheduleMediator();
            MaintenanceSchedule ms = new MaintenanceSchedule();
            ms.scheduleID = mediator.getLastID() + 1;
            ms.attractionID = attractionID;
            ms.scheduleDate = scheduleDate;
            ms.status = "Not Done";

            return ms;
        }
    }
}
