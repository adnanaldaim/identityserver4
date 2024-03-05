using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentApp.Object.DTOs.Exam
{
    public class CreateStudentMarksDto
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public decimal ObtainedMarks { get; set; }
        public List<SelectListItem> StudentList { get; set; }
        public List<SelectListItem> ExamList { get; set; }
    }
}
