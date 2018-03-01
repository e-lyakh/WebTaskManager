using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;

namespace WTM.DAL.Repositories
{
    class TaskItemRepository : IRepository<TaskItem>
    {
        private WtmDb db;

        public TaskItemRepository(WtmDb context)
        {
            this.db = context;
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return db.TaskItems;
        }

        public TaskItem Get(int id)
        {
            return db.TaskItems.Find(id);
        }

        public void Create(TaskItem item)
        {
            db.TaskItems.Add(item);
        }

        public void Update(TaskItem item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<TaskItem> Find(Func<TaskItem, Boolean> predicate)
        {
            return db.TaskItems.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TaskItem item = db.TaskItems.Find(id);
            if (item != null)
                db.TaskItems.Remove(item);
        }
    }
}
