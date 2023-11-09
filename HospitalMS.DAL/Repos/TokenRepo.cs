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
    internal class TokenRepo : IRepo<Token, string, Token>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Token> dbSet;
        public TokenRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<Token>();
        }

        public Token Add(Token obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<Token> Get()
        {
            IQueryable<Token> query = dbSet;
            return query.ToList();
        }

        public Token Get(Expression<Func<Token, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<Token> IncludeProp<TProperty>(Expression<Func<Token, TProperty>> property)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string primaryKey)
        {
            throw new NotImplementedException();

        }

        public bool RemoveRange(IEnumerable<Token> obj)
        {
            throw new NotImplementedException();
        }

        public Token Update(Token obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
