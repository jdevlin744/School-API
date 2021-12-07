using School.API.Models.DTO;
using School.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.API.EntityManager
{
    public interface IStudentManager
    {
        public List<StudentDTO> GetAllStudents();

        public Task<StudentDTO> GetStudentById(int studentId);

        public Task<StudentWithCoursesDTO> GetStudentWithEnrollments(int studentId);

        public void CreateStudent(Student student);
    }
}
