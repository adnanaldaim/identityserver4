using StudentApp.Object.DTOs.Course;

namespace CourseApp.Manager.Course
{
    public interface ICourseManager
    {
        Task<CourseDto> Create(CreateCourseDto input);
        Task<CourseDto> Update(EditCourseDto input);
        Task Delete(int id);
        Task<List<CourseDto>> Get();
        Task<EditCourseDto> Get(int id);
    }
}