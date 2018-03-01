using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;

namespace WTM.DAL.Repositories
{
    class TaskListRepository : IRepository<TaskList>
    {
        private WtmDb db;

        public TaskListRepository(WtmDb context)
        {
            this.db = context;
        }

        public IEnumerable<TaskList> GetAll()
        {
            return db.TaskLists;
        }

        public TaskList Get(int id)
        {
            return db.TaskLists.Find(id);
        }

        public void Create(TaskList list)
        {
            db.TaskLists.Add(list);
        }

        public void Update(TaskList list)
        {
            db.Entry(list).State = EntityState.Modified;
        }

        public IEnumerable<TaskList> Find(Func<TaskList, Boolean> predicate)
        {
            return db.TaskLists.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TaskList list = db.TaskLists.Find(id);
            if (list != null)
                db.TaskLists.Remove(list);
        }
    }
}
