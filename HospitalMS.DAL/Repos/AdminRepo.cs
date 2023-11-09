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
    internal class AdminRepo : IRepo<Admin, int, Admin>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Admin> dbSet;
        public AdminRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<Admin>();
        }

        public Admin Add(Admin obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<Admin> Get()
        {
            IQueryable<Admin> query = dbSet;
            return query.ToList();
        }

        public Admin Get(Expression<Func<Admin, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<Admin> IncludeProp<TProperty>(Expression<Func<Admin, TProperty>> property)
        {
            IQueryable<Admin> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<Admin> obj)
        {
            throw new NotImplementedException();
        }

        public Admin Update(Admin obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }
    }
}
