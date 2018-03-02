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
    public class TaskStatusManager : ITaskStatusManager
    {
        IUnitOfWork db { get; set; }

        public TaskStatusManager(IUnitOfWork uow)
        {
            db = uow;
        }

        public void CreateTaskStatus(TaskStatusDTO taskStatusDTO)
        {
            TaskStatus taskStatus = new TaskStatus
            {
                Name = taskStatusDTO.Name                
            };
            db.TaskStatuses.Create(taskStatus);
            db.Save();
        }

        public TaskStatusDTO GetTaskStatus(int? id)
        {
            if (id == null)
                throw new ValidationException("Id of TaskStatus is not set", "");
            var taskStatus = db.TaskStatuses.Get(id.Value);
            if (taskStatus == null)
                throw new ValidationException("TaskStatus is not found (to get)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskStatus, TaskStatusDTO>());
            return Mapper.Map<TaskStatus, TaskStatusDTO>(taskStatus);
        }

        public void UpdateTaskStatus(TaskStatusDTO taskStatusDTO)
        {
            var taskStatus = db.TaskStatuses.Get(taskStatusDTO.Id);
            if (taskStatus == null)
                throw new ValidationException("TaskStatus is not found (to update)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskStatus, TaskStatusDTO>());
            db.TaskStatuses.Update(taskStatus);
            db.Save();
        }

        public void DeleteTaskStatus(TaskStatusDTO taskStatusDTO)
        {
            TaskStatus taskStatus = db.TaskStatuses.Get(taskStatusDTO.Id);
            if (taskStatus == null)
                throw new ValidationException("TaskStatus is not found (to delete)", "");
            db.TaskStatuses.Delete(taskStatus.Id);
            db.Save();
        }                

        public IEnumerable<TaskStatusDTO> GetTaskStatuss()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TaskStatus, TaskStatusDTO>());
            return Mapper.Map<IEnumerable<TaskStatus>, List<TaskStatusDTO>>(db.TaskStatuses.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
