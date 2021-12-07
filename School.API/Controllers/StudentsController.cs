using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.API.Models.DTO;
using School.API.EntityManager;
using School.API.Models.Mapper;
using Microsoft.Extensions.Logging;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentManager studentManager, ILogger<StudentsController> logger)
        {
            _studentManager = studentManager;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
            try
            {
                return _studentManager.GetAllStudents();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred getting all students", ex);
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudent(int id)
        {
            try
            {
                return await _studentManager.GetStudentById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred getting student id={id}", ex);
                return NotFound();
            }
        }

        [HttpGet("GetStudentWithEnrollments/{id}", Name = "GetStudent_WithEnrollments")]
        public async Task<ActionResult<StudentWithCoursesDTO>> GetStudentWithEnrollments(int id)
        {
            try
            {
                return await _studentManager.GetStudentWithEnrollments(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred getting student id={id} with enrollments", ex);
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<int> CreateStudent(Student student)
        {
            try
            {
                _studentManager.CreateStudent(student);
                var studentDto = ModelMapper.MapStudentDTO(student);
                return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, studentDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred creating student name={student.Name}", ex);
                return BadRequest();
            }
        }
    }
}

