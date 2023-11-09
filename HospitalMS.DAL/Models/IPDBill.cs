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
    public class IPDBill
    {
       // [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("IPDAdmit")]
        public int IPDAdmitId { get; set; }
        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
       // [Required]
        
        public virtual IPDAdmit IPDAdmit { get; set; }
    }
}
