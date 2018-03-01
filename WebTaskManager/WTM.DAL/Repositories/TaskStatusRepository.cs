using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;


namespace WTM.DAL.Repositories
{
    class TaskStatusRepository : IRepository<TaskStatus>
    {
        private WtmDb db;

        public TaskStatusRepository(WtmDb context)
        {
            this.db = context;
        }

        public IEnumerable<TaskStatus> GetAll()
        {
            return db.TaskStatuses;
        }

        public TaskStatus Get(int id)
        {
            return db.TaskStatuses.Find(id);
        }

        public void Create(TaskStatus status)
        {
            db.TaskStatuses.Add(status);
        }

        public void Update(TaskStatus status)
        {
            db.Entry(status).State = EntityState.Modified;
        }

        public IEnumerable<TaskStatus> Find(Func<TaskStatus, Boolean> predicate)
        {
            return db.TaskStatuses.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TaskStatus status = db.TaskStatuses.Find(id);
            if (status != null)
                db.TaskStatuses.Remove(status);
        }
    }
}
