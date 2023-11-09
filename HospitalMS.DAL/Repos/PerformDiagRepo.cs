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
    internal class PerformDiagRepo : IRepo<PerformDiag,int,PerformDiag>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<PerformDiag> dbSet;
        public PerformDiagRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<PerformDiag>();
        }

        public PerformDiag Add(PerformDiag obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<PerformDiag> Get()
        {
            IQueryable<PerformDiag> query = dbSet;
            return query.ToList();
        }

        public PerformDiag Get(Expression<Func<PerformDiag, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<PerformDiag> IncludeProp<TProperty>(Expression<Func<PerformDiag, TProperty>> property)
        {
            IQueryable<PerformDiag> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<PerformDiag> obj)
        {
            throw new NotImplementedException();
        }

        public PerformDiag Update(PerformDiag obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
