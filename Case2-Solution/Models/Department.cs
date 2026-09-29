using System.ComponentModel.DataAnnotations;

namespace Case2_Solution.Models
{
    public class Department
    {


        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(150)]
        public string?Location { get; set; }

        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    }
}
