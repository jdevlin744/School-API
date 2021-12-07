using System.Collections.Generic;

namespace School.API.Models.DTO
{
    public class StudentWithCoursesDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
}
