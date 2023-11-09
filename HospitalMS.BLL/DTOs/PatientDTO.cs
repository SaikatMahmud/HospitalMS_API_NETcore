using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }

        //public List<Prescription> Prescriptions { get; set; }
        //public List<Appointment> Appointments { get; set; }
        //public List<IPDAdmit> IPDAdmits { get; set; }
        //public List<PerformDiag> PerformDiags { get; set; }
        //public List<OPDBill> OPDBills { get; set; }
        //public List<Complaint> Complaints { get; set; }
    }
}
