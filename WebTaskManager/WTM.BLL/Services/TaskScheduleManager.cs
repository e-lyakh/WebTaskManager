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
    public class TaskScheduleManager : ITaskScheduleManager
    {
        IUnitOfWork db { get; set; }

        public TaskScheduleManager(IUnitOfWork uow)
        {
            db = uow;
        }

        public void CreateTaskSchedule(TaskScheduleDTO taskScheduleDTO)
        {
            TaskSchedule taskSchedule = new TaskSchedule
            {
                Start_Term = taskScheduleDTO.Start_Term,
                End_Term = taskScheduleDTO.End_Term,
                Is_Reminder_On = taskScheduleDTO.Is_Reminder_On,
                Reminder_Time = taskScheduleDTO.Reminder_Time,
                RepeatTerm_Id = taskScheduleDTO.RepeatTerm_Id
            };
            db.TaskSchedules.Create(taskSchedule);
            db.Save();
        }

        public TaskScheduleDTO GetTaskSchedule(int? id)
        {
            if (id == null)
                throw new ValidationException("Id of TaskSchedule is not set", "");
            var taskSchedule = db.TaskSchedules.Get(id.Value);
            if (taskSchedule == null)
                throw new ValidationException("TaskSchedule is not found (to get)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskSchedule, TaskScheduleDTO>());
            return Mapper.Map<TaskSchedule, TaskScheduleDTO>(taskSchedule);
        }

        public void UpdateTaskSchedule(TaskScheduleDTO taskScheduleDTO)
        {
            var taskSchedule = db.TaskSchedules.Get(taskScheduleDTO.Id);
            if (taskSchedule == null)
                throw new ValidationException("TaskSchedule is not found (to update)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskSchedule, TaskScheduleDTO>());
            db.TaskSchedules.Update(taskSchedule);
            db.Save();
        }

        public void DeleteTaskSchedule(TaskScheduleDTO taskScheduleDTO)
        {
            TaskSchedule taskSchedule = db.TaskSchedules.Get(taskScheduleDTO.Id);
            if (taskSchedule == null)
                throw new ValidationException("TaskSchedule is not found (to delete)", "");
            db.TaskSchedules.Delete(taskSchedule.Id);
            db.Save();
        }                

        public IEnumerable<TaskScheduleDTO> GetTaskSchedules()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TaskSchedule, TaskScheduleDTO>());
            return Mapper.Map<IEnumerable<TaskSchedule>, List<TaskScheduleDTO>>(db.TaskSchedules.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
