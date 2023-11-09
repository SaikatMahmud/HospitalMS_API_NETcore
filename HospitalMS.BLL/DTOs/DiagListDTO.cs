using HospitalMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.DTOs
{
    public class DiagListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int DeptId { get; set; }
        public Department Department { get; set; }
      //  public List<PerformDiag> PerformDiags { get; set; }
      
    }
}
