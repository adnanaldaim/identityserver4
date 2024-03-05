using Azure;
using CourseApp.Manager.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Object.DTOs.Course;
using StudentApp.Object.Pagination;

namespace CourseApp.Web.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseManager _courseManager;

        public CourseController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDto input)
        {
            await _courseManager.Create(input);
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _courseManager.Get(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditCourseDto input)
        {
            await _courseManager.Update(input);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseManager.Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List(int page = 1)
        {
            var courses = await _courseManager.Get();
            if (page < 1) page = 1;
            var pager = courses.Paginate<CourseDto>(courses.Count, page, 10);
            ViewBag.Pager = pager;
            return View();
        }
        public async Task<PartialViewResult> SearchCourses(int page = 1, string searchtxt = "")
        {
            var courses = await _courseManager.Get();
            searchtxt = searchtxt?.ToLower();
            if (page < 1) page = 1;
            var pager = courses.Paginate<CourseDto>(courses.Count, page, 10);
            ViewBag.Pager = pager;
            var result = !string.IsNullOrEmpty(searchtxt) ? pager.Items.Where(x => x.Name.ToLower().Contains(searchtxt) ||
            x.Author.ToLower().Contains(searchtxt)
            ).ToList() : pager.Items;

            return PartialView("_GridView", result);
        }
    }
}
