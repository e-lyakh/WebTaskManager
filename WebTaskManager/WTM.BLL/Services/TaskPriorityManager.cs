using System;
using System.Collections.Generic;
using AutoMapper;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;
using WTM.BLL.DTO;
using WTM.BLL.Infrastructure;
using WTM.BLL.Interfaces;


namespace WTM.BLL.Services
{
    public class TaskPriorityManager : ITaskPriorityManager
    {
        IUnitOfWork db { get; set; }

        public TaskPriorityManager(IUnitOfWork uow)
        {
            db = uow;
        }

        public void CreateTaskPriority(TaskPriorityDTO taskPriorityDTO)
        {
            TaskPriority taskPriority = new TaskPriority
            {
                Name = taskPriorityDTO.Name,
                Rank = taskPriorityDTO.Rank
            };
            db.TaskPriorities.Create(taskPriority);
            db.Save();
        }

        public TaskPriorityDTO GetTaskPriority(int? id)
        {
            if (id == null)
                throw new ValidationException("Id of TaskPriority is not set", "");
            var taskPriority = db.TaskPriorities.Get(id.Value);
            if (taskPriority == null)
                throw new ValidationException("TaskPriority is not found (to get)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskPriority, TaskPriorityDTO>());
            return Mapper.Map<TaskPriority, TaskPriorityDTO>(taskPriority);
        }

        public void UpdateTaskPriority(TaskPriorityDTO taskPriorityDTO)
        {
            var taskPriority = db.TaskPriorities.Get(taskPriorityDTO.Id);
            if (taskPriority == null)
                throw new ValidationException("TaskPriority is not found (to update)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskPriority, TaskPriorityDTO>());
            db.TaskPriorities.Update(taskPriority);
            db.Save();
        }

        public void DeleteTaskPriority(TaskPriorityDTO taskPriorityDTO)
        {
            TaskPriority taskPriority = db.TaskPriorities.Get(taskPriorityDTO.Id);
            if (taskPriority == null)
                throw new ValidationException("TaskPriority is not found (to delete)", "");
            db.TaskPriorities.Delete(taskPriority.Id);
            db.Save();
        }                

        public IEnumerable<TaskPriorityDTO> GetTaskPrioritys()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TaskPriority, TaskPriorityDTO>());
            return Mapper.Map<IEnumerable<TaskPriority>, List<TaskPriorityDTO>>(db.TaskPriorities.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}