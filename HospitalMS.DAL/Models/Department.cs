using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.DAL.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required, StringLength(40)]
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

        public Department()
        {
            Doctors = new List<Doctor>();
        }
    }
}
