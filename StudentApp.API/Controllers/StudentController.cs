using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Manager.Student;
using StudentApp.Object.DTOs.Student;
using System.ComponentModel.DataAnnotations;

namespace StudentApp.API.Controllers
{

    [ApiController, Route("api/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto input)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            await _studentManager.Create(input);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit(EditStudentDto input)
        {
            await _studentManager.Update(input);
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _studentManager.Delete(id);
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var students = await _studentManager.Get();
            return Ok(students);
        }
        [HttpGet("marksheet")]
        public async Task<IActionResult> GetMarksSheet(int studentId)
        {
            var markSheet = await _studentManager.GetStudentMarksSheet(studentId);
            return Ok(markSheet);
        }

    }
}
