using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAdministration.Application.Models;
using UserAdministration.Application.Models.History;
using UserAdministration.DAL.Models;

namespace UserAdministration.Application.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<HistoryViewDTO>> GetHistories();
        Task AddHistory(HistoryAddDTO history);
    }
}
