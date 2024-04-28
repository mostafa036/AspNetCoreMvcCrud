using System.ComponentModel.DataAnnotations;

namespace DemoPL.ViewModels
{
	public class ForgetPasswordViewModel
	{
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}
