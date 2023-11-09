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
    public class OPDBillDetails
    {
        public int Id { get; set; }
        public int OPDBillId { get; set; }
        public int? DoctorId { get; set; }
        public float Amount { get; set; }
        public int Discount { get; set; }
        // public int AppointmentId { get; set; }
        public string BillType { get; set; } //doctor fee, diag cost etc
        public int? PerformDiagId { get; set; }

        [ForeignKey("OPDBillId")]
        public virtual OPDBill OPDBill { get; set; }
        [ForeignKey("PerformDiagId")]
        public virtual PerformDiag PerformDiag { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
    }
}
