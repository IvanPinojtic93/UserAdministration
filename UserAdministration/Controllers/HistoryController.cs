using Microsoft.AspNetCore.Mvc;
using UserAdministration.Application.Services;

namespace UserAdministration.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
        // GET: History
        public IActionResult Index()
        {
            return View();
        }

        // GET: History/HistoryTable
        public async Task<IActionResult> HistoryTable()
        {
            return View(await _historyService.GetHistories());
        }
    }
}
