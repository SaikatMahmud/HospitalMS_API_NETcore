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
    internal class IPDBillRepo : IRepo<IPDBill, int, IPDBill>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<IPDBill> dbSet;
        public IPDBillRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<IPDBill>();
        }

        public IPDBill Add(IPDBill obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<IPDBill> Get()
        {
            IQueryable<IPDBill> query = dbSet;
            return query.ToList();
        }

        public IPDBill Get(Expression<Func<IPDBill, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<IPDBill> IncludeProp<TProperty>(Expression<Func<IPDBill, TProperty>> property)
        {
            IQueryable<IPDBill> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<IPDBill> obj)
        {
            throw new NotImplementedException();
        }

        public IPDBill Update(IPDBill obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
