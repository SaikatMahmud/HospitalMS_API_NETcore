using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.DAL.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required, StringLength(15)]
        public string Gender { get; set; }
        [Required, StringLength(5)]
        public string BloodGroup { get; set; }
        [Required, StringLength(20)]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<IPDAdmit> IPDAdmits { get; set; }
        public virtual ICollection<PerformDiag> PerformDiags { get; set; }
        public virtual ICollection<OPDBill> OPDBills { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
      
    }
}
