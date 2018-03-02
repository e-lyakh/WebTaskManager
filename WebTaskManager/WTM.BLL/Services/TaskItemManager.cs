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
    public class TaskItemManager : ITaskItemManager
    {
        IUnitOfWork db { get; set; }

        public TaskItemManager(IUnitOfWork uow)
        {
            db = uow;
        }

        public void CreateTaskItem(TaskItemDTO taskItemDTO)
        {
            TaskItem taskItem = new TaskItem
            {
                Name = taskItemDTO.Name,                
                List_Id = taskItemDTO.List_Id,
                Order_In_List = taskItemDTO.Order_In_List,
                Is_Favorite = taskItemDTO.Is_Favorite,
                Description = taskItemDTO.Description,
                Creation_Date = taskItemDTO.Creation_Date,
                Delete_Date = taskItemDTO.Delete_Date,
                Schedule_Id = taskItemDTO.Schedule_Id,
                Priority_Id = taskItemDTO.Priority_Id,
                Tag_Id = taskItemDTO.Tag_Id,
                Status_Id = taskItemDTO.Status_Id,
                User_Id = taskItemDTO.User_Id,
                Doer_Id = taskItemDTO.Doer_Id
            };
            db.TaskItems.Create(taskItem);
            db.Save();
        }

        public TaskItemDTO GetTaskItem(int? id)
        {
            if (id == null)
                throw new ValidationException("Id of TaskItem is not set", "");
            var taskItem = db.TaskItems.Get(id.Value);
            if (taskItem == null)
                throw new ValidationException("TaskItem is not found (to get)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskItem, TaskItemDTO>());
            return Mapper.Map<TaskItem, TaskItemDTO>(taskItem);
        }

        public void UpdateTaskItem(TaskItemDTO taskItemDTO)
        {
            var taskItem = db.TaskItems.Get(taskItemDTO.Id);
            if (taskItem == null)
                throw new ValidationException("TaskItem is not found (to update)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<TaskItem, TaskItemDTO>());
            db.TaskItems.Update(taskItem);
            db.Save();
        }

        public void DeleteTaskItem(TaskItemDTO taskItemDTO)
        {
            TaskItem taskItem = db.TaskItems.Get(taskItemDTO.Id);
            if (taskItem == null)
                throw new ValidationException("TaskItem is not found (to delete)", "");
            db.TaskItems.Delete(taskItem.Id);
            db.Save();
        }                

        public IEnumerable<TaskItemDTO> GetTaskItems()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TaskItem, TaskItemDTO>());
            return Mapper.Map<IEnumerable<TaskItem>, List<TaskItemDTO>>(db.TaskItems.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
