using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class TaskRepository
    {
        public Task addTask(Task task)
        {
            Connection con = Connection.getConnection();

            con.db.Task.Add(task);
            con.db.SaveChanges();

            return task;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            Task task = (from t in con.db.Task orderby t.taskID descending select t).FirstOrDefault();
            if (task == null)
            {
                return 0;
            }
            return task.taskID;
        }

        public dynamic getAllTask()
        {
            Connection con = Connection.getConnection();

            var result = (from t in con.db.Task
                          join i in con.db.Idea on t.ideaID equals i.ideaID
                          where t.status == "Not Done"
                          select new {
                              t.taskID,
                              i.name,
                              i.description,
                              i.type,
                              i.category,
                              t.status,
                              t.taskDescription
                          });

            return result.ToList();
        }
    }
}
