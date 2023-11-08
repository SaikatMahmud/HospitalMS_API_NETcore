using HospitalMS.DAL.Interfaces;
using HospitalMS.DAL.Models;
using HospitalMS.DAL.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.DAL
{
    public class DataAccessFactory
    {
        private readonly ApplicationDbContext _db;
        public DataAccessFactory(ApplicationDbContext db)
        {
            _db = db;
        }

        public IRepo<Department, int, bool> DepartmentData()
        {
            return new DepartmentRepo(_db);
        }
    }
}
