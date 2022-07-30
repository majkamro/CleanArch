using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Data.Repositories;
using CleanArch.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.IoC
{
	public class DependencyContainer
	{
		public static void RegisterServices(IServiceCollection services)
		{
			//Application Layer
			services.AddScoped<ICourseService, CourseService>();
			services.AddScoped<IUserService, UserService>();

			//Data Layer
			services.AddScoped<ICourseRepository, CourseRepository>();
			services.AddScoped<IUserRepository, UserRepository>();

		}
	}
}
