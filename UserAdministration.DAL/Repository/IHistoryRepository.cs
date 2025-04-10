using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserAdministration.DAL.Models;

namespace UserAdministration.DAL.Repository
{
    public interface IHistoryRepository
    {
        Task AddHistory(History history);
        IQueryable<History> GetHistories();
    }
}
