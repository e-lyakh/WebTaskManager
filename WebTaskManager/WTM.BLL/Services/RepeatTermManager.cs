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
    public class RepeatTermManager : IRepeatTermManager
    {
        IUnitOfWork db { get; set; }

        public RepeatTermManager(IUnitOfWork uow)
        {
            db = uow;
        }

        // The method is not necessary (terms will be created as const and won't be changed)
        public void CreateRepeatTerm(RepeatTermDTO repeatTermDTO)
        {
            RepeatTerm repeatTerm = new RepeatTerm
            {               
                Repeat_Term = repeatTermDTO.Repeat_Term
            };
            db.RepeatTerms.Create(repeatTerm);
            db.Save();
        }

        public RepeatTermDTO GetRepeatTerm(int? id)
        {
            if (id == null)
                throw new ValidationException("Id of RepeatTerm is not set", "");
            var repeatTerm = db.RepeatTerms.Get(id.Value);
            if (repeatTerm == null)
                throw new ValidationException("RepeatTerm is not found (to get)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<RepeatTerm, RepeatTermDTO>());
            return Mapper.Map<RepeatTerm, RepeatTermDTO>(repeatTerm);

        }

        // The method is not necessary (terms will be created as const and won't be changed)
        public void UpdateRepeatTerm(RepeatTermDTO repeatTermDTO)
        {
            var repeatTerm = db.RepeatTerms.Get(repeatTermDTO.Id);
            if (repeatTerm == null)
                throw new ValidationException("RepeatTerm is not found (to update)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<RepeatTerm, RepeatTermDTO>());
            db.RepeatTerms.Update(repeatTerm);
            db.Save();
        }

        // The method is not necessary (terms will be created as const and won't be changed)
        public void DeleteRepeatTerm(RepeatTermDTO repeatTermDTO)
        {
            RepeatTerm repeatTerm = db.RepeatTerms.Get(repeatTermDTO.Id);
            if (repeatTerm == null)
                throw new ValidationException("RepeatTerm is not found (to delete)", "");
            db.RepeatTerms.Delete(repeatTerm.Id);
            db.Save();
        }                

        public IEnumerable<RepeatTermDTO> GetRepeatTerms()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RepeatTerm, RepeatTermDTO>());
            return Mapper.Map<IEnumerable<RepeatTerm>, List<RepeatTermDTO>>(db.RepeatTerms.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
