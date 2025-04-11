using System.ComponentModel.DataAnnotations;

namespace UserAdministration.Application.Models.User
{
    public class UserEditDTO
    {
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public required string Email { get; set; }

        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
