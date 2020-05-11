using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class TaskFactory
    {
        public Task createNewTask(int ideaID, string desc)
        {
            TaskMediator mediator = new TaskMediator();
            Task task = new Task();
            task.taskID = mediator.getLastID() + 1;
            task.ideaID = ideaID;
            task.status = "Not Done";
            task.taskDescription = desc;

            return task;
        }
    }
}
