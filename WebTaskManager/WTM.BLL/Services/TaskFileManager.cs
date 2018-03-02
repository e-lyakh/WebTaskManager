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
    public class TaskFileManager : ITaskFileManager
    {
        IUnitOfWork db { get; set; }

        public TaskFileManager(IUnitOfWork uow)
        {
            db = uow;
        }

        public void CreateTaskFile(TaskFileDTO taskFileDTO)
        {
            TaskFile taskFile = new TaskFile
            {
                Name = taskFileDTO.Name,
                Path = taskFileDTO.Path,
                Guid = taskFileDTO.Guid,
                Attach_Date = taskFileDTO.Attach_Date,
                Task_Id = taskFileDTO.Task_Id
            };
            db.TaskFiles.Create(taskFile);
            db.Save();
        }

        public TaskFileDTO GetTaskFile(int? id)
        {
            if (id == null)
                throw new ValidationException("Id of TaskFile is not set", "");
            var taskFile = db.TaskFiles.Get(id.Value);
            if (taskFile == null)
                throw new ValidationException("TaskFile is not found (to get)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskFile, TaskFileDTO>());
            return Mapper.Map<TaskFile, TaskFileDTO>(taskFile);
        }

        public void UpdateTaskFile(TaskFileDTO taskFileDTO)
        {
            var taskFile = db.TaskFiles.Get(taskFileDTO.Id);
            if (taskFile == null)
                throw new ValidationException("TaskFile is not found (to update)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskFile, TaskFileDTO>());
            db.TaskFiles.Update(taskFile);
            db.Save();
        }

        public void DeleteTaskFile(TaskFileDTO taskFileDTO)
        {
            TaskFile taskFile = db.TaskFiles.Get(taskFileDTO.Id);
            if (taskFile == null)
                throw new ValidationException("TaskFile is not found (to delete)", "");
            db.TaskFiles.Delete(taskFile.Id);
            db.Save();
        }                

        public IEnumerable<TaskFileDTO> GetTaskFiles()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TaskFile, TaskFileDTO>());
            return Mapper.Map<IEnumerable<TaskFile>, List<TaskFileDTO>>(db.TaskFiles.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
