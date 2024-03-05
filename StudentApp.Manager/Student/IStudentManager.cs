using StudentApp.Object.DTOs.Exam;
using StudentApp.Object.DTOs.Student;

namespace StudentApp.Manager.Student
{
    public interface IStudentManager
    {
        Task<StudentDto> Create(CreateStudentDto input);
        Task<StudentDto> Update(EditStudentDto input);
        Task Delete(int id);
        Task<List<StudentDto>> Get();
        Task<EditStudentDto> Get(int id);
        Task<List<StudentMarksDto>> GetStudentMarksSheet(int studentId);
    }
}
