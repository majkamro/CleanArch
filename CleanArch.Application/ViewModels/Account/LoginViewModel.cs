using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.ViewModels.Account
{
	public class LoginViewModel
	{
		[Required]
		[MaxLength(250)]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MaxLength(250)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool RememberMe { get; set; }
	}
}
