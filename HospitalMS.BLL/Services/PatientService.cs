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
    public class PatientService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public PatientService(ApplicationDbContext db)
        {
            _dataAccessFactory = new DataAccessFactory(db);
        }
        public  List<PatientDTO> Get()
        {
            var data = _dataAccessFactory.PatientData().Get();
            return Convert(data.ToList());
        }
        public  List<PatientDTO> GetPatients()
        {
            var data = _dataAccessFactory.PatientData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Patient, PatientDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<PatientDTO>>(data);
        }
        public  PatientDTO Get(int id)
        {
            return Convert(_dataAccessFactory.PatientData().Get(p=>p.Id == id));
        }

        public  bool Create(PatientDTO patient)
        {
            var data = Convert(patient);
            var res = _dataAccessFactory.PatientData().Add(data);

            if (res != null)
            {
                var user = new User()
                {
                    Username = patient.Username,
                    Password = Guid.NewGuid().ToString().Substring(0, 5),
                    Type = "Patient"
                };
                _ = Task.Run(() => SendEmail.SendNewUserEmail(patient.Email, user.Password, user.Type));
                _dataAccessFactory.UserData().Add(user);


                return true;
            }
            return false;
        }
        public  bool Update(PatientDTO patient)
        {
            var data = Convert(patient);
            var res = _dataAccessFactory.PatientData().Update(data);

            if (res != null) return true;
            return false;
        }
        public  bool Delete(int id)
        {
            return (_dataAccessFactory.PatientData().Remove(id));
        }

        public  int OPDCount(int PatientId)
        {
            int count = 0;
            var OPDbills = _dataAccessFactory.OPDBillData().Get();
            count = OPDbills.Count(c => c.PatientId == PatientId);
            return count;
        }
        public  int IPDCount(int PatientId)
        {
            int count = 0;
            var IPDadmits = _dataAccessFactory.IPDAdmitData().Get();
            count = IPDadmits.Count(c => c.PatientId == PatientId);
            return count;
        }
        public  int TotalPaid(int PatientID)
        {
            int amount = 0;
            var PaidOPD = _dataAccessFactory.OPDBillData().Get();
            var PaidIPD = _dataAccessFactory.IPDBillData().Get();
            amount += (from p in PaidOPD where p.PatientId.Equals(PatientID) select p.PaidAmount).Sum();
            amount += (from p in PaidIPD where p.PatientId.Equals(PatientID) select p.PaidAmount).Sum();
            //amount = PaidOPD.Sum(p => p.Paid)
            return amount;
        }
        public  int CalculateAge(DateTime Dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - Dob.Year;
            if (today < Dob.AddYears(age)) age--;
            return age;
        }


         List<PatientDTO> Convert(List<Patient> patients)
        {
            var data = new List<PatientDTO>();
            foreach (var patient in patients)
            {
                data.Add(new PatientInfoDTO()
                {
                    Id = patient.Id,
                    Name = patient.Name,
                    DOB = patient.DOB,
                    Gender = patient.Gender,
                    BloodGroup = patient.BloodGroup,
                    Mobile = patient.Mobile,
                    Email = patient.Email,
                    Address = patient.Address,
                    Username = patient.Username,
                    OPDCount = OPDCount(patient.Id),
                    IPDCount = IPDCount(patient.Id),
                    TotalPaid = TotalPaid(patient.Id),
                    Age = CalculateAge(patient.DOB),
                    //Prescriptions = patient.Prescriptions.ToList(),
                    //Appointments = patient.Appointments.ToList(),
                    //IPDAdmits = patient.IPDAdmits.ToList(),
                    //PerformDiags = patient.PerformDiags.ToList(),
                    //OPDBills = patient.OPDBills.ToList(),
                    //Complaints = patient.Complaints.ToList(),
                });
            }
            return data;

        }
         Patient Convert(PatientDTO patient)
        {
            return new Patient()
            {
                Id = patient.Id,
                Name = patient.Name,
                DOB = patient.DOB,
                Gender = patient.Gender,
                BloodGroup = patient.BloodGroup,
                Mobile = patient.Mobile,
                Email = patient.Email,
                Address = patient.Address,
                Username = patient.Username,
            };
        }
         PatientDTO Convert(Patient patient)
        {
            return new PatientInfoDTO()
            {
                Id = patient.Id,
                Name = patient.Name,
                DOB = patient.DOB,
                Gender = patient.Gender,
                BloodGroup = patient.BloodGroup,
                Mobile = patient.Mobile,
                Email = patient.Email,
                Address = patient.Address,
                Username = patient.Username,
                OPDCount = OPDCount(patient.Id),
                IPDCount = IPDCount(patient.Id),
                TotalPaid = TotalPaid(patient.Id),
                Age = CalculateAge(patient.DOB),


                //Prescriptions = patient.Prescriptions.ToList(),
                //Appointments = patient.Appointments.ToList(),
                //IPDAdmits = patient.IPDAdmits.ToList(),
                //PerformDiags = patient.PerformDiags.ToList(),
                //OPDBills = patient.OPDBills.ToList(),
                //Complaints = patient.Complaints.ToList(),
            };
        }
    }
}
