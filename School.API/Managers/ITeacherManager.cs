using School.API.Models.DTO;
using School.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.API.EntityManager
{
    public interface ITeacherManager
    {
        public List<TeacherDTO> GetAllTeachers();

        public Task<TeacherDTO> GetTeacherById(int teacherId);

        public Task<TeacherDTO> GetTeacherWithCourses(int teacherId);

        public void AssignCourse(int teacherId, int courseId);

        public void CreateTeacher(Teacher teacher);
    }
}
