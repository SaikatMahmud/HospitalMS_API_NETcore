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
    public class DoctorService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public DoctorService(ApplicationDbContext db)
        {
            _dataAccessFactory = new DataAccessFactory(db);
        }
        public  List<DoctorDeptDTO> Get()
        {
            var data = _dataAccessFactory.DoctorData().Get();
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Doctor, DoctorDeptDTO>();
                    c.CreateMap<Department, DepartmentDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<List<DoctorDeptDTO>>(data);
                DateTime currentTime = DateTime.ParseExact(DateTime.Now.ToString("hh:mm tt"), "h:mm tt", CultureInfo.InvariantCulture);
                foreach (var doctor in mapped)
                {
                    DateTime stayFrom = DateTime.ParseExact(doctor.StayFrom, "h:mm tt", CultureInfo.InvariantCulture);
                    DateTime stayTill = DateTime.ParseExact(doctor.StayTill, "h:mm tt", CultureInfo.InvariantCulture);
                    if (currentTime >= stayFrom && currentTime <= stayTill)
                    {
                        doctor.IsAvailable = true;
                    }
                    else { doctor.IsAvailable = false; }
                }
                    return mapped;
            }
            return null;
        }
        public  DoctorDTO Get(int id)
        {
            var data = _dataAccessFactory.DoctorData().Get(id);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Doctor, DoctorDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<DoctorDTO>(data);
                DateTime stayFrom = DateTime.ParseExact(mapped.StayFrom, "h:mm tt", CultureInfo.InvariantCulture);
                DateTime stayTill = DateTime.ParseExact(mapped.StayTill, "h:mm tt", CultureInfo.InvariantCulture);
                DateTime currentTime = DateTime.ParseExact(DateTime.Now.ToString("hh:mm tt"), "h:mm tt", CultureInfo.InvariantCulture);
                if (currentTime >= stayFrom && currentTime <= stayTill)
                {
                    mapped.IsAvailable = true;
                }
                else { mapped.IsAvailable = false; }
                return mapped;
            }
            return null;
        }

        public  bool Create(DoctorDTO doctor)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DoctorDTO, Doctor>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Doctor>(doctor);
            var res = _dataAccessFactory.DoctorData().Create(mapped);
            return (res != null);
        }
        public  bool Update(DoctorDTO doctor)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DoctorDTO, Doctor>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Doctor>(doctor);
            var res = _dataAccessFactory.DoctorData().Update(mapped);
            return (res != null) ? true : false;

        }
        public  bool Delete(int id)
        {
            return (_dataAccessFactory.DoctorData().Delete(id));
        }

        public  List<RecepDashboardDTO> RecepDeptWiseDoctor()
        {
            var dept = _dataAccessFactory.DepartmentData().Get();
            var doctor = Get();
           
            var fetched = doctor
                        .GroupBy(x => x.Department.Id)
                        .Select(g => new
                        {
                            DeptId = g.Key,
                            DeptName = g.FirstOrDefault().Department.Name ,
                            totalDoctor = g.Count(),
                            availableDoctor = g.Count(x => x.IsAvailable == true)
                        }).ToList();
            var result = fetched.Select(x => new RecepDashboardDTO
            {
               DeptId = x.DeptId,
               DeptName = x.DeptName,
               TotalDoctor = x.totalDoctor,
               AvailableDoctor = x.availableDoctor
            }).ToList();
            return result; 
        }

        public  List<DoctorDeptDTO> DoctorOfDept(int DeptId)
        {
            var data = (from d in _dataAccessFactory.DoctorData().Get() where d.DeptId == DeptId select d).ToList();
            
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Doctor, DoctorDeptDTO>();
                    c.CreateMap<Department, DepartmentDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<List<DoctorDeptDTO>>(data);
                DateTime currentTime = DateTime.ParseExact(DateTime.Now.ToString("hh:mm tt"), "h:mm tt", CultureInfo.InvariantCulture);
                foreach (var doctor in mapped)
                {
                    DateTime stayFrom = DateTime.ParseExact(doctor.StayFrom, "h:mm tt", CultureInfo.InvariantCulture);
                    DateTime stayTill = DateTime.ParseExact(doctor.StayTill, "h:mm tt", CultureInfo.InvariantCulture);
                    if (currentTime >= stayFrom && currentTime <= stayTill)
                    {
                        doctor.IsAvailable = true;
                    }
                    else { doctor.IsAvailable = false; }
                }
                return mapped;
            }
            return null;
        }
    }
}
