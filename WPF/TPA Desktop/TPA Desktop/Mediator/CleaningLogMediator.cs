using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class CleaningLogMediator
    {
        public int getLastID()
        {
            CleaningLogRepository repository = new CleaningLogRepository();
            return repository.getLastID();
        }

        public CleaningLog addCleaningLog(CleaningLog cleaningLog)
        {
            CleaningLogRepository repository = new CleaningLogRepository();
            return repository.addCleaningLog(cleaningLog);
        }

        public List<CleaningLog> getAllCleaningLog()
        {
            CleaningLogRepository repository = new CleaningLogRepository();
            return repository.getAllCleaningLog();
        }
    }
}
