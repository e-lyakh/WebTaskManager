using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;


namespace WTM.DAL.Repositories
{
    class DoerRepository : IRepository<Doer>
    {
        private WtmDb db;

        public DoerRepository(WtmDb context)
        {
            this.db = context;
        }

        public IEnumerable<Doer> GetAll()
        {
            return db.Doers;
        }

        public Doer Get(int id)
        {
            return db.Doers.Find(id);
        }

        public void Create(Doer doer)
        {
            db.Doers.Add(doer);
        }

        public void Update(Doer doer)
        {
            db.Entry(doer).State = EntityState.Modified;
        }

        public IEnumerable<Doer> Find(Func<Doer, Boolean> predicate)
        {
            return db.Doers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Doer doer = db.Doers.Find(id);
            if (doer != null)
                db.Doers.Remove(doer);
        }
    }
}
