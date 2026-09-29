using System.ComponentModel.DataAnnotations;

namespace Case2_Solution.Models
{
    public class Patient
    {

        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required,MaxLength(20)]
        public string Gender { get; set; }

        public  DateTime DateOfBirth { get; set; }

        [Phone]
        [Required, MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
