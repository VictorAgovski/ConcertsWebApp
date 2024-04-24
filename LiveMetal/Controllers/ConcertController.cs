using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Concert;
using LiveMetal.Infrastructure.Data.Models;
using LiveMetal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LiveMetal.Controllers
{
    public class ConcertController : BaseController
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
        [AllowAnonymous]
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
                string userId = User.Id();
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConcertCreateViewModel model)
        {
            string userId = User.Id();

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

            string userId = User.Id();

            if (userId != concert.CreatorId && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await _concertService.GetConcertFormModelByIdAsync(id);

            ViewBag.Bands = new SelectList(await _bandService.GetAllBands(), "Id", "Name", concert.BandId);
            ViewBag.Venues = new SelectList(await _venueService.GetAllVenues(), "Id", "Name", concert.VenueId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConcertCreateViewModel model)
        {
            var concert = await _concertService.GetConcertByIdAsync(id);

            if (concert == null)
            {
                return NotFound();
            }

            string userId = User.Id();

            if (userId != concert.CreatorId && User.IsAdmin() == false)
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
        [AllowAnonymous]
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

            string userId = User.Id();

            if (userId == null)
            {
                return BadRequest();
            }

            if (concert.CreatorId != userId && User.IsAdmin() == false)
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

            string userId = User.Id();

            if (userId == null)
            {
                return BadRequest();
            }

            if (concert.CreatorId != userId && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            try
            {
                await _concertService.DeleteReviewsAndConcertAsync(concert);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm)
        {
            var concerts = await _concertService.SearchConcertsAsync(searchTerm);
            return View("All", concerts);
        }

        [HttpGet]
        [Route("Concert/All/{searchTerm}")]
        public async Task<IActionResult> All(string searchTerm)
        {
            IEnumerable<ConcertViewModel> concerts;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                concerts = await _concertService.SearchConcertsAsync(searchTerm);
            }
            else
            {
                concerts = await _concertService.GetAllConcerts();
            }
            return View(concerts);
        }
    }
}
