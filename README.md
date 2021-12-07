# SchoolAPI

Note: I named the Class Entity 'Course' due to 'Class' being a reserved keyword in C#. 

- CourseController, StudentController and TeacherController all offer the ability to GET All, GET and POST a new record. 
- CourseController offers a PUT to enroll a student in a course and TeacherController offers a PUT to assign a teacher to a course.
- Validation rules are mainly handled by the ValidationManager which is covered by the unit test project with NUnit and Moq.
- Other entity level validation exists for name length within the entity classes.

The program includes a DbInitializer that creates a local DB using EF Core code first. This is deleted and recreated each time the program starts for ease of testing.

Further development ideas:
- ApplicationInsights logging instead of to the console
- Interfacing the ModelMapper, then scoping in it Startup for DI.
- Allow GET with other parameters such as Name or Email. For now you can only GET with IDs - depending on nature of data you may not want to expost DB IDs to a consumer.

