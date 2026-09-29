using Case2_Solution.Data;
using Case2_Solution.Models;
using Case2_Solution.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Case2_Solution.Repos.Implementation
{
    public class  PatientRepo: GenericRepo<Patient>, IPatientRepo
    {

        private readonly AppDbContext _context;

        public PatientRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Patient GetPatientHistory(int patientId)
        {
           return  _context.Patients
                .Include(p=>p.Appointments)
                .ThenInclude(a=>a.Doctor)
                .FirstOrDefault(p=>p.Id== patientId);





        }
    }
}
