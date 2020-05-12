using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class MaintenanceLogMediator
    {
        public dynamic getAllMaintenanceLog()
        {
            MaintenanceLogRepository repository = new MaintenanceLogRepository();
            return repository.getAllMaintenanceLog();
        }

        public int getLastID()
        {
            MaintenanceLogRepository repository = new MaintenanceLogRepository();
            return repository.getLastID();
        }

        public MaintenanceLog addMaintenanceLog(MaintenanceLog log)
        {
            MaintenanceLogRepository repository = new MaintenanceLogRepository();
            return repository.addMaintenanceLog(log);
        }
    }
}
