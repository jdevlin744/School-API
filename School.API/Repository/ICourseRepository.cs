using School.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.API.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourses();

        public Task<Course> GetCourseAsync(int id);

        public Course GetCourse(int id);

        public Task<Course> GetCourseWithTeacher(int id);

        public Task<Course> GetCourseWithStudents(int id);

        public void EnrollStudent(Enrollment enrollment);

        public void CreateCourse(Course course);

        public Task<Teacher> GetTeacher(int id);

        public Task<Student> GetStudent(int id);

        public int GetCurrentStudentCountForCourse(int id);

        public bool CheckIfStudentEnrolledInCourse(int studentid, int courseid);

        public int GetNumberOfCoursesAssignedToTeacher(int teacherId);

        public bool IsTeacherAlreadyAssignedToCourse(int courseId);
    }
}
