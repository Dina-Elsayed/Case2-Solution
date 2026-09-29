using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Case2_Solution.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public DateTime AppoinmentDate { get; set; }

        [Required, MaxLength(30)]
        public string Status { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }


        public MedicalRecord MedicalRecord { get; set; }
    }
}
