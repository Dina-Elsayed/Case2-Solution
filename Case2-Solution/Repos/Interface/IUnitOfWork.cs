namespace Case2_Solution.Repos.Interface
{
    public interface IUnitOfWork
    {
        IDepartmentRepo DepartmentRepo { get; }
        
        IDoctorRepo DoctorRepo { get; }

        IPatientRepo PatientRepo { get; }

        int Save();
    }
}
