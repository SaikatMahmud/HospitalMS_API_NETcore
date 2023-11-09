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
    public class DoctorsSchedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string SlotTime { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
