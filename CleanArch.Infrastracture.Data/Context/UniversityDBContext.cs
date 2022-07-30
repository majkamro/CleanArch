using CleanArch.Domain.Models.Entities;
using CleanArch.Domain.Models.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Context
{
	public class UniversityDBContext : DbContext
	{
		public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
		{

		}

		public DbSet<Course> Courses { get; set; }
		public DbSet<User> Users { get; set; }


	}
}
