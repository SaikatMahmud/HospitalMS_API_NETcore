using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class StaffDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public string Username { get; set; }
        public string Type { get; set; }
        public int DeptId { get; set; }
        public int Salary { get; set; }
    }
}
