﻿namespace StudentApp.Data.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string RollNumber { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public ICollection<StudentCourseEntity> Courses { get; set; }
        public ICollection<StudentExamMarkEntity> ExamMarks { get; set; }
    }
}
