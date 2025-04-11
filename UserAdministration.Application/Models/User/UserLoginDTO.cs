using System.ComponentModel.DataAnnotations;

namespace UserAdministration.Application.Models.User
{
    public class UserLoginDTO
    {
        [Display(Name = "Email Address")]

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public required string Email { get; set; }

        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public required string Browser { get; set; }
    }
}
