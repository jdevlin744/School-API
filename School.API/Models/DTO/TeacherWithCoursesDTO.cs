using System.Collections.Generic;

namespace School.API.Models.DTO
{
    public class TeacherWithCoursesDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
}
