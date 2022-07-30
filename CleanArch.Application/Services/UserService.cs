using CleanArch.Application.Enums;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Tools;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models.Entities.Identity;

namespace CleanArch.Application.Services
{
	public class UserService : IUserService
	{
		private IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		#region Login
		public bool IsExistUser(string email, string password)
		{
			var hashedPassword = SecurityUtils.EncodePasswordMd5(password);
			return _userRepository.IsExistUser(email, hashedPassword);
		}
		#endregion

		#region Register
		public CheckUser CheckEmail(string email)
		{
			var emailValid = _userRepository.IsExistEmail(email.Trim().ToLower());

			return !emailValid ? CheckUser.OK : CheckUser.EmailNotValid;
		}

		public CheckUser CheckUserName(string username)
		{
			var userNameValid = _userRepository.IsExistUserName(username);

			return !userNameValid ? CheckUser.OK : CheckUser.UserNameNotValid;
		}

		public int RegisterUser(User user)
		{
			_userRepository.AddUser(user);
			_userRepository.Save();
			return user.Id;
		}
		#endregion
	}
}
