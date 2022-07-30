using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Interfaces
{
	public interface ICourseService
	{
		CoursesViewModel GetCourses();
		CourseViewModel GetCourseById(int courseId);
	}
}
