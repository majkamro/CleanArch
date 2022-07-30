using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Controllers
{
	[Authorize]
	public class CourseController : Controller
	{
		private ICourseService _courseService;

		public CourseController(ICourseService courseService)
		{
			_courseService = courseService;
		}

		public IActionResult Index()
		{
			var model = _courseService.GetCourses();
			return View(model);
		}

		public IActionResult ShowCourseDetails(int id)
		{
			var course = _courseService.GetCourseById(id);

			return course == null ? NotFound() : View("CourseDetails", course);
		}
	}
}
