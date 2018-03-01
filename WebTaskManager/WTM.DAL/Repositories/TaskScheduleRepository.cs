using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;


namespace WTM.DAL.Repositories
{
    class TaskScheduleRepository : IRepository<TaskSchedule>
    {
        private WtmDb db;

        public TaskScheduleRepository(WtmDb context)
        {
            this.db = context;
        }

        public IEnumerable<TaskSchedule> GetAll()
        {
            return db.TaskSchedules;
        }

        public TaskSchedule Get(int id)
        {
            return db.TaskSchedules.Find(id);
        }

        public void Create(TaskSchedule schedule)
        {
            db.TaskSchedules.Add(schedule);
        }

        public void Update(TaskSchedule schedule)
        {
            db.Entry(schedule).State = EntityState.Modified;
        }

        public IEnumerable<TaskSchedule> Find(Func<TaskSchedule, Boolean> predicate)
        {
            return db.TaskSchedules.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TaskSchedule schedule = db.TaskSchedules.Find(id);
            if (schedule != null)
                db.TaskSchedules.Remove(schedule);
        }
    }
}
