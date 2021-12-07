namespace School.Models
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            //if (context.Students.Any()) { return; }
            
            Teacher teacher = new Teacher()
            {
                Name = "Ned Schneebly",
                Email = "need@schoolofrock.edu"
            };
            context.Teachers.Add(teacher);
            context.SaveChanges();

            Student student = new Student()
            {
                Name = "JP Devlin",
                Email = "jdevlin744@gmail.com"
            };
            context.Students.Add(student);
            context.SaveChanges();

            Course testClass = new Course()
            {
                Name = "Computational Theory",
                TeacherId = 1,
                Capacity = 25
            };
            context.Courses.Add(testClass);
            context.SaveChanges();

            Enrollment enrollment = new Enrollment()
            {
                StudentId = 1,
                CourseId = 1
            };
            context.Enrollments.Add(enrollment);

            context.SaveChanges();
        }
    }
}
