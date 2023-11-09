using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class OPDBillDetailsDTO
    {
        public int Id { get; set; }
        public int OPDBillId { get; set; }
        public int? DoctorId { get; set; }
        public int Amount { get; set; }
        public int Discount { get; set; }
        public string BillType { get; set; } //doctor fee, diag cost etc
        public int? PerformDiagId { get; set; }
      
    }
}
