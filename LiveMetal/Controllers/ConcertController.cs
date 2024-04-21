using Microsoft.AspNetCore.Mvc;
using LiveMetal.Core.Contracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using LiveMetal.Core.Models.Concert;

namespace LiveMetal.Controllers
{
    public class ConcertController : Controller
    {
        private readonly IConcertService _concertService;
        private readonly IBandService _bandService;
        private readonly IVenueService _venueService;
        private readonly ILogger<ConcertController> _logger;

        public ConcertController(IConcertService concertService, ILogger<ConcertController> logger, IBandService bandService, IVenueService venueService)
        {
            _concertService = concertService;
            _logger = logger;
            _bandService = bandService;
            _venueService = venueService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allConcerts = await _concertService.GetAllConcerts();
            return View(allConcerts);
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Bands = new SelectList(await _bandService.GetAllBands(), "Id", "Name");
            ViewBag.Venues = new SelectList(await _venueService.GetAllVenues(), "Id", "Name");

            return View(new ConcertViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConcertViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _concertService.CreateConcertAsync(model);
            return RedirectToAction("All");
        }
    }
}
