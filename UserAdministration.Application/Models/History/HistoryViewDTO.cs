using System.ComponentModel.DataAnnotations;

namespace UserAdministration.Application.Models.History
{
    public class HistoryViewDTO
    {
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }
        public required string Browser { get; set; }
        public required DateTime Timestamp { get; set; }
    }
}
