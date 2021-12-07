using System.Collections.Generic;

namespace School.API.Models.DTO
{
    public class CourseWithStudentsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
    }
}
