using Case2_Solution.Data;
using Case2_Solution.Models;
using Case2_Solution.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Case2_Solution.Repos.Implementation
{
    public class DoctorRepo : GenericRepo<Doctor>, IDoctorRepo
    {


        private readonly AppDbContext _context;

        public DoctorRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetBySpecialization(string specialization)
        {
            return _context.Doctors
                .Where(x => x.Specialization == specialization)
                .ToList();
        }

        public IEnumerable<Doctor> GetDetails()
        {
            return _context.Doctors
                .Include(d => d.Department)
                .ToList();
        }
    }
}
