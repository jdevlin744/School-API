using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using System;
using School.API.Models.DTO;
using School.API.EntityManager;
using School.API.Models.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace School.Controllers
{
    [Route("api/Courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseManager _courseManager;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ICourseManager courseManager, ILogger<CoursesController> logger)
        {
            _courseManager = courseManager;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDTO>> GetCourses()
        {
            try
            {
                return _courseManager.GetAllCourses();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred getting all courses", ex);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourse(int id)
        {
            try
            {
                return await _courseManager.GetCourseById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred getting course id={id}", ex);
                return NotFound();
            }

        }

        [HttpGet("GetCourseWithTeacher/{id}", Name = "GetCourse_WithTeacher")]
        public async Task<ActionResult<CourseWithTeacherDTO>> GetCourseWithTeacher(int id)
        {
            try
            {
                return await _courseManager.GetCourseWithTeacher(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred getting course id={id} with teacher", ex);
                return NotFound();
            }

        }

        [HttpGet("GetCourseWithStudents/{id}", Name = "GetCourse_WithStudents")]
        public async Task<ActionResult<CourseWithStudentsDTO>> GetCourseWithStudents(int id)
        {
            try
            {
                return await _courseManager.GetCourseWithStudents(id);
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occurred getting course id={id} with students", ex);
                return NotFound();
            }

        }

        [HttpPut("EnrollStudents/{studentid}/{courseid}", Name = "Enroll_Students")]
        public ActionResult<int> EnrollStudents(int studentid, int courseid)
        {
            try
            {
                var isEnrolled = _courseManager.EnrollStudent(studentid, courseid);
                return StatusCodes.Status202Accepted;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred enrolling student id={studentid} in course id={courseid}", ex);
                return BadRequest();
            }

        }

        [HttpPost]
        public ActionResult<CourseDTO> CreateCourse(Course course)
        {
            try
            {
                _courseManager.CreateCourse(course);
                var courseDTO = ModelMapper.MapCoursesDTO(course);
                return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, courseDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred creating course name={course.Name}", ex);
                return BadRequest();
            }
        }
    }
}
