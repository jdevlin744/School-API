using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength (50)]
        public string Name { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
