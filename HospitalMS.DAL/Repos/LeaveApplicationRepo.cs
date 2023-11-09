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
    internal class LeaveApplicationRepo : IRepo<LeaveApplication, int, LeaveApplication>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<LeaveApplication> dbSet;
        public LeaveApplicationRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<LeaveApplication>();
        }

        public LeaveApplication Add(LeaveApplication obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<LeaveApplication> Get()
        {
            IQueryable<LeaveApplication> query = dbSet;
            return query.ToList();
        }

        public LeaveApplication Get(Expression<Func<LeaveApplication, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<LeaveApplication> IncludeProp<TProperty>(Expression<Func<LeaveApplication, TProperty>> property)
        {
            IQueryable<LeaveApplication> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<LeaveApplication> obj)
        {
            throw new NotImplementedException();
        }

        public LeaveApplication Update(LeaveApplication obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
