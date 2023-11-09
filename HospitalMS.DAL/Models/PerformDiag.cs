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
    public class PerformDiag // diagnosis performed of patients
    {

        [Key]
      // [ForeignKey("OPDBillDetails")]
        public int Id { get; set; }
        // public int OPDBillDetailsId { get; set; }
        public int PatientId { get; set; }
        public int DiagId { get; set; } //diagnosis id from the available diag list
                                        //  public float Amount { get; set; }
        public int Cost { get; set; }
        public string StoragePath { get; set; } //need review
        [Required, StringLength(10)]
        public string Status { get; set; }
        public DateTime? DeliverDate { get; set; }
        [ForeignKey("DiagId")]
        public virtual DiagList DiagList { get; set; }
       // public virtual OPDBillDetails OPDBillDetails { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

    }
}
