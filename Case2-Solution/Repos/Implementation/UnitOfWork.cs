using Case2_Solution.Data;
using Case2_Solution.Repos.Interface;

namespace Case2_Solution.Repos.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        public IDepartmentRepo DepartmentRepo { get; }

        public IDoctorRepo DoctorRepo { get;}

        public IPatientRepo PatientRepo { get; }

        public IAppointment AppointmentRepo {  get; }

        public UnitOfWork(AppDbContext context, IDepartmentRepo departmentRepo, IDoctorRepo doctorRepo, IPatientRepo patientRepo, IAppointment appointmentRepo)
        {
            _context = context;
            DepartmentRepo = departmentRepo;
            DoctorRepo = doctorRepo;
            PatientRepo = patientRepo;
            AppointmentRepo = appointmentRepo ;


        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
