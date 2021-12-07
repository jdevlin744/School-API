using School.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.API.Repository
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAllTeachers();

        public Task<Teacher> GetTeacherById(int teacherId);

        public Task<Teacher> GetTeacherWithCourses(int teacherId);

        public void AssignCourse(int teacherId, int courseId);

        public void CreateTeacher(Teacher teacher);

    }
}
