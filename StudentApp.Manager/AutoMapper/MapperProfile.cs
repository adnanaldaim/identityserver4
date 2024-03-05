using AutoMapper;
using StudentApp.Data.Entities;
using StudentApp.Object.DTOs.Course;
using StudentApp.Object.DTOs.Exam;
using StudentApp.Object.DTOs.Student;

namespace StudentApp.Manager.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<StudentEntity, StudentDto>().ReverseMap();
            CreateMap<CreateStudentDto, StudentEntity>().ReverseMap();
            CreateMap<EditStudentDto, StudentEntity>().ReverseMap();

            CreateMap<CreateCourseDto, CourseEntity>().ReverseMap();
            CreateMap<EditCourseDto, CourseEntity>().ReverseMap();
            CreateMap<CourseEntity, CourseDto>().ReverseMap();

            CreateMap<CreateExamDto, ExamEntity>().ReverseMap();
            CreateMap<EditExamDto, ExamEntity>().ReverseMap();
            CreateMap<ExamEntity, ExamDto>().ReverseMap();
            CreateMap<ExamDto, ExamEntity>().ReverseMap().ForMember(x => x.CourseName, map => map.MapFrom(x => x.Course.Name));

            CreateMap<CreateStudentMarksDto, StudentExamMarkEntity>().ReverseMap();
        }
    }
}
