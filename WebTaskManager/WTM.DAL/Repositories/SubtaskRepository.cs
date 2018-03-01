using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;

namespace WTM.DAL.Repositories
{
    class SubtaskRepository : IRepository<Subtask>
    {
        private WtmDb db;

        public SubtaskRepository(WtmDb context)
        {
            this.db = context;
        }

        public IEnumerable<Subtask> GetAll()
        {
            return db.Subtasks;
        }

        public Subtask Get(int id)
        {
            return db.Subtasks.Find(id);
        }

        public void Create(Subtask subtask)
        {
            db.Subtasks.Add(subtask);
        }

        public void Update(Subtask subtask)
        {
            db.Entry(subtask).State = EntityState.Modified;
        }

        public IEnumerable<Subtask> Find(Func<Subtask, Boolean> predicate)
        {
            return db.Subtasks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Subtask subtask = db.Subtasks.Find(id);
            if (subtask != null)
                db.Subtasks.Remove(subtask);
        }
    }
}
