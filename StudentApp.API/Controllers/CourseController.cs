using Microsoft.AspNetCore.Mvc;
using CourseApp.Manager.Course;
using StudentApp.Object.DTOs.Course;
using Microsoft.AspNetCore.Authorization;

namespace CourseApp.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _courseManager;

        public CourseController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDto input)
        {
            await _courseManager.Create(input);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit(EditCourseDto input)
        {
            await _courseManager.Update(input);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseManager.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var courses = await _courseManager.Get();
            return Ok(courses);
        }
    }
}
