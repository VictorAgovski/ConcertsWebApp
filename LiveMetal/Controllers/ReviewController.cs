using LiveMetal.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LiveMetal.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(IReviewService reviewService, ILogger<ReviewController> logger)
        {
            _reviewService = reviewService;
            _logger = logger;
        }

        public async Task<IActionResult> All()
        {
            var allReviews = await _reviewService.GetAllReviewsAsync();
            return View(allReviews);
        }
    }
}
