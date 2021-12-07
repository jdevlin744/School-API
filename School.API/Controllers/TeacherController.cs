using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using School.API.EntityManager;
using School.API.Models.DTO;
using School.API.Models.Mapper;
using School.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherManager _teacherManager;
        private readonly ILogger<CoursesController> _logger;


        public TeacherController(ITeacherManager teacherManager, ILogger<CoursesController> logger)
        {
            _teacherManager = teacherManager;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeacherDTO>> GetTeachers()
        {
            try
            {
                return _teacherManager.GetAllTeachers();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred getting all teachers", ex);
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDTO>> GetTeacher(int id)
        {
            try
            {
                return await _teacherManager.GetTeacherById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred getting teacher id={id}", ex);
                return NotFound();
            }
        }

        [HttpPut("AssignCourse/{teacherid}/{courseid}", Name = "AssignCourse")]
        public ActionResult<int> AssignCourse(int teacherid, int courseid)
        {
            try
            {
                _teacherManager.AssignCourse(teacherid, courseid);
                return StatusCodes.Status202Accepted;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred assigning teacher id={teacherid} to course id={courseid}", ex);
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<int> PostTeacher(Teacher teacher)
        {
            try
            {
                _teacherManager.CreateTeacher(teacher);
                var teacherDto = ModelMapper.MapTeacherDTO(teacher);
                return CreatedAtAction(nameof(GetTeacher), new { id = teacher.Id }, teacherDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred creating teacher name={teacher.Name}", ex);
                return BadRequest();
            }
        }
    }
}