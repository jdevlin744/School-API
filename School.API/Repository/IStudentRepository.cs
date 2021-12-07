using School.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.API.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();

        public Task<Student> GetStudentById(int studentId);

        public Task<Student> GetStudentWithEnrollments(int studentId);

        public void CreateStudent(Student student);
    }
}
