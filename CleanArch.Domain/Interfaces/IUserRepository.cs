using CleanArch.Domain.Models.Entities.Identity;

namespace CleanArch.Domain.Interfaces
{
	public interface IUserRepository
	{
		#region Login
		bool IsExistUser(string email, string password);
		#endregion

		#region Register
		void AddUser(User user);
		bool IsExistUserName(string userName);
		bool IsExistEmail(string email);
		#endregion

		void Save();
	}
}
