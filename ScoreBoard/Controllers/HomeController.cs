using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;
using ScoreBoard.Repositories.Interfaces;
using ScoreBoard.ViewModels;
using System.Diagnostics;

namespace ScoreBoard.Controllers
{
    // Lê Đức Tài
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScoreRepository _scoreRepository;

        public HomeController(ILogger<HomeController> logger, IScoreRepository scoreRepository)
        {
            _logger = logger;
            _scoreRepository = scoreRepository;
        }

        /// <summary>
        /// get months
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var months = await _scoreRepository.GetMonthsAsync();
            return View(months);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IActionResult> ScoresByMonth(int month, int pageIndex = 1, int pageSize = 3)
        {
            var scores = await _scoreRepository.GetScoresByMonthAsync(month, pageIndex, pageSize);

            
            var totalUsers = await _scoreRepository.GetTotalUserCountAsync();
            var userOnPage2 = await _scoreRepository.GetUserOnPage2Async(month, 2, pageSize);
            var model = new ScoresVM
            {
                Scores = scores,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalUsers,
                UserOnPage2 = userOnPage2
            };

            ViewData["Month"] = month;

            return View(model);
        }


      




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
