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
    public class DepartmentService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public DepartmentService(ApplicationDbContext db)
        {
            _dataAccessFactory = new DataAccessFactory(db);
        }
        public List<DeptDocStaffDTO> Get()
        {
            var data = _dataAccessFactory.DepartmentData().IncludeProp(d => d.Doctors);
            data = _dataAccessFactory.DepartmentData().IncludeProp(d => d.Staffs);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Department, DeptDocStaffDTO>();
                    c.CreateMap<Doctor, DoctorDTO>();
                    c.CreateMap<Staff, StaffDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<List<DeptDocStaffDTO>>(data);
                return mapped;
            }
            return null;
        }
        //public  DeptDocStaffDTO Get(int id)
        //{
        //    var data = _dataAccessFactory.DepartmentData().Get(id);
        //    if (data != null)
        //    {
        //        var cfg = new MapperConfiguration(c =>
        //        {
        //            c.CreateMap<Department, DeptDocStaffDTO>();
        //            c.CreateMap<Doctor, DoctorDTO>();
        //            // c.CreateMap<Staff, StaffDTO>();
        //        });
        //        var mapper = new Mapper(cfg);
        //        var mapped = mapper.Map<DeptDocStaffDTO>(data);
        //        return mapped;
        //    }
        //    return null;
        //}
        public DepartmentDTO Get(int id)
        {
            var data = _dataAccessFactory.DepartmentData().Get(d => d.Id == id);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Department, DepartmentDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<DepartmentDTO>(data);
            }
            return null;
        }

        public bool Create(DepartmentDTO dept)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DepartmentDTO, Department>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Department>(dept);
            var res = _dataAccessFactory.DepartmentData().Add(mapped);
            return (res != null);
        }
        public bool Update(DepartmentDTO dept)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DepartmentDTO, Department>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Department>(dept);
            var res = _dataAccessFactory.DepartmentData().Update(mapped);
            return (res != null) ? true : false;

        }
        public bool Delete(int id)
        {
            return (_dataAccessFactory.DepartmentData().Remove(id));
        }
    }
}
