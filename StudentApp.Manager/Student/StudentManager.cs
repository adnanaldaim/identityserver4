using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data.Entities;
using StudentApp.Manager.Repo;
using StudentApp.Object.DTOs.Exam;
using StudentApp.Object.DTOs.Student;

namespace StudentApp.Manager.Student
{
    public class StudentManager : IStudentManager
    {
        private readonly IMapper _mapper;
        private readonly IRepository<StudentEntity> _studentRepo;
        private readonly IRepository<StudentExamMarkEntity> _studentMarksRepo;

        public StudentManager(IMapper mapper, IRepository<StudentEntity> studentRepo, IRepository<StudentExamMarkEntity> studentMarksRepo)
        {
            _mapper = mapper;
            _studentRepo = studentRepo;
            _studentMarksRepo = studentMarksRepo;
        }
        public async Task<StudentDto> Create(CreateStudentDto input)
        {
            var s = await _studentRepo.AddAsync(_mapper.Map<StudentEntity>(input));
            return _mapper.Map<StudentDto>(s);
        }

        public async Task<StudentDto> Update(EditStudentDto input)
        {
            var s = await _studentRepo.UpdateAsync(_mapper.Map<StudentEntity>(input));
            return _mapper.Map<StudentDto>(s);
        }
        public async Task Delete(int id)
        {
            await _studentRepo.DeleteAsync(await _studentRepo.GetByIdAsync(id));
        }

        public async Task<List<StudentDto>> Get()
        {
            return _mapper.Map<List<StudentDto>>(await _studentRepo.GetAllAsync());
        }
        public async Task<EditStudentDto> Get(int id)
        {
            return _mapper.Map<EditStudentDto>(await _studentRepo.GetByIdAsync(id));
        }
        public async Task<List<StudentMarksDto>> GetStudentMarksSheet(int studentId)
        {
            var studentMarks = _studentMarksRepo.GetAllIncluding().AsNoTracking()
                 .Include(x => x.Student)
                 .Include(x => x.Exam)
                 .ThenInclude(x => x.Course).Where(x => x.StudentId == studentId);

            var marks = await studentMarks.Select(x => new StudentMarksDto
            {
                Id = x.Id,
                StudentName = x.Student.Name,
                ExamDate = x.Exam.ExamDate,
                ExamName = x.Exam.Course.Name,
                ObtainedMarks = x.ObtainedMarks
            }).ToListAsync();
            return marks;
        }


    }
}
