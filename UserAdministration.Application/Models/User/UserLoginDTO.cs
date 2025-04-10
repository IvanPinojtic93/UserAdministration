using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
