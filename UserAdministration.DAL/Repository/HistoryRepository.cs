using Microsoft.EntityFrameworkCore;
using UserAdministration.DAL.Models;

namespace UserAdministration.DAL.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly UserAdministrationContext _context;
        public HistoryRepository(UserAdministrationContext context)
        {
            this._context = context;
        }

        public async Task AddHistory(History history)
        {
            _context.Histories.Add(history);
            await _context.SaveChangesAsync();
        }


        public IQueryable<History> GetHistories()
        {
            return _context.Histories.Include(history => history.User);
        }
    }
}