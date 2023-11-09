using AutoMapper;
using HospitalMS.BLL.DTOs;
using HospitalMS.DAL;
using HospitalMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.Services
{
    public class DepartmentService_TEMP
    {
        //private readonly ApplicationDbContext _db;
        private readonly DataAccessFactory _dataAccessFactory;
        public DepartmentService_TEMP(ApplicationDbContext db)
        {
            _dataAccessFactory = new DataAccessFactory(db);
        }
        public Department Get(Expression<Func<Department, bool>> filter)
        {
            var data = _dataAccessFactory.DepartmentData().Get(filter);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public List<DeptDoctorDTO> Get()
        {
            //var data = _dataAccessFactory.DepartmentData().Get().ToList();
            var data = _dataAccessFactory.DepartmentData().IncludeProp(u => u.Doctors).ToList();
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Department, DeptDoctorDTO>();
                    c.CreateMap<Doctor, DoctorDTO>();
                    // c.CreateMap<Staff, StaffDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<List<DeptDoctorDTO>>(data);
                return mapped;
            }
            return null;
        }

        public bool Create(Department dept)
        {
            var res = _dataAccessFactory.DepartmentData().Add(dept);
            return (res != null);
        }

        public bool Update(Department dept)
        {
            var res = _dataAccessFactory.DepartmentData().Update(dept);
            return (res != null) ? true : false;
        }

    }
}
