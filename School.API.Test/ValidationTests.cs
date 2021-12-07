using School.API.EntityManager;
using School.API.Repository;
using School.API.Validation;
using Moq;
using NUnit.Framework;

namespace School.API.Test
{
    public class ValidationTests
    {
        private Mock<IValidationManager> _mockValidationManager;
        private Mock<ICourseRepository> _mockCourseRepository;

        [SetUp]
        public void Setup()
        {
            _mockCourseRepository = new Mock<ICourseRepository>();
        }

        [Test]
        public void Valid_Course_NameLength_LessThan_MaxCharacters()
        {
            var validationManager = new ValidationManager(_mockCourseRepository.Object);
            var result = validationManager.ValidateCourseNameLength("Area 51: The Secrets");
            Assert.IsTrue(result);
        }

        [Test]
        public void InValid_Course_NameLength_GreaterThan_MaxCharacters()
        {
            var validationManager = new ValidationManager(_mockCourseRepository.Object);
            var result = validationManager.ValidateCourseNameLength("SArea 51: The Secrets");
            Assert.IsFalse(result);
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(30)]
        public void Valid_ClassCapacity_Between_Bounds(int classCapacity)
        {
            var validationManager = new ValidationManager(_mockCourseRepository.Object);
            var result = validationManager.ValidateCourseCapacity(classCapacity);
            Assert.IsTrue(result);
        }

        [TestCase(4)]
        [TestCase(31)]
        public void InValid_ClassCapacity_Outside_Bounds(int classCapacity)
        {
            var validationManager = new ValidationManager(_mockCourseRepository.Object);
            var result = validationManager.ValidateCourseCapacity(classCapacity);
            Assert.IsFalse(result);
        }

        [Test]
        public void Valid_TeacherOrStudent_Length_LessThan_MaxCharacters()
        {
            var validationManager = new ValidationManager(_mockCourseRepository.Object);
            var result = validationManager.ValidateNameLength("Joseph Patrick Devlin Joseph Patrick Devlin Joseph");
            Assert.IsTrue(result);
        }

        [Test]
        public void InValid_TeacherOrStudent_NameLength_GreaterThan_MaxCharacters()
        {
            var validationManager = new ValidationManager(_mockCourseRepository.Object);
            var result = validationManager.ValidateNameLength("AJoseph Patrick Devlin Joseph Patrick Devlin Joseph");
            Assert.IsFalse(result);
        }
    }
}