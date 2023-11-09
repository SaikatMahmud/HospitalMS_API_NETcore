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
    internal class DiagListRepo : IRepo<DiagList,int,DiagList>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<DiagList> dbSet;
        public DiagListRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<DiagList>();
        }

        public DiagList Add(DiagList obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<DiagList> Get()
        {
            IQueryable<DiagList> query = dbSet;
            return query.ToList();
        }

        public DiagList Get(Expression<Func<DiagList, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<DiagList> IncludeProp<TProperty>(Expression<Func<DiagList, TProperty>> property)
        {
            IQueryable<DiagList> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<DiagList> obj)
        {
            throw new NotImplementedException();
        }

        public DiagList Update(DiagList obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
