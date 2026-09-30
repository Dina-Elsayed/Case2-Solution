using Case2_Solution.Models;

namespace Case2_Solution.Repos.Interface
{
    public interface IAppointment : IGenericRepo<Appointment>
    {

        IEnumerable<Appointment> GetTodayAppointments();


    }
}
