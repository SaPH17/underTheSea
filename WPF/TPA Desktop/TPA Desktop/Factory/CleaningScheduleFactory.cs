using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class CleaningScheduleFactory
    {
        public CleaningSchedule createNewCleaningSchedule(int roomID, DateTime? cleaningDate)
        {
            CleaningScheduleMediator mediator = new CleaningScheduleMediator();
            CleaningSchedule cleaningSchedule = new CleaningSchedule();

            cleaningSchedule.scheduleID = mediator.getLastID() + 1;
            cleaningSchedule.roomID = roomID;
            cleaningSchedule.cleaningDate = cleaningDate;
            cleaningSchedule.status = "Not Done";

            return cleaningSchedule;
        }
    }
}
