using Case2_Solution.Models;

namespace Case2_Solution.Repos.Interface
{
    public interface IPatientRepo : IGenericRepo<Patient>
    {
        Patient GetPatientHistory(int patientId);  
    }
}
