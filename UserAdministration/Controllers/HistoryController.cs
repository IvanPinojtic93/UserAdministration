using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Globalization;
using UserAdministration.Application.Models;
using UserAdministration.Application.Services;
using UserAdministration.DAL.Models;

namespace UserAdministration.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
        // GET: HistoryController
        public async Task<IActionResult> Index()
        {
            return View(await _historyService.GetHistories());
        }
    }
}
