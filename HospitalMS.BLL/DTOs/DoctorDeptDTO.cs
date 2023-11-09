using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class DoctorDeptDTO:DoctorDTO
    {
        public DepartmentDTO Department { get; set; }
    }
}
