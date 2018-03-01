using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;


namespace WTM.DAL.Repositories
{
    class TaskTagRepository : IRepository<TaskTag>
    {
        private WtmDb db;

        public TaskTagRepository(WtmDb context)
        {
            this.db = context;
        }

        public IEnumerable<TaskTag> GetAll()
        {
            return db.TaskTags;
        }

        public TaskTag Get(int id)
        {
            return db.TaskTags.Find(id);
        }

        public void Create(TaskTag tag)
        {
            db.TaskTags.Add(tag);
        }

        public void Update(TaskTag tag)
        {
            db.Entry(tag).State = EntityState.Modified;
        }

        public IEnumerable<TaskTag> Find(Func<TaskTag, Boolean> predicate)
        {
            return db.TaskTags.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TaskTag tag = db.TaskTags.Find(id);
            if (tag != null)
                db.TaskTags.Remove(tag);
        }
    }
}
