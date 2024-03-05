namespace StudentApp.Data.Entities
{
    public class ExamEntity
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int? CourseId { get; set; }
        public CourseEntity Course { get; set; }
    }
}
