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
    public class AppointmentService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public AppointmentService(ApplicationDbContext db)
        {
            _dataAccessFactory = new DataAccessFactory(db);
        }
        public  List<AppointmentDTO> Get()
        {
            var data = _dataAccessFactory.AppointmentData().Get();
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Appointment, AppointmentDTO>();
                    c.CreateMap<Patient, PatientDTO>();
                    c.CreateMap<Doctor, DoctorDTO>();

                    //c.CreateMap<Doctor, DoctorDeptDTO>();
                    //c.CreateMap<Department, DepartmentDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<List<AppointmentDTO>>(data);

            }
            return null;
        }
        public  AppointmentDTO Get(int id)
        {
            var data = _dataAccessFactory.AppointmentData().Get(id);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Appointment, AppointmentDTO>();
                    c.CreateMap<Patient, PatientDTO>();
                    c.CreateMap<Doctor, DoctorDTO>();
                    //c.CreateMap<Doctor, DoctorDeptDTO>();
                    //c.CreateMap<Department, DepartmentDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<AppointmentDTO>(data);

            }
            return null;
        }

        public  bool Create(AppointmentDTO obj)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AppointmentDTO, Appointment>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Appointment>(obj);
            mapped.BookTime = DateTime.Now;
          //  mapped.Status = "Open";
            var res = _dataAccessFactory.AppointmentData().Add(mapped);
            return (res != null);
        }
        public  bool Update(AppointmentDTO obj)
        {
            var exist = _dataAccessFactory.AppointmentData().Get(obj.Id);
            var data = new Appointment()
            {
                Id = obj.Id,
                DoctorId = obj.DoctorId,
                PatientId = obj.PatientId,
                ScheduleDate = obj.ScheduleDate,
                ScheduleTime = obj.ScheduleTime,
                BookTime = DateTime.Now,
                Fee = exist.Fee,
                Status = obj.Status,
            };

            var res = _dataAccessFactory.AppointmentData().Update(data);
            return (res != null) ? true : false;

        }
        public  bool Delete(int id)
        {
            return (_dataAccessFactory.AppointmentData().Delete(id));
        }
        public  bool CancelAppointment(int id)
        {
            var existing = _dataAccessFactory.AppointmentData().Get(id);
            existing.Status = "Cancelled";
            var res = _dataAccessFactory.AppointmentData().Update(existing);
            return (res != null) ? true : false;
        }
        public  bool CloseAppointment(int id)
        {
            var existing = _dataAccessFactory.AppointmentData().Get(id);
            existing.Status = "Closed";
            var res = _dataAccessFactory.AppointmentData().Update(existing);
            return (res != null) ? true : false;
        }

        public  List<string> AvailableSlot(int DoctorId, DateTime ScheduleDate)
        {
            var booked = (from t in _dataAccessFactory.AppointmentData().Get()
                          where (t.DoctorId == DoctorId && t.ScheduleDate.Date == ScheduleDate.Date)
                       || (t.DoctorId == DoctorId && t.ScheduleDate == ScheduleDate && t.Status == "Cancelled")
                          select t).ToList();
            var schedules = _dataAccessFactory.DoctorScheduleData().Get();
            var available = schedules
                                .Where(ds => ds.DoctorId == DoctorId)
                                .Select(ds => ds.SlotTime)
                                .Except(booked.Select(a => a.ScheduleTime))
                                .ToList();
            return available;
        }

        public  byte[] PrintAppointment(int appointmentId)
        {
            var result = BLL.GeneratePDF.GetPDF("AppointmentDetails", Get(appointmentId));
            return result;
        }

    }
}
