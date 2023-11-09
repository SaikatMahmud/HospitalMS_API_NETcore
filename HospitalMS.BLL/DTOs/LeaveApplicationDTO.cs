using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class LeaveApplicationDTO
    {
        public int? Id { get; set; }
        public string TokenKey { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string Details { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTill { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Status { get; set; }
        public virtual StaffDTO Staff { get; set; }
    }
}
