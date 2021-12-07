using School.API.Models.DTO;
using School.API.Models.Mapper;
using School.API.Repository;
using School.API.Validation;
using School.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.API.EntityManager
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepository _repository;
        private readonly IValidationManager _validationManager;

        public StudentManager(IStudentRepository repository, IValidationManager validationManager)
        {
            _repository = repository;
            _validationManager = validationManager;
        }

        public void CreateStudent(Student student)
        {
            if(_validationManager.ValidateStudent(student))
            {
                _repository.CreateStudent(student);
            }
        }

        public List<StudentDTO> GetAllStudents()
        {
            var students = _repository.GetAllStudents();
            var studentList = new List<StudentDTO>();

            foreach (Student student in students)
            {
                var studentDto = ModelMapper.MapStudentDTO(student);
                studentList.Add(studentDto);
            }

            return studentList;
        }

        public async Task<StudentDTO> GetStudentById(int studentId)
        {
            var student = await _repository.GetStudentById(studentId);
            return ModelMapper.MapStudentDTO(student);
        }

        public async Task<StudentWithCoursesDTO> GetStudentWithEnrollments(int studentId)
        {
            var student = await _repository.GetStudentWithEnrollments(studentId);
            return ModelMapper.MapStudentWithCoursesDTO(student);
        }
    }
}
