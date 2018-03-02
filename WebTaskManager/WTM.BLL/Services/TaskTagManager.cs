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
    public class TaskTagManager : ITaskTagManager
    {
        IUnitOfWork db { get; set; }

        public TaskTagManager(IUnitOfWork uow)
        {
            db = uow;
        }

        public void CreateTaskTag(TaskTagDTO taskTagDTO)
        {
            TaskTag taskTag = new TaskTag
            {
                Name = taskTagDTO.Name               
            };
            db.TaskTags.Create(taskTag);
            db.Save();
        }

        public TaskTagDTO GetTaskTag(int? id)
        {
            if (id == null)
                throw new ValidationException("Id of TaskTag is not set", "");
            var taskTag = db.TaskTags.Get(id.Value);
            if (taskTag == null)
                throw new ValidationException("TaskTag is not found (to get)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskTag, TaskTagDTO>());
            return Mapper.Map<TaskTag, TaskTagDTO>(taskTag);
        }

        public void UpdateTaskTag(TaskTagDTO taskTagDTO)
        {
            var taskTag = db.TaskTags.Get(taskTagDTO.Id);
            if (taskTag == null)
                throw new ValidationException("TaskTag is not found (to update)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskTag, TaskTagDTO>());
            db.TaskTags.Update(taskTag);
            db.Save();
        }

        public void DeleteTaskTag(TaskTagDTO taskTagDTO)
        {
            TaskTag taskTag = db.TaskTags.Get(taskTagDTO.Id);
            if (taskTag == null)
                throw new ValidationException("TaskTag is not found (to delete)", "");
            db.TaskTags.Delete(taskTag.Id);
            db.Save();
        }                

        public IEnumerable<TaskTagDTO> GetTaskTags()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TaskTag, TaskTagDTO>());
            return Mapper.Map<IEnumerable<TaskTag>, List<TaskTagDTO>>(db.TaskTags.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
