using CleanArch.Data.Context;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models.Entities;
using System.Collections.Generic;

namespace CleanArch.Data.Repositories
{
	public class CourseRepository : ICourseRepository
	{
		private UniversityDBContext _context;

		public CourseRepository(UniversityDBContext context)
		{
			_context = context;
		}

		public IEnumerable<Course> GetCourses()
		{
			return _context.Courses;
		}

		Course ICourseRepository.GetCourseById(int courseId)
		{
			return _context.Courses.Find(courseId);
		}
	}
}
