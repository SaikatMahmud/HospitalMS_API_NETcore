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
    internal class PatientRepo : IRepo<Patient, int, Patient>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Patient> dbSet;
        public PatientRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<Patient>();
        }

        public Patient Add(Patient obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<Patient> Get()
        {
            IQueryable<Patient> query = dbSet;
            return query.ToList();
        }

        public Patient Get(Expression<Func<Patient, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<Patient> IncludeProp<TProperty>(Expression<Func<Patient, TProperty>> property)
        {
            IQueryable<Patient> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<Patient> obj)
        {
            throw new NotImplementedException();
        }

        public Patient Update(Patient obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
