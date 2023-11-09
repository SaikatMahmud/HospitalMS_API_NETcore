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
    public class Cabin
    {
        public int Id { get; set; }
        public int CabinNo { get; set; }
        public int PatientBed { get; set; }
        public int GuestBed { get; set; }
        public int Rent { get; set; }
        public string Category { get; set; }
        public virtual ICollection<IPDAdmit> IPDAdmits { get; set; }

    }
}
