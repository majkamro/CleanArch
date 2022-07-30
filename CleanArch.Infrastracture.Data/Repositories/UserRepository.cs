using CleanArch.Data.Context;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models.Entities.Identity;
using System.Linq;

namespace CleanArch.Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		private UniversityDBContext _context;

		public UserRepository(UniversityDBContext context)
		{
			_context = context;
		}

		#region Login
		public bool IsExistUser(string email, string password)
		{
			return _context.Users.Any(x => x.Email == email && x.Password == password);
		}
		#endregion

		#region Register
		public void AddUser(User user)
		{
			_context.Add(user);
		}

		public bool IsExistEmail(string email)
		{
			return _context.Users.Any(x => x.Email == email);
		}

		public bool IsExistUserName(string userName)
		{
			return _context.Users.Any(x => x.UserName == userName);
		}
		#endregion

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
