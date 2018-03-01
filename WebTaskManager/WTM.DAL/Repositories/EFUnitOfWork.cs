using System;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;

namespace WTM.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private WtmDb db;
        private DoerRepository doerRepository;
        private ListFilterRepository listFilterRepository;
        private RepeatTermRepository repeatTermRepository;
        private SubtaskRepository subtaskRepository;
        private TaskFileRepository taskFileRepository;
        private TaskItemRepository taskItemRepository;
        private TaskListRepository taskListRepository;
        private TaskPriorityRepository taskPriorityRepository;
        private TaskScheduleRepository taskScheduleRepository;
        private TaskStatusRepository taskStatusRepository;
        private TaskTagRepository taskTagRepository;
        private UserRepository userRepository;

        public EFUnitOfWork()
        {
            db = new WtmDb();
        }

        public IRepository<Doer> Doers
        {
            get
            {
                if (doerRepository == null)
                    doerRepository = new DoerRepository(db);
                return doerRepository;
            }
        }

        public IRepository<ListFilter> ListFilters
        {
            get
            {
                if (listFilterRepository == null)
                    listFilterRepository = new ListFilterRepository(db);
                return listFilterRepository;
            }
        }

        public IRepository<RepeatTerm> RepeatTerms
        {
            get
            {
                if (repeatTermRepository == null)
                    repeatTermRepository = new RepeatTermRepository(db);
                return repeatTermRepository;
            }
        }

        public IRepository<Subtask> Subtasks
        {
            get
            {
                if (subtaskRepository == null)
                    subtaskRepository = new SubtaskRepository(db);
                return subtaskRepository;
            }
        }

        public IRepository<TaskFile> TaskFiles
        {
            get
            {
                if (taskFileRepository == null)
                    taskFileRepository = new TaskFileRepository(db);
                return taskFileRepository;
            }
        }

        public IRepository<TaskItem> TaskItems
        {
            get
            {
                if (taskItemRepository == null)
                    taskItemRepository = new TaskItemRepository(db);
                return taskItemRepository;
            }
        }

        public IRepository<TaskList> TaskLists
        {
            get
            {
                if (taskListRepository == null)
                    taskListRepository = new TaskListRepository(db);
                return taskListRepository;
            }
        }

        public IRepository<TaskPriority> TaskPriorities
        {
            get
            {
                if (taskPriorityRepository == null)
                    taskPriorityRepository = new TaskPriorityRepository(db);
                return taskPriorityRepository;
            }
        }

        public IRepository<TaskSchedule> TaskSchedules
        {
            get
            {
                if (taskScheduleRepository == null)
                    taskScheduleRepository = new TaskScheduleRepository(db);
                return taskScheduleRepository;
            }
        }

        public IRepository<TaskStatus> TaskStatuses
        {
            get
            {
                if (taskStatusRepository == null)
                    taskStatusRepository = new TaskStatusRepository(db);
                return taskStatusRepository;
            }
        }

        public IRepository<TaskTag> TaskTags
        {
            get
            {
                if (taskTagRepository == null)
                    taskTagRepository = new TaskTagRepository(db);
                return taskTagRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
