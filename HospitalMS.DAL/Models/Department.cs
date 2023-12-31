﻿using System;
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
    public class Department
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
        public virtual ICollection<DiagList> DiagLists { get; set; }
       

    }
}

