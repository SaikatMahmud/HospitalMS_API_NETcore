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
    public class Token
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string TKey { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        [Required]
        public string CreatedBy { get; set; }

    }
}
