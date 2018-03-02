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
    public class SubtaskManager : ISubtaskManager
    {
        IUnitOfWork db { get; set; }

        public SubtaskManager(IUnitOfWork uow)
        {
            db = uow;
        }

        public void CreateSubtask(SubtaskDTO subtaskDTO)
        {
            Subtask subtask = new Subtask
            {
                Name = subtaskDTO.Name,
                Order_In_List = subtaskDTO.Order_In_List,
                Is_Completed = false,
                Task_Id = subtaskDTO.Task_Id
            };
            db.Subtasks.Create(subtask);
            db.Save();
        }

        public SubtaskDTO GetSubtask(int? id)
        {
            if (id == null)
                throw new ValidationException("Id of Subtask is not set", "");
            var subtask = db.Subtasks.Get(id.Value);
            if (subtask == null)
                throw new ValidationException("Subtask is not found (to get)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Subtask, SubtaskDTO>());
            return Mapper.Map<Subtask, SubtaskDTO>(subtask);

        }

        public void UpdateSubtask(SubtaskDTO subtaskDTO)
        {
            var subtask = db.Subtasks.Get(subtaskDTO.Id);
            if (subtask == null)
                throw new ValidationException("Subtask is not found (to update)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Subtask, SubtaskDTO>());
            db.Subtasks.Update(subtask);
            db.Save();
        }

        public void DeleteSubtask(SubtaskDTO subtaskDTO)
        {
            Subtask subtask = db.Subtasks.Get(subtaskDTO.Id);
            if (subtask == null)
                throw new ValidationException("Subtask is not found (to delete)", "");
            db.Subtasks.Delete(subtask.Id);
            db.Save();
        }                

        public IEnumerable<SubtaskDTO> GetSubtasks()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Subtask, SubtaskDTO>());
            return Mapper.Map<IEnumerable<Subtask>, List<SubtaskDTO>>(db.Subtasks.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
