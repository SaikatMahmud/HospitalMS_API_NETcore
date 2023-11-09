using HospitalMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DiagList> DiagLists { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<IPDAdmit> IPDAdmits { get; set; }
        public DbSet<IPDBill> IPDBills { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
        public DbSet<OPDBill> OPDBills { get; set; }
        public DbSet<OPDBillDetails> OPDBillDetails { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PerformDiag> PerformDiags { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<DoctorsSchedule> DoctorsSchedules { get; set; }
    }
}
