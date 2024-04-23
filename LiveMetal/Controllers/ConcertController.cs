using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Concert;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using static LiveMetal.Infrastructure.Constants.DataConstants;

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

            return View(new ConcertCreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConcertCreateViewModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _concertService.CreateConcertAsync(model, userId);
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var concert = await _concertService.GetConcertByIdAsync(id);

            if (concert == null)
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != concert.CreatorId)
            {
                return Unauthorized();
            }

            var model = await _concertService.GetConcertFormModelByIdAsync(id);

            ViewBag.Bands = new SelectList(await _bandService.GetAllBands(), "Id", "Name", concert.BandId);
            ViewBag.Venues = new SelectList(await _venueService.GetAllVenues(), "Id", "Name", concert.VenueId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ConcertCreateViewModel model)
        {
            var concert = await _concertService.GetConcertByIdAsync(id);

            if (concert == null)
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != concert.CreatorId)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _concertService.EditConcertAsync(id, model);
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var concert = await _concertService.GetConcertByIdAsync(id);

            if (concert == null)
            {
                return NotFound();
            }

            var model = await _concertService.GetConcertDetailsModelByIdAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var concert = await _concertService.GetConcertDeleteModelByIdAsync(id);
            if (concert == null)
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest();
            }

            if (concert.CreatorId != userId)
            {
                return Unauthorized();
            }

            return View(concert);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id, ConcertDeleteViewModel model)
        {
            var concert = await _concertService.GetConcertByIdAsync(id);

            if (concert == null)
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest();
            }

            if (concert.CreatorId != userId)
            {
                return Unauthorized();
            }

            await _concertService.DeleteReviewsAsync(concert);
            await _concertService.DeleteConcertAsync(id);

            return RedirectToAction("All");
        }
    }
}
