using System.ComponentModel.DataAnnotations;

namespace ProjectDbStarter.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your username")]
        string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        string Password { get; set; }

        public LoginViewModel() { }
    }
}
