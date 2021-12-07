using School.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext _context;

        public CourseRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public Course GetCourse(int id)
        {
            return _context.Courses.Find(id);
        }

        public async Task<Course> GetCourseWithTeacher(int id)
        {
            return await _context.Courses.Include(t => t.Teacher).SingleAsync(c => c.Id == id);
        }

        public async Task<Course> GetCourseWithStudents(int id)
        {
            return await _context.Courses.Include(t => t.Enrollments).SingleAsync(c => c.Id == id);
        }

        public void EnrollStudent(Enrollment enrollment)
        {
            try
            {
                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error enrolling student - {ex}");
            }
        }


        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Teacher> GetTeacher(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public void CreateCourse(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating course - {ex}");
            }
        }

        public int GetCurrentStudentCountForCourse(int id)
        {
            return _context.Enrollments.Count(c => c.CourseId == id);
        }

        public bool CheckIfStudentEnrolledInCourse(int studentid, int courseid)
        {
            var count = _context.Enrollments.Count(c => c.StudentId == studentid && c.CourseId == courseid);

            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetNumberOfCoursesAssignedToTeacher(int teacherId)
        {
            return _context.Courses.Count(c => c.TeacherId == teacherId);
        }

        public bool IsTeacherAlreadyAssignedToCourse(int courseId)
        {
            return _context.Courses.Find(courseId).TeacherId.HasValue;
        }
    }
}
