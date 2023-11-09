﻿using HospitalMS.DAL.Interfaces;
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
    internal class PrescriptionRepo:IRepo<Prescription, int, Prescription>
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Prescription> dbSet;
        public PrescriptionRepo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<Prescription>();
        }

        public Prescription Add(Prescription obj)
        {
            dbSet.Add(obj);
            if (_db.SaveChanges() > 0) return obj;
            return null;
        }

        public IEnumerable<Prescription> Get()
        {
            IQueryable<Prescription> query = dbSet;
            return query.ToList();
        }

        public Prescription Get(Expression<Func<Prescription, bool>> filter)
        {
            var obj = dbSet.Where(filter).AsQueryable().FirstOrDefault();
            if (obj != null) return obj;
            return null;
        }

        public IEnumerable<Prescription> IncludeProp<TProperty>(Expression<Func<Prescription, TProperty>> property)
        {
            IQueryable<Prescription> query = dbSet.Include(property);
            return query.ToList();
        }

        public bool Remove(int primaryKey)
        {
            var exObj = dbSet.Find(primaryKey);
            dbSet.Remove(exObj);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveRange(IEnumerable<Prescription> obj)
        {
            throw new NotImplementedException();
        }

        public Prescription Update(Prescription obj)
        {
            var exObj = dbSet.Find(obj.Id);
            dbSet.Entry(exObj).CurrentValues.SetValues(obj);
            return _db.SaveChanges() > 0 ? obj : null;
        }

    }
}
