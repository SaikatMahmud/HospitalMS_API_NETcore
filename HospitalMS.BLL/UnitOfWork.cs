using HospitalMS.BLL.Services;
using HospitalMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public DepartmentService Department { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Department = new DepartmentService(_db);
        }

    }
}
