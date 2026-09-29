using Case2_Solution.Models;
using Case2_Solution.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Case2_Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public DepartementsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        public IActionResult GetDepartments()
        {


            var departments = _unitOfWork.DepartmentRepo.GetAll();

            var result = departments.Select(
                d => new
                {
                    Id = d.Id,
                    Name = d.Name,
                    Location = d.Location,

                });

            return Ok(result);


        }



        [HttpGet("Doctors-Count")]
        public IActionResult GetDepartmentsDoctorCount()
        {
            var departments = _unitOfWork.DepartmentRepo.GetDepartmentsWithDoctorCount();

            var result = departments.Select(d => new
            {

                Id = d.Id,
                Name = d.Name,
                Location = d.Location,
                DoctorCount = d.Doctors.Count

            });


            return Ok(result);
        }
    }
}
