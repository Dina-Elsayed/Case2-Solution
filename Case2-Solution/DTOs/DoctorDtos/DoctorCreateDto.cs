using Case2_Solution.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Case2_Solution.DTOs.DoctorDtos
{
    public class DoctorCreateDto
    {
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, MaxLength(100)]
        public string Specialization { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Salary { get; set; }


        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
    }
}
