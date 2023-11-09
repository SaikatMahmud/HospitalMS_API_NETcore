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
    internal class WardRepo : IRepo<Ward,int,Ward>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Ward> dbSet;
        public WardRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<Ward>();
        }

        public Ward Add(Ward obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<Ward> Get()
        {
            IQueryable<Ward> query = dbSet;
            return query.ToList();
        }

        public Ward Get(Expression<Func<Ward, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<Ward> IncludeProp<TProperty>(Expression<Func<Ward, TProperty>> property)
        {
            IQueryable<Ward> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<Ward> obj)
        {
            throw new NotImplementedException();
        }

        public Ward Update(Ward obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
