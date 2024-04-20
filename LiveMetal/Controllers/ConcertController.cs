using Microsoft.AspNetCore.Mvc;
using LiveMetal.Core.Contracts;

namespace LiveMetal.Controllers
{
    public class ConcertController : Controller
    {
        private readonly IConcertService _concertService;
        private readonly ILogger<ConcertController> _logger;

        public ConcertController(IConcertService concertService, ILogger<ConcertController> logger)
        {
            _concertService = concertService;
            _logger = logger;
        }

        public async Task<IActionResult> All()
        {
            var allConcerts = await _concertService.GetAllConcerts();
            return View(allConcerts);
        }
    }
}
