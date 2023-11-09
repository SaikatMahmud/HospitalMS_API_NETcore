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
    public class Ward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BedCout { get; set; }
        public int Rent { get; set; }
        public virtual ICollection<IPDAdmit> IPDAdmits { get; set; }
        public Ward()
        {
            IPDAdmits = new List<IPDAdmit>();
        }
    }
}
