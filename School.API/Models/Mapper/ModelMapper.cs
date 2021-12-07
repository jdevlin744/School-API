using School.API.Models.DTO;
using School.Models;

namespace School.API.Models.Mapper
{
    public static class ModelMapper
    {
        public static StudentDTO MapStudentDTO (Student student)
        {
            StudentDTO studentDTO = new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };

            return studentDTO;
        }

        public static StudentWithCoursesDTO MapStudentWithCoursesDTO(Student student)
        {
            StudentWithCoursesDTO studentDTO = new StudentWithCoursesDTO();
            studentDTO.Id = student.Id;
            studentDTO.Name = student.Name;
            studentDTO.Email = student.Email;

            foreach(Enrollment en in student.Enrollments)
            {
                CourseDTO course = new CourseDTO()
                {
                    Name = en.Course.Name,
                    Id = en.Course.Id,
                    Capacity = en.Course.Capacity
                };
                studentDTO.Courses.Add(course);
            }

            return studentDTO;
        }

        public static CourseDTO MapCoursesDTO(Course course)
        {
            CourseDTO CourseDTO = new CourseDTO();
            CourseDTO.Id = course.Id;
            CourseDTO.Name = course.Name;
            CourseDTO.Capacity = course.Capacity;           

            return CourseDTO;
        }

        public static CourseWithStudentsDTO MapCoursesWithStudentDTO(Course course)
        {
            CourseWithStudentsDTO CourseDTO = new CourseWithStudentsDTO();
            CourseDTO.Id = course.Id;
            CourseDTO.Name = course.Name;
            CourseDTO.Capacity = course.Capacity;

            if (course.Enrollments != null)
            {
                foreach (Enrollment en in course.Enrollments)
                {
                    StudentDTO studentDto = new StudentDTO()
                    {
                        Id = en.StudentId
                    };
                    CourseDTO.Students.Add(studentDto);
                }
            }

            return CourseDTO;
        }

        public static CourseWithTeacherDTO MapCoursesWithTeacherDTO(Course course)
        {
            CourseWithTeacherDTO CourseDTO = new CourseWithTeacherDTO();
            CourseDTO.Id = course.Id;
            CourseDTO.Name = course.Name;
            CourseDTO.Capacity = course.Capacity;

            if (course.Teacher != null)
            {
                CourseDTO.Teacher.Id = course.Teacher.Id;
                CourseDTO.Teacher.Name = course.Teacher.Name;
            }

            return CourseDTO;
        }

        public static TeacherDTO MapTeacherDTO(Teacher teacher)
        {
            TeacherDTO teacherDto = new TeacherDTO()
            {
                Id = teacher.Id,
                Name = teacher.Name,
            };

            return teacherDto;
        }

        public static TeacherWithCoursesDTO MapTeacherWithCoursesDTO(Teacher teacher)
        {
            TeacherWithCoursesDTO teacherDto = new TeacherWithCoursesDTO()
            {
                Id = teacher.Id,
                Name = teacher.Name,
            };

            if (teacher.Courses != null)
            {
                foreach (Course c in teacher.Courses)
                {
                    CourseDTO courseDto = new CourseDTO()
                    {
                        Id = c.Id,
                        Name = c.Name
                    };
                    teacherDto.Courses.Add(courseDto);
                }
            }

            return teacherDto;
        }
    }
}
