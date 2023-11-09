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
    internal class IPDAdmitRepo: IRepo<IPDAdmit, int, IPDAdmit>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<IPDAdmit> dbSet;
        public IPDAdmitRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<IPDAdmit>();
        }

        public IPDAdmit Add(IPDAdmit obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<IPDAdmit> Get()
        {
            IQueryable<IPDAdmit> query = dbSet;
            return query.ToList();
        }

        public IPDAdmit Get(Expression<Func<IPDAdmit, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<IPDAdmit> IncludeProp<TProperty>(Expression<Func<IPDAdmit, TProperty>> property)
        {
            IQueryable<IPDAdmit> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<IPDAdmit> obj)
        {
            throw new NotImplementedException();
        }

        public IPDAdmit Update(IPDAdmit obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
