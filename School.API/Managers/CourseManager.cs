using School.API.Models.DTO;
using School.API.Models.Mapper;
using School.API.Repository;
using School.API.Validation;
using School.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.API.EntityManager
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepository _repository;
        private readonly IValidationManager _validationManager;

        public CourseManager(ICourseRepository repository, IValidationManager validationManager)
        {
            _repository = repository;
            _validationManager = validationManager;
        }

        public List<CourseDTO> GetAllCourses()
        {
            var courses = _repository.GetAllCourses();

            var courseList = new List<CourseDTO>();

            foreach (Course course in courses)
            {
                var courseDto = ModelMapper.MapCoursesDTO(course);
                courseList.Add(courseDto);
            }

            return courseList;
        }

        public async Task<CourseDTO> GetCourseById(int id)
        {
            var course = await _repository.GetCourseAsync(id);

            return ModelMapper.MapCoursesDTO(course);
        }

        public async Task<CourseWithTeacherDTO> GetCourseWithTeacher(int id)
        {
            var course = await _repository.GetCourseWithTeacher(id);

            return ModelMapper.MapCoursesWithTeacherDTO(course);
        }

        public async Task<CourseWithStudentsDTO> GetCourseWithStudents(int id)
        {
            var course = await _repository.GetCourseWithStudents(id);

            return ModelMapper.MapCoursesWithStudentDTO(course);
        }

        public bool EnrollStudent(int studentid, int courseid)
        {
            if(_validationManager.ValidateEnrollment(studentid, courseid))
            {
                Enrollment enrollment = new Enrollment()
                {
                    StudentId = studentid,
                    CourseId = courseid
                };

                _repository.EnrollStudent(enrollment);
                return true;
            }

            return false;
        }

        public void CreateCourse(Course course)
        {
            if (_validationManager.ValidateCourse(course))
            {
                _repository.CreateCourse(course);
            }
        }
    }
}
