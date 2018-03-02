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
    public class ListFilterManager : IListFilterManager
    {
        IUnitOfWork db { get; set; }

        public ListFilterManager(IUnitOfWork uow)
        {
            db = uow;
        }

        public void CreateListFilter(ListFilterDTO listFilterDTO)
        {
            ListFilter listFilter = new ListFilter
            {
                Is_Show_Completed = false,
                Is_Ordered_Term = false,
                Is_Ordered_Prior = false,
                Is_Ordered_Tag = false,
                Selected_From_Date = null,
                Selected_To_Date = null,
                Selected_Prior_Id = null,
                Selected_Tag_Id = null,
                Is_Only_Favorites = false
            };
            db.ListFilters.Create(listFilter);
            db.Save();
        }

        public ListFilterDTO GetListFilter(int? id)
        {
            if (id == null)
                throw new ValidationException("Id of ListFilter is not set", "");
            var listFilter = db.ListFilters.Get(id.Value);
            if (listFilter == null)
                throw new ValidationException("ListFilter is not found (to get)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ListFilter, ListFilterDTO>());
            return Mapper.Map<ListFilter, ListFilterDTO>(listFilter);

        }

        public void UpdateListFilter(ListFilterDTO listFilterDTO)
        {
            var listFilter = db.ListFilters.Get(listFilterDTO.Id);
            if (listFilter == null)
                throw new ValidationException("ListFilter is not found (to update)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ListFilter, ListFilterDTO>());
            db.ListFilters.Update(listFilter);
            db.Save();
        }

        public void DeleteListFilter(ListFilterDTO listFilterDTO)
        {
            ListFilter listFilter = db.ListFilters.Get(listFilterDTO.Id);
            if (listFilter == null)
                throw new ValidationException("ListFilter is not found (to delete)", "");
            db.ListFilters.Delete(listFilter.Id);
            db.Save();
        }                

        public IEnumerable<ListFilterDTO> GetListFilters()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ListFilter, ListFilterDTO>());
            return Mapper.Map<IEnumerable<ListFilter>, List<ListFilterDTO>>(db.ListFilters.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
