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
    internal class UserRepo: IRepo<User, string, User>, IAuth<bool>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<User> dbSet;
        public UserRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<User>();
        }

        public User Add(User obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<User> Get()
        {
            IQueryable<User> query = dbSet;
            return query.ToList();
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<User> IncludeProp<TProperty>(Expression<Func<User, TProperty>> property)
        {
            IQueryable<User> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(string primaryKey)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(IEnumerable<User> obj)
        {
            throw new NotImplementedException();
        }

        public User Update(User obj)
        {
            var exObj = dbSet.Find(obj.Username);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

        public bool Authenticate(string Username, string Password)
        {
            var data = dbSet.AsQueryable().Where(u => u.Username.Equals(Username) && u.Password.Equals(Password)).FirstOrDefault();
            if (data != null) return true;
            return false;
        }
    }
}
