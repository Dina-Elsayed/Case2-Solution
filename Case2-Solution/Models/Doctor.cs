using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Case2_Solution.Models
{

    [Index(nameof(Email), IsUnique = true)]
    public class Doctor
    {

        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, MaxLength(100)]
        public string Specialization { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required,Phone]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Salary { get; set; }


        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }


        public Department Department { get; set; }


        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
