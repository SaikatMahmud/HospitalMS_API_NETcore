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
    internal class ComplaintRepo : IRepo<Complaint, int, Complaint>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Complaint> dbSet;
        public ComplaintRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<Complaint>();
        }

        public Complaint Add(Complaint obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<Complaint> Get()
        {
            IQueryable<Complaint> query = dbSet;
            return query.ToList();
        }

        public Complaint Get(Expression<Func<Complaint, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<Complaint> IncludeProp<TProperty>(Expression<Func<Complaint, TProperty>> property)
        {
            IQueryable<Complaint> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<Complaint> obj)
        {
            throw new NotImplementedException();
        }

        public Complaint Update(Complaint obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
