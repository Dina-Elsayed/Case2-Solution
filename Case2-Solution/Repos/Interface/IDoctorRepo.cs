using Case2_Solution.Models;

namespace Case2_Solution.Repos.Interface
{
    public interface IDoctorRepo : IGenericRepo<Doctor>
    {

        IEnumerable<Doctor> GetBySpecialization(string specialization);

        IEnumerable<Doctor> GetDetails();
    }
}
