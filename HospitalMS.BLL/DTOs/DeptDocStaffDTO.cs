using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class DeptDocStaffDTO : DepartmentDTO
    {
        public List<DoctorDTO> Doctors { get; set; }
        public List<StaffDTO> Staffs { get; set; }
        public DeptDocStaffDTO()
        {
            Doctors = new List<DoctorDTO>();
            Staffs = new List<StaffDTO>();
        }
    }
}
