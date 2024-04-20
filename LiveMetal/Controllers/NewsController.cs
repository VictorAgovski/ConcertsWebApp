using LiveMetal.Core.Contracts;
using LiveMetal.Core.Exceptions;
using LiveMetal.Core.Models.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiveMetal.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsService _newsService;
        private readonly ILogger<NewsController> _logger;

        public NewsController(INewsService newsService, ILogger<NewsController> logger)
        {
            _newsService = newsService;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var allNews = await _newsService.GetAllNewsAsync();
            return View(allNews);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var viewModel = await _newsService.GetNewsByIdAsync(id);
                return View(viewModel);
            }
            catch (NewsNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
