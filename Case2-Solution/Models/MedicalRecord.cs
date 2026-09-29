using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Case2_Solution.Models
{
    public class MedicalRecord
    {

        public int Id { get; set; }

        [Required, MaxLength(500)]
        public string Diagnosis { get; set; }

        [Required, MaxLength(1000)]
        public string Prescription { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }

        [ForeignKey(nameof(Appointment))]
        public int AppoinmentId { get; set; }

       
        public Appointment Appointment { get; set; }

    }
}
