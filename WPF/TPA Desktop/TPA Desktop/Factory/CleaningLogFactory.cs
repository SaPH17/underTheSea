using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class CleaningLogFactory
    {
        public CleaningLog createNewCleaningLog(int roomID, string desc, DateTime? cleaningDate)
        {
            CleaningLogMediator mediator = new CleaningLogMediator();

            CleaningLog cleaningLog = new CleaningLog();
            cleaningLog.cleaningLogID = mediator.getLastID();
            cleaningLog.roomID = roomID;
            cleaningLog.description = desc;
            cleaningLog.cleaningDate = cleaningDate;

            return cleaningLog;
        }
    }
}
