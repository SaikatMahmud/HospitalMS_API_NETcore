using HospitalMS.DAL.Interfaces;
using HospitalMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.DAL.Repos
{
    internal class DepartmentRepo : IRepo<Department, int, bool>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Department> dbSet;
        public DepartmentRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<Department>();
        }

        public bool Add(Department obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return true;
            return false;
        }

        public IEnumerable<Department> Get()
        {
            IQueryable<Department> query = dbSet;
            return query.ToList();
        }

        public Department Get(Expression<Func<Department, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<Department> IncludeProp<TProperty>(Expression<Func<Department, TProperty>> property)
        {
            IQueryable<Department> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<Department> obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Department obj)
        {
            var exObj = dbSet.Find(obj.DepartmentId);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0;
        }
    }
}
