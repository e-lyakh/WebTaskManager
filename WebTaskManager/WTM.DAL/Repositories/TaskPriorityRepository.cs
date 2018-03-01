using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;


namespace WTM.DAL.Repositories
{
    class TaskPriorityRepository : IRepository<TaskPriority>
    {
        private WtmDb db;

        public TaskPriorityRepository(WtmDb context)
        {
            this.db = context;
        }

        public IEnumerable<TaskPriority> GetAll()
        {
            return db.TaskPriorities;
        }

        public TaskPriority Get(int id)
        {
            return db.TaskPriorities.Find(id);
        }

        public void Create(TaskPriority prior)
        {
            db.TaskPriorities.Add(prior);
        }

        public void Update(TaskPriority prior)
        {
            db.Entry(prior).State = EntityState.Modified;
        }

        public IEnumerable<TaskPriority> Find(Func<TaskPriority, Boolean> predicate)
        {
            return db.TaskPriorities.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TaskPriority prior = db.TaskPriorities.Find(id);
            if (prior != null)
                db.TaskPriorities.Remove(prior);
        }
    }
}
