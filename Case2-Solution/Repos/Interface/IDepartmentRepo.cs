using Case2_Solution.Models;

namespace Case2_Solution.Repos.Interface
{
    public interface IDepartmentRepo : IGenericRepo<Department>
    {

        IEnumerable<Department> GetDepartmentsWithDoctorCount();
    }
}
