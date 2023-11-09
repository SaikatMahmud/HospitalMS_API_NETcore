using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class StatDTO
    {
        public string Month { get; set; }
        public int? OPDPtCount { get; set; }
        public int? IPDPtCount { get; set; }
        public String DoctorName { get; set; }
        public int? OPDVisitDCount { get; set; }
        public int? CurrentMnOPDrv { get; set; }
        public int? CurrentMnIPDrv { get; set; }


    }
}
