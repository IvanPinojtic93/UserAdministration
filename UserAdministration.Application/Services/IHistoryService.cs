using UserAdministration.Application.Models.History;

namespace UserAdministration.Application.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<HistoryViewDTO>> GetHistories();
        Task AddHistory(HistoryAddDTO history);
    }
}
