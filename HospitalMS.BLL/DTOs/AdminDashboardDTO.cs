using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class AdminDashboardDTO
    {
        public int? TotalDoctor { get; set; }
        public int? AvailableDoctor { get; set; }
        public int? RegisteredPatient { get; set; }
        public int? TotalDept { get; set; }
        public int? TotalStaff { get; set; }
        public int? TotalCabin { get; set; }
        public int? AvailableCabin { get; set; }
        public int TodayTotalAmount { get; set; }
        public int TodayTotalPaid { get; set; }
    }
}
