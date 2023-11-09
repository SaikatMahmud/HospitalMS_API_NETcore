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
    public class IPDAdmit
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[ForeignKey("IPDBill")]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int NightCount { get; set; }
        public int? CabinId { get; set; }
        public int? WardId { get; set; }
        [StringLength(15)]
        public string Status { get; set; }
        public DateTime AdmitDate { get; set; }
        [ForeignKey("WardId")]
        public virtual Ward Ward { get; set; }
        [ForeignKey("CabinId")]
        public virtual Cabin Cabin { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        public virtual ICollection<IPDBill> IPDBills { get; set; }
      

    }
}
