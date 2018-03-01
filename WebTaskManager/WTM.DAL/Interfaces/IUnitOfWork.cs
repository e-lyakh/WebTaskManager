using System;
using WTM.DAL.Entities;

namespace WTM.DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Doer> Doers { get; }
        IRepository<TaskList> TaskLists { get; }
        IRepository<ListFilter> ListFilters { get; }
        IRepository<TaskItem> TaskItems { get; }
        IRepository<TaskSchedule> TaskSchedules { get; }
        IRepository<TaskPriority> TaskPriorities { get; }
        IRepository<TaskTag> TaskTags { get; }
        IRepository<TaskFile> TaskFiles { get; }
        IRepository<TaskStatus> TaskStatuses { get; }
        IRepository<Subtask> Subtasks { get; }
        IRepository<RepeatTerm> RepeatTerms { get; }

        void Save();
        
    }
}
