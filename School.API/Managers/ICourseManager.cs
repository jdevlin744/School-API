using School.API.Models.DTO;
using School.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.API.EntityManager
{
    public interface ICourseManager
    {
        public List<CourseDTO> GetAllCourses();

        public Task<CourseDTO> GetCourseById(int id);

        public Task<CourseWithTeacherDTO> GetCourseWithTeacher(int id);

        public Task<CourseWithStudentsDTO> GetCourseWithStudents(int id);

        public bool EnrollStudent(int studentid, int courseid);

        public void CreateCourse(Course course);
    }
}
