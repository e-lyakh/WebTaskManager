using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;

namespace WTM.DAL.Repositories
{
    class TaskFileRepository : IRepository<TaskFile>
    {
        private WtmDb db;

        public TaskFileRepository(WtmDb context)
        {
            this.db = context;
        }

        public IEnumerable<TaskFile> GetAll()
        {
            return db.TaskFiles;
        }

        public TaskFile Get(int id)
        {
            return db.TaskFiles.Find(id);
        }

        public void Create(TaskFile file)
        {
            db.TaskFiles.Add(file);
        }

        public void Update(TaskFile file)
        {
            db.Entry(file).State = EntityState.Modified;
        }

        public IEnumerable<TaskFile> Find(Func<TaskFile, Boolean> predicate)
        {
            return db.TaskFiles.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TaskFile file = db.TaskFiles.Find(id);
            if (file != null)
                db.TaskFiles.Remove(file);
        }
    }
}
