using Case2_Solution.Models;
using Case2_Solution.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Case2_Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public AppointmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpGet("today")]
        public IActionResult GetTodayAppointments()
        {
            var result =  _unitOfWork.AppointmentRepo.GetTodayAppointments()
                .Select(a => new
                {
                   ID =  a.Id,
                   AppoinmentDate = a.AppoinmentDate,
                   DoctorName = a.Doctor.FullName,
                   PatientName = a.Patient.FullName
                });

            return Ok(result);

        }
    }
}
