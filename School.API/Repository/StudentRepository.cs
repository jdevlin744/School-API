using School.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {    
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating student - {ex}");
            }
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await _context.Students.SingleAsync(s => s.Id == studentId);
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public async Task<Student> GetStudentWithEnrollments(int studentId)
        {
            return await _context.Students.Include(s => s.Enrollments).ThenInclude(en => en.Course)
                .ThenInclude(t => t.Teacher).AsNoTracking().SingleAsync(s => s.Id == studentId);
        }
    }
}
