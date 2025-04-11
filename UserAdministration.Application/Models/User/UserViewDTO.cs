using System.ComponentModel.DataAnnotations;

namespace UserAdministration.Application.Models.User
{
    public class UserViewDTO
    {
        public required int Id { get; set; }

        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        [Display(Name = "Login Count")]
        public required int LoginCount { get; set; }
    }
}
