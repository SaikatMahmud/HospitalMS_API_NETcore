using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class PatientInfoDTO : PatientDTO
    {
        public int Age { get; set; }
        public int OPDCount { get; set; }
        public int IPDCount { get; set; }
        public int TotalPaid { get; set; }
    }
}
