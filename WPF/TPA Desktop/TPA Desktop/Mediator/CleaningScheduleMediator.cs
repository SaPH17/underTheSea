using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class CleaningScheduleMediator
    {
        public List<CleaningSchedule> getAllCleaningSchedule()
        {
            CleaningScheduleRepository repository = new CleaningScheduleRepository();
            return repository.getAllCleaningSchedule();
        }

        public CleaningSchedule addCleaningSchedule(CleaningSchedule cleaningSchedule)
        {
            CleaningScheduleRepository repository = new CleaningScheduleRepository();
            return repository.addCleaningSchedule(cleaningSchedule);
        }

        public int getLastID()
        {
            CleaningScheduleRepository repository = new CleaningScheduleRepository();
            return repository.getLastID();
        }

        public CleaningSchedule getCleaningSchedule(int scheduleID)
        {
            CleaningScheduleRepository repository = new CleaningScheduleRepository();
            return repository.getCleaningSchedule(scheduleID);
        }

        public CleaningSchedule updateCleaningSchedule(int scheduleID, CleaningSchedule cleaningSchedule)
        {
            CleaningScheduleRepository repository = new CleaningScheduleRepository();
            return repository.updateCleaningSchedule(scheduleID, cleaningSchedule);
        }
    }
}
