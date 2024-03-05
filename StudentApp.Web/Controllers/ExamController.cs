using CourseApp.Manager.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentApp.Manager.Exam;
using StudentApp.Manager.Student;
using StudentApp.Object.DTOs.Exam;

namespace StudentApp.Web.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamManager _examManager;
        private readonly ICourseManager _courseManager;
        private readonly IStudentManager _studentManager;

        public ExamController(IExamManager examManager, ICourseManager courseManager, IStudentManager studentManager)
        {
            _examManager = examManager;
            _courseManager = courseManager;
            _studentManager = studentManager;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateExamDto();
            var courses = await _courseManager.Get();
            model.CourseList = courses.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateExamDto input)
        {
            await _examManager.Create(input);
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _examManager.Get(id);
            var courses = await _courseManager.Get();
            model.CourseList = courses.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditExamDto input)
        {
            await _examManager.Update(input);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _examManager.Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return View(await _examManager.Get());
        }
        public async Task<PartialViewResult> SearchExams(string searchtxt)
        {
            var exams = await _examManager.Get();
            searchtxt = searchtxt?.ToLower();
            var result = !string.IsNullOrEmpty(searchtxt) ? exams.Where(x => x.CourseName.ToLower().Contains(searchtxt) ||
            x.ExamDate.ToString().ToLower().Contains(searchtxt)
            ).ToList() : exams;

            return PartialView("_GridView", result);
        }

        [HttpGet]
        public async Task<IActionResult> StudentMarksRecord()
        {
            return View(await _examManager.GetStudentMarksRecord());
        }
        [HttpGet]
        public async Task<IActionResult> CreateStudentMarks()
        {
            var model = new CreateStudentMarksDto();
            var students = await _studentManager.Get();
            var exams = await _examManager.Get();
            model.StudentList = students.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
            model.ExamList = exams.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.CourseName }).ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudentMarks(CreateStudentMarksDto input)
        {
            await _examManager.CreateStudentMarks(input);
            return RedirectToAction("StudentMarksRecord");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteMarks(int id)
        {
            await _examManager.DeleteMarks(id);
            return RedirectToAction("StudentMarksRecord");
        }

    }
}
