using AutoMapper;
using HospitalMS.BLL.DTOs;
using HospitalMS.DAL;
using HospitalMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.Services
{
    public class AdminDashboardService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public AdminDashboardService(ApplicationDbContext db)
        {
            _dataAccessFactory = new DataAccessFactory(db);
        }
        public AdminDashboardDTO DashboardInfo()
        {
            var doctor = _dataAccessFactory.DoctorData().Get();
            var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Doctor, DoctorDTO>();
                });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<DoctorDTO>>(doctor);
            foreach (var d in mapped)
            {
                DateTime stayFrom = DateTime.ParseExact(d.StayFrom, "h:mm tt", CultureInfo.InvariantCulture);
                DateTime stayTill = DateTime.ParseExact(d.StayTill, "h:mm tt", CultureInfo.InvariantCulture);
                DateTime currentTime = DateTime.ParseExact(DateTime.Now.ToString("hh:mm tt"), "h:mm tt", CultureInfo.InvariantCulture);
                if (currentTime >= stayFrom && currentTime <= stayTill)
                {
                    d.IsAvailable = true;
                }
                else { d.IsAvailable = false; }
            }

            var patient = _dataAccessFactory.PatientData().Get();
            var dept = _dataAccessFactory.DepartmentData().Get();
            var staff = _dataAccessFactory.StaffData().Get();

            var cabin = _dataAccessFactory.CabinData().Get();
            var bookedCabin = _dataAccessFactory.IPDAdmitData().Get();

            var availableCabin = cabin
                .Where(c => !bookedCabin.Any(b => b.CabinId == c.Id && b.Status == "Booked"))
                .Select(c => c.Id)
                .ToList();
            // today's revenue vs paid amount
            var totalAmount = _dataAccessFactory.OPDBillData().Get().Sum(x => x.BillAmount);
            totalAmount += _dataAccessFactory.IPDBillData().Get().Sum(x => x.TotalAmount);
            var totalPaid = _dataAccessFactory.OPDBillData().Get().Sum(x => x.PaidAmount);
            totalPaid += _dataAccessFactory.IPDBillData().Get().Sum(x => x.PaidAmount);
            var result = new AdminDashboardDTO()
            {
                TotalDoctor = mapped.Count(),
                AvailableDoctor = mapped.Count(x => x.IsAvailable == true),
                RegisteredPatient = patient.Count(),
                TotalDept = dept.Count(),
                TotalStaff = staff.Count(),
                TotalCabin = cabin.Count(),
                AvailableCabin = availableCabin.Count(),
                TodayTotalAmount = totalAmount,
                TodayTotalPaid = totalPaid

            };
            return result;

        }
    }
}
