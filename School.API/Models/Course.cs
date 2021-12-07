using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        public IList<Enrollment> Enrollments { get; set; }

        public int? TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}
