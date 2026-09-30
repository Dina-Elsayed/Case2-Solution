using Case2_Solution.Data;
using Case2_Solution.Models;
using Case2_Solution.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Case2_Solution.Repos.Implementation
{
    public class AppointmentRepo : GenericRepo<Appointment>, IAppointment
    {
        private readonly AppDbContext _context;

        public AppointmentRepo(AppDbContext context) : base(context)
        {

            _context = context;
        }

        public IEnumerable<Appointment> GetTodayAppointments()
        {
            var today = DateTime.Today;

            return _context.Appointments
                .Include(a=>a.Doctor)
                .Include(a=>a.Patient)
                .Where(a=>a.AppoinmentDate == today).ToList();



        }
    }
}
