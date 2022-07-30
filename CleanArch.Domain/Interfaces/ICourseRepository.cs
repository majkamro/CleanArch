using CleanArch.Domain.Models.Entities;
using System.Collections.Generic;

namespace CleanArch.Domain.Interfaces
{
	public interface ICourseRepository
	{
		IEnumerable<Course> GetCourses();
		Course GetCourseById(int courseId);
	}
}
