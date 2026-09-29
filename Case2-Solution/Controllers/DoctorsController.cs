using Case2_Solution.DTOs.DoctorDtos;
using Case2_Solution.Models;
using Case2_Solution.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Case2_Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {

        private IUnitOfWork _unitOfWork;

        public DoctorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("specialization/{specialization}")]
        public IActionResult GetBySpecialization(string specialization)
        {
            var doctors = _unitOfWork.DoctorRepo.GetBySpecialization(specialization);

            if (doctors == null)
            {
                return NotFound("No doctors Found");
            }

            var result = doctors.Select(s => new
            {
                Id = s.Id,
                FullName = s.FullName,
                Email = s.Email,
                Phone = s.Phone,
                DepartmentId = s.DepartmentId

            });

            return Ok(result);
        }



        [HttpGet("details")]

        public IActionResult GetDeoctorDetails()
        {
            var doctors = _unitOfWork.DoctorRepo
                .GetDetails();

            var result = doctors.Select(d => new
            {
                FullName = d.FullName,
                Specialization = d.Specialization,
                Email = d.Email,
                Phone = d.Phone,
                Salary = d.Salary,
                DepartmentId = d.DepartmentId,
                DepartmentName = d.Department.Name
            });

            return Ok(result);
        }


        [HttpPost]
        public IActionResult CreateDoctor(DoctorCreateDto dto)
        {
            var doctor = new Doctor
            {
                FullName = dto.FullName,
                Specialization = dto.Specialization,
                Email = dto.Email,
                Phone = dto.Phone,
                Salary = dto.Salary,
                DepartmentId = dto.DepartmentId

            };

            _unitOfWork.DoctorRepo.Add(doctor);
            _unitOfWork.Save();

            return Created();

        }



        [HttpPut]
        public IActionResult UpdateDoctor(int id, DoctorCreateDto dto)
        {
            var doctor = _unitOfWork.DoctorRepo.GetById(id);
            if (doctor == null)
                return NotFound("No Doctor");

            doctor.FullName = dto.FullName;
            doctor.Specialization = dto.Specialization;
            doctor.Email = dto.Email;
            doctor.Phone = dto.Phone;
            doctor.Salary = dto.Salary;
            doctor.DepartmentId = dto.DepartmentId;


            _unitOfWork.Save();

            return NoContent();
        }


        [HttpDelete]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _unitOfWork.DoctorRepo
                .GetById(id);

            if (doctor == null) return NotFound("No Doctors");
            
            _unitOfWork.DoctorRepo.Delete(doctor);
            _unitOfWork.Save();

            return NoContent(); 
        }
    }
}