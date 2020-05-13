using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class TaskMediator
    {
        public Task addTask(Task task)
        {
            TaskRepository repository = new TaskRepository();
            return repository.addTask(task);
        }

        public int getLastID()
        {
            TaskRepository repository = new TaskRepository();
            return repository.getLastID();
        }

        public dynamic getAllTask()
        {
            TaskRepository repository = new TaskRepository();
            return repository.getAllTask();
        }

        public Task updateTask(int taskID, Task task)
        {
            TaskRepository repository = new TaskRepository();
            return repository.updateTask(taskID, task);
        }
    }
}
