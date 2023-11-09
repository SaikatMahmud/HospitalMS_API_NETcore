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
    internal class OPDBillRepo : IRepo<OPDBill,int,OPDBill>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<OPDBill> dbSet;
        public OPDBillRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<OPDBill>();
        }

        public OPDBill Add(OPDBill obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<OPDBill> Get()
        {
            IQueryable<OPDBill> query = dbSet;
            return query.ToList();
        }

        public OPDBill Get(Expression<Func<OPDBill, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<OPDBill> IncludeProp<TProperty>(Expression<Func<OPDBill, TProperty>> property)
        {
            IQueryable<OPDBill> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<OPDBill> obj)
        {
            throw new NotImplementedException();
        }

        public OPDBill Update(OPDBill obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
