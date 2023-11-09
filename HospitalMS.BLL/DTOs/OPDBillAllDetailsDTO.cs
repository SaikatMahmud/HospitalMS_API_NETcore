using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class OPDBillAllDetailsDTO
    {
        public int OPDBillId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public string BillDate { get; set; }
        public string Status { get; set; }
        public List<DiagInfo> DiagInfo { get; set; }

    }
    public class DiagInfo
    {
        public int Amount { get; set; }
        public string DiagnosisName { get; set; }
    }
}
