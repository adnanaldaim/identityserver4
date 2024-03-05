using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using StudentApp.Manager.Student;
using StudentApp.Object.DTOs.Course;
using StudentApp.Object.DTOs.Student;
using StudentApp.Object.Pagination;

namespace StudentApp.Web.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentManager _studentManager;

        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto input)
        {
            await _studentManager.Create(input);
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _studentManager.Get(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditStudentDto input)
        {
            await _studentManager.Update(input);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentManager.Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List(int page = 1)
        {
            Log.Information("Calling StudentController > List ...");

            var students = await _studentManager.Get();
            if (page < 1) page = 1;
            var pager = students.Paginate<StudentDto>(students.Count, page, 10);
            ViewBag.Pager = pager;
            return View();
        }

        public async Task<PartialViewResult> SearchStudents(int page = 1, string searchtxt = "")
        {
            var students = await _studentManager.Get();
            searchtxt = searchtxt?.ToLower();
            if (page < 1) page = 1;
            var pager = students.Paginate<StudentDto>(students.Count, page, 10);
            ViewBag.Pager = pager;
            var result = !string.IsNullOrEmpty(searchtxt) ? pager.Items.Where(x => x.Name.ToLower().Contains(searchtxt) ||
            x.RollNumber.ToLower().Contains(searchtxt) ||
            x.Email.ToLower().Contains(searchtxt) ||
            x.Phone.ToLower().Contains(searchtxt) ||
            x.Address.ToLower().Contains(searchtxt) ||
            x.City.ToLower().Contains(searchtxt) ||
            x.State.ToLower().Contains(searchtxt)
            ).ToList() : pager.Items;

            return PartialView("_GridView", result);
        }

        [HttpGet]
        public async Task<IActionResult> MarksSheet(int studentId)
        {
            var markSheet = await _studentManager.GetStudentMarksSheet(studentId);
            return View(markSheet);
        }
    }
}
