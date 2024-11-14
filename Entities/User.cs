namespace Entities
{ 
using System.ComponentModel.DataAnnotations;


	public class User
	{

		public string UserName { get; set; }
		[StringLength(40, ErrorMessage = "Password has to be between 8 and 40 chars length", MinimumLength = 8)]
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int UserId { get; set; }
	}
}

