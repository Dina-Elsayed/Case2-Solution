using Case2_Solution.Data;
using Case2_Solution.Models;
using Case2_Solution.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Case2_Solution.Repos.Implementation
{
    public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
    {

        private readonly AppDbContext _context;

        public DepartmentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetDepartmentsWithDoctorCount()
        {
            return _context.Departments.Include(d=>d.Doctors).ToList();
        }
    }
}
