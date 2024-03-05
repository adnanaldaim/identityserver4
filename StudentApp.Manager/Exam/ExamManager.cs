using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data.Entities;
using StudentApp.Manager.Repo;
using StudentApp.Object.DTOs.Exam;

namespace StudentApp.Manager.Exam
{
    public class ExamManager : IExamManager
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ExamEntity> _examRepo;
        private readonly IRepository<StudentExamMarkEntity> _studentMarksRepo;

        public ExamManager(IMapper mapper, IRepository<ExamEntity> examRepo, IRepository<StudentExamMarkEntity> studentMarksRepo)
        {
            _mapper = mapper;
            _examRepo = examRepo;
            _studentMarksRepo = studentMarksRepo;
        }
        public async Task<ExamDto> Create(CreateExamDto input)
        {
            var s = await _examRepo.AddAsync(_mapper.Map<ExamEntity>(input));
            return _mapper.Map<ExamDto>(s);
        }

        public async Task<ExamDto> Update(EditExamDto input)
        {
            var s = await _examRepo.UpdateAsync(_mapper.Map<ExamEntity>(input));
            return _mapper.Map<ExamDto>(s);
        }
        public async Task Delete(int id)
        {
            await _examRepo.DeleteAsync(await _examRepo.GetByIdAsync(id));
        }
        public async Task DeleteMarks(int id)
        {
            await _studentMarksRepo.DeleteAsync(await _studentMarksRepo.GetByIdAsync(id));
        }

        public async Task<List<ExamDto>> Get()
        {
            return _mapper.Map<List<ExamDto>>(await _examRepo.GetAllIncluding().Include(x => x.Course).ToListAsync());
        }
        public async Task<EditExamDto> Get(int id)
        {
            return _mapper.Map<EditExamDto>(await _examRepo.GetByIdAsync(id));
        }

        public async Task<List<StudentMarksDto>> GetStudentMarksRecord()
        {
            var studentMarks = _studentMarksRepo.GetAllIncluding()
                .Include(x => x.Student)
                .Include(x => x.Exam)
                .ThenInclude(x => x.Course).AsNoTracking();

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
        public async Task<CreateStudentMarksDto> CreateStudentMarks(CreateStudentMarksDto input)
        {
            await _studentMarksRepo.AddAsync(_mapper.Map<StudentExamMarkEntity>(input));
            return input;
        }

    }
}
