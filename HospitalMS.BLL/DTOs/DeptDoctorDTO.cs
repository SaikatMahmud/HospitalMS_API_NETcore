using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class DeptDoctorDTO : DepartmentDTO
    {
       public List<DoctorDTO> Doctors { get; set; }
      //  public DepartmentDTO Department { get; set; }
    }
}
