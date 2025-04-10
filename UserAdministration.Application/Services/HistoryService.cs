using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserAdministration.Application.Models;
using UserAdministration.Application.Models.History;
using UserAdministration.DAL.Models;
using UserAdministration.DAL.Repository;

namespace UserAdministration.Application.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryService(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }
        public async Task AddHistory(HistoryAddDTO history)
        {
            await _historyRepository.AddHistory(new History()
            {
                Browser = history.Browser,
                UserId = history.UserId
            });
        }

        public async Task<IEnumerable<HistoryViewDTO>> GetHistories()
        {
            return await _historyRepository.GetHistories()
                .Select(history => new HistoryViewDTO()
                {
                    FirstName = history.User.FirstName,
                    LastName = history.User.LastName,
                    Timestamp = history.Timestamp,
                    Browser = history.Browser,
                }).ToListAsync();
        }
    }
}
