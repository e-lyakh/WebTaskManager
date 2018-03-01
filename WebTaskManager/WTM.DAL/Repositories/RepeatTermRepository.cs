using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;

namespace WTM.DAL.Repositories
{
    class RepeatTermRepository : IRepository<RepeatTerm>
    {
        private WtmDb db;

        public RepeatTermRepository(WtmDb context)
        {
            this.db = context;
        }

        public IEnumerable<RepeatTerm> GetAll()
        {
            return db.RepeatTerms;
        }

        public RepeatTerm Get(int id)
        {
            return db.RepeatTerms.Find(id);
        }

        public void Create(RepeatTerm term)
        {
            db.RepeatTerms.Add(term);
        }

        public void Update(RepeatTerm term)
        {
            db.Entry(term).State = EntityState.Modified;
        }

        public IEnumerable<RepeatTerm> Find(Func<RepeatTerm, Boolean> predicate)
        {
            return db.RepeatTerms.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            RepeatTerm term = db.RepeatTerms.Find(id);
            if (term != null)
                db.RepeatTerms.Remove(term);
        }
    }
}
