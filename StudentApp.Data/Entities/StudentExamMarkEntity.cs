using StudentApp.Object.Enum;

namespace StudentApp.Data.Entities
{
    public class StudentExamMarkEntity
    {
        public int Id { get; set; }
        public decimal ObtainedMarks { get; set; }
        public StudentExamStatus Status { get; set; }
        public int? StudentId { get; set; }
        public StudentEntity Student { get; set; }
        public int? ExamId { get; set; }
        public ExamEntity Exam { get; set; }
    }
}
