using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class PerformDiagDTO
    {
        public int Id { get; set; }
        // public int OPDBillDetailsId { get; set; }
        public int PatientId { get; set; }
        public int DiagId { get; set; } //diagnosis id from the available diag list
                                        //  public float Amount { get; set; }
        public int Cost { get; set; }
        public string StoragePath { get; set; } //need review
        public string Status { get; set; }
        public DateTime DeliverDate { get; set; }
        public DiagListDTO DiagList { get; set; }

        //public virtual OPDBillDetails OPDBillDetails { get; set; }
        //public virtual Patient Patient { get; set; }
    }
}
