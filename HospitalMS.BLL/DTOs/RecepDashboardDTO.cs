using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class RecepDashboardDTO
    {
        public string DeptName { get; set; }
        public int TotalDoctor { get; set; }
        public int AvailableDoctor { get; set; }
        public int DeptId { get; set; }
    }
}
