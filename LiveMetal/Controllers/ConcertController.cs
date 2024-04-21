using Microsoft.AspNetCore.Mvc;
using LiveMetal.Core.Contracts;
using System.Security.Claims;

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

        public async Task<IActionResult> Rated()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var ratedConcerts = await _concertService.RatedConcertsByUserId(userId);
                return View(ratedConcerts);
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
