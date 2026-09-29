using Case2_Solution.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Case2_Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public PatientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetPatients()
        {
            var patients =  _unitOfWork.PatientRepo.GetAll();


            var result = patients.Select(p => new 
            {
                Id = p.Id,
                FullName = p.FullName,
                Gender = p.Gender,
                DateOfBirth = p.DateOfBirth,
                Phone = p.Phone,
                Address = p.Address
            });

            return Ok(result);
        }

        [HttpGet("History/{pid}")]
        public IActionResult GetHistory(int pid)
        {
            var patient = _unitOfWork.PatientRepo.GetPatientHistory(pid);

            if (patient == null) 
                return NotFound("No patient");

            var result = new
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appoinments = patient.Appointments.Select(p => new
                {

                    AppointmentId = p.Id,
                    AppointmentDate = p.AppoinmentDate,
                    Status = p.Status,
                    DoctorId =p.DoctorId,
                    DoctorName = p.Doctor.FullName,
                    Specialization = p.Doctor.Specialization


                })
            };




            return Ok(result);


        }
    }
}
