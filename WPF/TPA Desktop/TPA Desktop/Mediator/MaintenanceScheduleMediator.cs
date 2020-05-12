using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class MaintenanceScheduleMediator
    {
        public dynamic getAllMaintenanceSchedule()
        {
            MaintenanceScheduleRepository repository = new MaintenanceScheduleRepository();
            return repository.getAllMaintenanceSchedule();
        }

        public int getLastID()
        {
            MaintenanceScheduleRepository repository = new MaintenanceScheduleRepository();
            return repository.getLastID();
        }

        public MaintenanceSchedule addMaintenanceSchedule(MaintenanceSchedule schedule)
        {
            MaintenanceScheduleRepository repository = new MaintenanceScheduleRepository();
            return repository.addMaintenanceSchedule(schedule);
        }

        public MaintenanceSchedule updateMaintenanceSchedule(int scheduleID, MaintenanceSchedule schedule)
        {
            MaintenanceScheduleRepository repository = new MaintenanceScheduleRepository();
            return repository.updateMaintenanceSchedule(scheduleID, schedule);
        }

        public MaintenanceSchedule getMaintenanceSchedule(int scheduleID)
        {
            MaintenanceScheduleRepository repository = new MaintenanceScheduleRepository();
            return repository.getMaintenanceSchedule(scheduleID);
        }
    }
}
