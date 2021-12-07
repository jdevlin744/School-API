using School.API.Repository;
using School.Models;

namespace School.API.Validation
{
    public class ValidationManager : IValidationManager
    {
        private readonly ICourseRepository _repository;

        public ValidationManager(ICourseRepository repository)
        {
            _repository = repository;
        }

        public bool ValidateTeacher(Teacher teacher)
        {
            return ValidateNameLength(teacher.Name) && !IsAssignedToMaxAllowedCourses(teacher.Id);
        }

        public bool ValidateCourse(Course course)
        {
            return ValidateCourseNameLength(course.Name) && ValidateCourseCapacity(course.Capacity);
        }

        public bool ValidateStudent(Student student)
        {
            return ValidateNameLength(student.Name);
        }

        public bool IsTeacherAlreadyAssignedToCourse(int courseId)
        {
            return _repository.IsTeacherAlreadyAssignedToCourse(courseId);
        }

        public bool IsAssignedToMaxAllowedCourses(int teacherId)
        {
            var count = _repository.GetNumberOfCoursesAssignedToTeacher(teacherId);

            if(count>=5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateNameLength(string name)
        {
            if (name.Length <= 50)
            {
                return true;
            }

            return false;
        }

        public bool ValidateCourseNameLength(string courseName)
        {
            if (courseName.Length <= 20)
            {
                return true;
            }

            return false;
        }

        public bool ValidateCourseCapacity(int courseCapacity)
        {
            if (courseCapacity >= 5 && courseCapacity <= 30)
            {
                return true;
            }

            return false;
        }

        public bool ValidateEnrollment(int courseid, int studentid)
        {
            return IsSpaceAvailableInCourse(courseid) && IsStudentAlreadyEnrolledInCourse(studentid, courseid);
        }

        public bool IsStudentAlreadyEnrolledInCourse(int studentid, int couseid)
        {
            return _repository.CheckIfStudentEnrolledInCourse(studentid, couseid);
        }

        public bool IsSpaceAvailableInCourse(int id)
        {
            var course = _repository.GetCourse(id);
            var courseCapacity = course.Capacity;
            var currentStudentCount = _repository.GetCurrentStudentCountForCourse(id);

            if (currentStudentCount < courseCapacity)
            {
                return true;
            }

            return false;
        }
    }
}
