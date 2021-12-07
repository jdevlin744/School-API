namespace School.API.Models.DTO
{
    public class CourseWithTeacherDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public TeacherDTO Teacher { get; set; } = new TeacherDTO();
    }
}
