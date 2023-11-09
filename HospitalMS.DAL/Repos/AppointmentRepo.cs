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
    internal class AppointmentRepo : IRepo<Appointment,int,Appointment>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Appointment> dbSet;
        public AppointmentRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<Appointment>();
        }

        public Appointment Add(Appointment obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<Appointment> Get()
        {
            IQueryable<Appointment> query = dbSet;
            return query.ToList();
        }

        public Appointment Get(Expression<Func<Appointment, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<Appointment> IncludeProp<TProperty>(Expression<Func<Appointment, TProperty>> property)
        {
            IQueryable<Appointment> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<Appointment> obj)
        {
            throw new NotImplementedException();
        }

        public Appointment Update(Appointment obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }
    }
}

