using LiveMetal.Core.Contracts;
using LiveMetal.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LiveMetal.Areas.Admin.Controllers
{
    public class NewsController : AdminBaseController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

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
