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
    public class DoerManager : IDoerManager
    {
        IUnitOfWork db { get; set; }

        public DoerManager(IUnitOfWork uow)
        {
            db = uow;
        }

        public void CreateDoer(DoerDTO doerDTO)
        {
            Doer doer = new Doer
            {
                Name = doerDTO.Name,
                User_Id = doerDTO.User_Id
            };
            db.Doers.Create(doer);
            db.Save();
        }

        public DoerDTO GetDoer(int? id)
        {
            if (id == null)
                throw new ValidationException("Id of Doer is not set", "");
            var doer = db.Doers.Get(id.Value);
            if (doer == null)
                throw new ValidationException("Doer is not found (to get)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Doer, DoerDTO>());
            return Mapper.Map<Doer, DoerDTO>(doer);
        }

        public void UpdateDoer(DoerDTO doerDTO)
        {
            var doer = db.Doers.Get(doerDTO.Id);
            if (doer == null)
                throw new ValidationException("Doer is not found (to update)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Doer, DoerDTO>());
            db.Doers.Update(doer);
            db.Save();
        }

        public void DeleteDoer(DoerDTO doerDTO)
        {
            Doer doer = db.Doers.Get(doerDTO.Id);
            if (doer == null)
                throw new ValidationException("Doer is not found (to delete)", "");
            db.Doers.Delete(doer.Id);
            db.Save();
        }                

        public IEnumerable<DoerDTO> GetDoers()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Doer, DoerDTO>());
            return Mapper.Map<IEnumerable<Doer>, List<DoerDTO>>(db.Doers.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
