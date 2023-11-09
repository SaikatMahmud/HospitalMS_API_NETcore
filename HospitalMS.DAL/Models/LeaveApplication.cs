using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.DAL.Models
{
    public class LeaveApplication
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Details { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTill { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Status { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }

    }
}
