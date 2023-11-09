using HospitalMS.DAL.Interfaces;
using HospitalMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.DAL.Repos
{
    internal class CabinRepo:IRepo<Cabin, int, Cabin>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Cabin> dbSet;
        public CabinRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<Cabin>();
        }

        public Cabin Add(Cabin obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<Cabin> Get()
        {
            IQueryable<Cabin> query = dbSet;
            return query.ToList();
        }

        public Cabin Get(Expression<Func<Cabin, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<Cabin> IncludeProp<TProperty>(Expression<Func<Cabin, TProperty>> property)
        {
            IQueryable<Cabin> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<Cabin> obj)
        {
            throw new NotImplementedException();
        }

        public Cabin Update(Cabin obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
