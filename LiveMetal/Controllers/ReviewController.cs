using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Review;
using LiveMetal.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace LiveMetal.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IConcertService _concertService;
        private readonly IBandService _bandService;
        private readonly IReviewService _reviewService;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(IReviewService reviewService, ILogger<ReviewController> logger, IConcertService concertService, IBandService bandService)
        {
            _reviewService = reviewService;
            _logger = logger;
            _concertService = concertService;
            _bandService = bandService;
        }

        public async Task<IActionResult> All()
        {
            var allReviews = await _reviewService.GetAllReviewsAsync();
            return View(allReviews);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? concertId, int? bandId)
        {
            var concerts = await _concertService.GetAllConcertsAsync();
            var bands = await _bandService.GetAllBandsAsync();
            var ratings = await _reviewService.GetRatingsAsync();

            var model = new ReviewCreateViewModel
            {
                Ratings = ratings.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                Concerts = concerts.Select(c => new SelectListItem { Text = c.Name, Value = c.ConcertId.ToString() }).ToList(),
                Bands = bands.Select(b => new SelectListItem { Text = b.Name, Value = b.BandId.ToString() }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            await _reviewService.AddReviewAsync(model, userId);

            if (model.ConcertId.HasValue)
            {
                return RedirectToAction("Details", "Concert", new { id = model.ConcertId });
            }
            if (model.BandId.HasValue)
            {
                return RedirectToAction("Details", "Band", new { id = model.BandId });
            }

            return RedirectToAction("All", "Review");
        }
    }
}
