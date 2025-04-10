using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAdministration.Application.Models.History
{
    public class HistoryAddDTO
    {
        public required int UserId { get; set; }
        public required string Browser { get; set; }
    }
}
