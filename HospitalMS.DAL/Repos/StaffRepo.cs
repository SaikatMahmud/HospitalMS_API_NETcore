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
    internal class StaffRepo : IRepo<Staff, int, Staff>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Staff> dbSet;
        public StaffRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<Staff>();
        }

        public Staff Add(Staff obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<Staff> Get()
        {
            IQueryable<Staff> query = dbSet;
            return query.ToList();
        }

        public Staff Get(Expression<Func<Staff, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<Staff> IncludeProp<TProperty>(Expression<Func<Staff, TProperty>> property)
        {
            IQueryable<Staff> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<Staff> obj)
        {
            throw new NotImplementedException();
        }

        public Staff Update(Staff obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
