using UserAdministration.DAL.Models;

namespace UserAdministration.DAL.Repository
{
    public interface IHistoryRepository
    {
        Task AddHistory(History history);
        IQueryable<History> GetHistories();
    }
}
