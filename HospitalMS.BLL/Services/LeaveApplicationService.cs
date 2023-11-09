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
    public class LeaveApplicationService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public LeaveApplicationService(ApplicationDbContext db)
        {
            _dataAccessFactory = new DataAccessFactory(db);
        }
        public  List<LeaveApplicationDTO> Get()
        {
            var data = _dataAccessFactory.LeaveApplicationData().Get();
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<LeaveApplication, LeaveApplicationDTO>();
                    c.CreateMap<Staff, StaffDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<List<LeaveApplicationDTO>>(data);
                foreach (var item in mapped)
                {
                    item.StaffName = item.Staff.Name;
                }
                return mapped;
            }
            return null;
        }
        public  LeaveApplicationDTO Get(int id)
        {
            var data = _dataAccessFactory.LeaveApplicationData().Get(id);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<LeaveApplication, LeaveApplicationDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<LeaveApplicationDTO>(data);
            }
            return null;
        }
        public  bool Create(LeaveApplicationDTO la)
        {
            la.ApplyDate = DateTime.Now;
            la.Status = "Pending";
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<LeaveApplicationDTO, LeaveApplication>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<LeaveApplication>(la);
            var res = _dataAccessFactory.LeaveApplicationData().Create(mapped);
            return (res != null);
        }
        public  bool Update(LeaveApplicationDTO la)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<LeaveApplicationDTO, LeaveApplication>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<LeaveApplication>(la);
            var res = _dataAccessFactory.LeaveApplicationData().Update(mapped);
            return (res != null) ? true : false;

        }

        public  bool ApproveApplication(int id)
        {
            var existing = _dataAccessFactory.LeaveApplicationData().Get(id);
            existing.Status = "Approved";
            var res = _dataAccessFactory.LeaveApplicationData().Update(existing);
            return (res != null) ? true : false;
        }
        public  bool RejectApplication(int id)
        {
            var existing = _dataAccessFactory.LeaveApplicationData().Get(id);
            existing.Status = "Rejected";
            var res = _dataAccessFactory.LeaveApplicationData().Update(existing);
            return (res != null) ? true : false;
        }

        public  bool Delete(int id)
        {
            return (_dataAccessFactory.LeaveApplicationData().Delete(id));
        }
    }

}
