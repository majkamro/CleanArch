using System.ComponentModel.DataAnnotations;

namespace CleanArch.Domain.Models.Entities.Identity
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(250)]
		public string UserName { get; set; }

		[Required]
		[MaxLength(250)]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MaxLength(250)]
		public string Password { get; set; }
	}
}
