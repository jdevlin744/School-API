using School.Models;

namespace School.API.Validation
{
    public interface IValidationManager
    {
        public bool ValidateTeacher(Teacher teacher);

        public bool ValidateCourse(Course course);

        public bool ValidateStudent(Student student);

        public bool ValidateNameLength(string name);

        public bool ValidateCourseNameLength(string courseName);

        public bool ValidateEnrollment(int courseid, int studentid);

        public bool IsSpaceAvailableInCourse(int id);

        public bool IsTeacherAlreadyAssignedToCourse(int courseId);
    }
}
