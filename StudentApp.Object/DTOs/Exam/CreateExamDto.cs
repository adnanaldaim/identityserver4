

using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentApp.Object.DTOs.Exam
{
    public class CreateExamDto
    {
        public DateTime ExamDate { get; set; }
        public int? CourseId { get; set; }
        public List<SelectListItem> CourseList { get; set; }
    }
}
