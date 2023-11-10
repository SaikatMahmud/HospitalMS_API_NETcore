using HospitalMS.BLL.Services;
using HospitalMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _db;
       // public DepartmentService_TEMP Department { get; private set; }
        public AdminDashboardService AdminDashboard { get; private set; }
        public AppointmentService Appointment { get; private set; }
        public AuthService Auth { get; private set; }
        public DepartmentService Department { get; private set; }
        public DoctorService Doctor { get; private set; }
        public LeaveApplicationService LeaveApplication { get; private set; }
        public OPDBillDetailService OPDBillDetails { get; private set; }
        public OPDBillService OPDBill { get; private set; }
        public PatientService Patient { get; private set; }
        public StaffService Staff { get; private set; }
        public StatService Stat { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            AdminDashboard = new AdminDashboardService(_db);
            Appointment = new AppointmentService(_db);
            Auth = new AuthService(_db);
            Department = new DepartmentService(_db);
            Doctor = new DoctorService(_db);
            LeaveApplication = new LeaveApplicationService(_db);
            OPDBillDetails = new OPDBillDetailService(_db);
            OPDBill = new OPDBillService(_db);
            Patient = new PatientService(_db);
            Staff = new StaffService(_db);
            Stat = new StatService(_db);
        }

    }
}
