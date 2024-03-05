namespace StudentApp.Object.DTOs.Exam
{
    public class StudentMarksDto
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string ExamName { get; set; }
        public decimal ObtainedMarks { get; set; }
        public DateTime? ExamDate { get; set; }
    }
}
