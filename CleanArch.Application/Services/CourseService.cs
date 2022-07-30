using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArch.Application.Services
{
	public class CourseService : ICourseService
	{
		private ICourseRepository _courseRepository;

		public CourseService(ICourseRepository courseRepository)
		{
			_courseRepository = courseRepository;
		}

		public CourseViewModel GetCourseById(int courseId)
		{
			var course = _courseRepository.GetCourseById(courseId);

			if (course == null)
			{
				return null;
			}
			else
			{
				return new CourseViewModel()
				{
					Id = course.Id,
					Name = course.Name,
					Description = course.Description,
					ImageUrl = course.ImageUrl,
				};
			}
		}

		public CoursesViewModel GetCourses()
		{
			var courses = new List<CourseViewModel>();

			foreach (var course in _courseRepository.GetCourses())
			{
				courses.Add(new CourseViewModel()
				{
					Id = course.Id,
					Name = course.Name,
					Description = course.Description,
					ImageUrl = course.ImageUrl,
				});
			}

			return new CoursesViewModel()
			{
				Courses = courses,
			};
		}
	}
}
