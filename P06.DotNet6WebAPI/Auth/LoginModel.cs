using System.ComponentModel.DataAnnotations;

namespace P06.DotNet6WebAPI.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User name should not be empty")]
        public string? Username { get; set; }


        [Required(ErrorMessage = "Password should not be empty")]
        public string? Password { get; set; }

    }
}
