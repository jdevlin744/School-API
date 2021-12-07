using School.API.Models.DTO;
using School.API.Models.Mapper;
using School.API.Repository;
using School.API.Validation;
using School.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.API.EntityManager
{
    public class TeacherManager : ITeacherManager
    {
        private readonly ITeacherRepository _repository;
        private readonly IValidationManager _validationManager;

        public TeacherManager(ITeacherRepository repository, IValidationManager validationManager)
        {
            _repository = repository;
            _validationManager = validationManager;
        }
        
        public void AssignCourse(int teacherId, int courseId)
        {
            if(!_validationManager.IsTeacherAlreadyAssignedToCourse(courseId))
            {
                _repository.AssignCourse(teacherId, courseId);
            }
        }

        public void CreateTeacher(Teacher teacher)
        {
            if(_validationManager.ValidateTeacher(teacher))
            {
                _repository.CreateTeacher(teacher);
            }
        }

        public List<TeacherDTO> GetAllTeachers()
        {
            var teachers = _repository.GetAllTeachers();

            var teacherList = new List<TeacherDTO>();

            foreach (Teacher teacher in teachers)
            {
                var teacherDto = ModelMapper.MapTeacherDTO(teacher);
                teacherList.Add(teacherDto);
            }

            return teacherList;
        }

        public async Task<TeacherDTO> GetTeacherById(int teacherId)
        {
            var teacher = await _repository.GetTeacherById(teacherId);
            return ModelMapper.MapTeacherDTO(teacher);
        }

        public Task<TeacherDTO> GetTeacherWithCourses(int teacherId)
        {
            throw new NotImplementedException();
        }
    }
}
