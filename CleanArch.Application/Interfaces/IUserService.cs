using CleanArch.Application.Enums;
using CleanArch.Domain.Models.Entities.Identity;

namespace CleanArch.Application.Interfaces
{
	public interface IUserService
	{
		#region Login
		public bool IsExistUser(string email, string password);
		#endregion

		#region Register
		CheckUser CheckUserName(string username);
		CheckUser CheckEmail(string email);
		int RegisterUser(User user);
		#endregion
	}
}
