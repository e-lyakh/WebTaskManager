using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;

namespace WTM.DAL.Repositories
{
    class ListFilterRepository : IRepository<ListFilter>
    {
        private WtmDb db;

        public ListFilterRepository(WtmDb context)
        {
            this.db = context;
        }

        public IEnumerable<ListFilter> GetAll()
        {
            return db.ListFilters;
        }

        public ListFilter Get(int id)
        {
            return db.ListFilters.Find(id);
        }

        public void Create(ListFilter filter)
        {
            db.ListFilters.Add(filter);
        }

        public void Update(ListFilter filter)
        {
            db.Entry(filter).State = EntityState.Modified;
        }

        public IEnumerable<ListFilter> Find(Func<ListFilter, Boolean> predicate)
        {
            return db.ListFilters.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ListFilter filter = db.ListFilters.Find(id);
            if (filter != null)
                db.ListFilters.Remove(filter);
        }
    }
}
