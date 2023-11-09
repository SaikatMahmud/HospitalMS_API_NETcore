using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class OPDBillDTO
    {
        public int Id { get; set; }
        public int BillAmount { get; set; }
        public int PaidAmount { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Status { get; set; }
        public int[] DiagId { get; set; }
        public DateTime BillDate { get; set; }
       public List<OPDBillDetailsDTO> OPDBillDetails { get; set; }
      
       // public  Patient Patient { get; set; }
      //  public List<OPDBillDetailsDTO> OPDBillDetails { get; set; }
       
    }
}
