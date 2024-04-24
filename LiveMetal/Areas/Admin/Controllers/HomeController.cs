using LiveMetal.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LiveMetal.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly INewsService _newsService;

        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            var topThreeNews = await _newsService.GetTopThreeNewsAsync();
            return View(topThreeNews);
        }
    }
}
