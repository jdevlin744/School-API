﻿namespace School.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}
