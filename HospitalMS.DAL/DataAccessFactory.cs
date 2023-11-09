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

       public IRepo<Patient, int, Patient> PatientData()
        {
            return new PatientRepo(_db);
        }
        public IRepo<Doctor, int, Doctor> DoctorData()
        {
            return new DoctorRepo(_db);
        } 
        public IRepo<Appointment, int, Appointment> AppointmentData()
        {
            return new AppointmentRepo(_db);
        }
        public IRepo<Staff, int, Staff> StaffData()
        {
            return new StaffRepo(_db);
        }
        public IRepo<DoctorsSchedule, int, DoctorsSchedule> DoctorScheduleData()
        {
            return new DoctorsScheduleRepo(_db);
        }
        public IRepo<OPDBill, int, OPDBill> OPDBillData()
        {
            return new OPDBillRepo(_db);
        }
        public IRepo<OPDBillDetails, int, OPDBillDetails> OPDBillDetailsData()
        {
            return new OPDBillDetailsRepo(_db);
        }
        public IRepo<IPDAdmit, int, IPDAdmit> IPDAdmitData()
        {
            return new IPDAdmitRepo(_db);
        }
        public IRepo<IPDBill, int, IPDBill> IPDBillData()
        {
            return new IPDBillRepo(_db);
        }
        public IRepo<Department, int, bool> DepartmentData()
        {
            return new DepartmentRepo(_db);
        }
        public IRepo<Cabin, int, Cabin> CabinData()
        {
            return new CabinRepo(_db);
        }
        public IRepo<LeaveApplication, int, LeaveApplication> LeaveApplicationData()
        {
            return new LeaveApplicationRepo(_db);
        }

        public IRepo<DiagList, int, DiagList> DiagListData()
        {
            return new DiagListRepo(_db);
        }
        public IRepo<PerformDiag, int, PerformDiag> PerformDiagData()
        {
            return new PerformDiagRepo(_db);
        }
        public IAuth<bool> AuthData()
        {
            return new UserRepo(_db);
        }
        public IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo(_db);
        }
        public IRepo<User, string, User> UserData()
        {
            return new UserRepo(_db);
        }
    }
}
