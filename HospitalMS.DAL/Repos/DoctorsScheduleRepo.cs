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
    internal class DoctorsScheduleRepo : IRepo<DoctorsSchedule, int, DoctorsSchedule>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<DoctorsSchedule> dbSet;
        public DoctorsScheduleRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<DoctorsSchedule>();
        }

        public DoctorsSchedule Add(DoctorsSchedule obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<DoctorsSchedule> Get()
        {
            IQueryable<DoctorsSchedule> query = dbSet;
            return query.ToList();
        }

        public DoctorsSchedule Get(Expression<Func<DoctorsSchedule, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<DoctorsSchedule> IncludeProp<TProperty>(Expression<Func<DoctorsSchedule, TProperty>> property)
        {
            IQueryable<DoctorsSchedule> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<DoctorsSchedule> obj)
        {
            throw new NotImplementedException();
        }

        public DoctorsSchedule Update(DoctorsSchedule obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
