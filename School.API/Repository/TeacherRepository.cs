using School.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDbContext _context;

        public TeacherRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public void AssignCourse(int teacherId, int courseId)
        {
            try
            {
                var course = _context.Courses.Find(courseId);
                course.TeacherId = teacherId;
                _context.Entry(course).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception($"Error assigning teacher to course - {ex}");
            }
                 
        }

        public void CreateTeacher(Teacher teacher)
        {
            try
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating teacher - {ex}");
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await _context.Teachers.FindAsync(teacherId);
        }

        public Task<Teacher> GetTeacherWithCourses(int teacherId)
        {
            throw new NotImplementedException();
        }
    }
}
