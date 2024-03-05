namespace StudentApp.Object.DTOs.Exam
{
    public class ExamDto
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
