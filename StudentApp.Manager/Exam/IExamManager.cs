using StudentApp.Object.DTOs.Exam;

namespace StudentApp.Manager.Exam
{
    public interface IExamManager
    {
        Task<ExamDto> Create(CreateExamDto input);
        Task<ExamDto> Update(EditExamDto input);
        Task Delete(int id);
        Task<List<ExamDto>> Get();
        Task<EditExamDto> Get(int id);
        Task<List<StudentMarksDto>> GetStudentMarksRecord();
        Task<CreateStudentMarksDto> CreateStudentMarks(CreateStudentMarksDto input);
        Task DeleteMarks(int id);
    }
}