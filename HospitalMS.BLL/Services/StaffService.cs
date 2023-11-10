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
    public class StaffService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public StaffService(ApplicationDbContext db)
        {
            _dataAccessFactory = new DataAccessFactory(db);
        }
        public  List<StaffDTO> Get()
        {
            var data = _dataAccessFactory.StaffData().Get();
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Staff, StaffDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<List<StaffDTO>>(data);
            }
            return null;
        }
        public  StaffDTO Get(int id)
        {
            var data = _dataAccessFactory.StaffData().Get(s=> s.Id == id);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Staff, StaffDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<StaffDTO>(data);
            }
            return null;
        }

        public  bool Create(StaffDTO staff)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<StaffDTO, Staff>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Staff>(staff);
            var res = _dataAccessFactory.StaffData().Add(mapped);
            return (res != null);
        }
        public  bool Update(StaffDTO staff)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<StaffDTO, Staff>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Staff>(staff);
            var res = _dataAccessFactory.StaffData().Update(mapped);
            return (res != null) ? true : false;

        }
        public  bool Delete(int id)
        {
            return (_dataAccessFactory.StaffData().Remove(id));
        }
    }
}
