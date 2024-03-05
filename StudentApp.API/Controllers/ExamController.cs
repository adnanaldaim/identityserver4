using CourseApp.Manager.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentApp.Manager.Exam;
using StudentApp.Manager.Student;
using StudentApp.Object.DTOs.Exam;

namespace StudentApp.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    [Authorize]
    public class ExamController : ControllerBase
    {
        private readonly IExamManager _examManager;

        public ExamController(IExamManager examManager)
        {
            _examManager = examManager;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateExamDto input)
        {
            await _examManager.Create(input);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit(EditExamDto input)
        {
            await _examManager.Update(input);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _examManager.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _examManager.Get());
        }
    }
}
