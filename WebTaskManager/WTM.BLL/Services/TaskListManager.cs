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
    public class TaskListManager : ITaskListManager
    {
        IUnitOfWork db { get; set; }

        public TaskListManager(IUnitOfWork uow)
        {
            db = uow;
        }

        public void CreateTaskList(TaskListDTO taskListDTO)
        {
            TaskList taskList = new TaskList
            {
                Name = taskListDTO.Name,
                Order_Rank = taskListDTO.Order_Rank,
                Color_R = taskListDTO.Color_R,
                Color_G = taskListDTO.Color_G,
                Color_B = taskListDTO.Color_B,
                User_Id = taskListDTO.User_Id,
                Filter_Id = taskListDTO.Filter_Id
            };
            db.TaskLists.Create(taskList);
            db.Save();
        }

        public TaskListDTO GetTaskList(int? id)
        {
            if (id == null)
                throw new ValidationException("Id of TaskList is not set", "");
            var taskList = db.TaskLists.Get(id.Value);
            if (taskList == null)
                throw new ValidationException("TaskList is not found (to get)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskList, TaskListDTO>());
            return Mapper.Map<TaskList, TaskListDTO>(taskList);
        }

        public void UpdateTaskList(TaskListDTO taskListDTO)
        {
            var taskList = db.TaskLists.Get(taskListDTO.Id);
            if (taskList == null)
                throw new ValidationException("TaskList is not found (to update)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskList, TaskListDTO>());
            db.TaskLists.Update(taskList);
            db.Save();
        }

        public void DeleteTaskList(TaskListDTO taskListDTO)
        {
            TaskList taskList = db.TaskLists.Get(taskListDTO.Id);
            if (taskList == null)
                throw new ValidationException("TaskList is not found (to delete)", "");
            db.TaskLists.Delete(taskList.Id);
            db.Save();
        }                

        public IEnumerable<TaskListDTO> GetTaskLists()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TaskList, TaskListDTO>());
            return Mapper.Map<IEnumerable<TaskList>, List<TaskListDTO>>(db.TaskLists.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
