using AutoMapper;
using StudentApp.Data.Entities;
using StudentApp.Manager.Repo;
using StudentApp.Object.DTOs.Course;

namespace CourseApp.Manager.Course
{
    public class CourseManager : ICourseManager
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CourseEntity> _courseRepo;

        public CourseManager(IMapper mapper, IRepository<CourseEntity> courseRepo)
        {
            _mapper = mapper;
            _courseRepo = courseRepo;
        }
        public async Task<CourseDto> Create(CreateCourseDto input)
        {
            var s = await _courseRepo.AddAsync(_mapper.Map<CourseEntity>(input));
            return _mapper.Map<CourseDto>(s);
        }

        public async Task<CourseDto> Update(EditCourseDto input)
        {
            var s = await _courseRepo.UpdateAsync(_mapper.Map<CourseEntity>(input));
            return _mapper.Map<CourseDto>(s);
        }
        public async Task Delete(int id)
        {
            await _courseRepo.DeleteAsync(await _courseRepo.GetByIdAsync(id));
        }

        public async Task<List<CourseDto>> Get()
        {
            return _mapper.Map<List<CourseDto>>(await _courseRepo.GetAllAsync());
        }
        public async Task<EditCourseDto> Get(int id)
        {
            return _mapper.Map<EditCourseDto>(await _courseRepo.GetByIdAsync(id));
        }
    }
}
