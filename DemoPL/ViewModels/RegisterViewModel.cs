using System.ComponentModel.DataAnnotations;

namespace DemoPL.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage ="Email Is Required")]
		[EmailAddress(ErrorMessage ="Invalid Email")]
		public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
		[DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password Is Required")]
		[Compare("Password",ErrorMessage ="Confirm Password Does Not Match Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
		public bool IsAgree { get; set; }
	}
}
