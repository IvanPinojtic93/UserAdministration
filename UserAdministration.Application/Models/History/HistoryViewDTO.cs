using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
