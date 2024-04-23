using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Review;
using LiveMetal.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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
        public async Task<IActionResult> Create()
        {
            var concerts = await _concertService.GetAllConcertsAsync();
            var ratings = await _reviewService.GetRatingsAsync();

            var model = new ReviewCreateViewModel
            {
                Ratings = ratings.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                Concerts = concerts.Select(c => new SelectListItem { Text = c.Name, Value = c.ConcertId.ToString() }).ToList(),
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

            return RedirectToAction("All", "Review");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != review.UserId)
            {
                return Unauthorized();
            }

            var model = new ReviewEditViewModel
            {
                ReviewId = review.ReviewId,
                Title = review.Title,
                Content = review.Content,
                Rating = review.Rating,
                IssuedOn = review.IssuedOn,
                UserId = userId,
                ConcertId = review.ConcertId,
                Ratings = Enumerable.Range(1, 5).Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString(), Selected = i == review.Rating }),
                Concerts = new SelectList(await _concertService.GetAllConcertsAsync(), "ConcertId", "Name", review.ConcertId)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReviewEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Ratings = Enumerable.Range(1, 5).Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString(), Selected = i == model.Rating });
                model.Concerts = new SelectList(await _concertService.GetAllConcertsAsync(), "ConcertId", "Name", model.ConcertId);
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var updateResult = await _reviewService.EditReviewAsync(new Review
            {
                ReviewId = model.ReviewId,
                Title = model.Title,
                Content = model.Content,
                IssuedOn = model.IssuedOn,
                Rating = model.Rating,
                UserId = userId,
                ConcertId = model.ConcertId
            });

            if (updateResult != null)
            {
                return RedirectToAction("All"); 
            }
            else
            {
                ModelState.AddModelError("", "Unable to update the review.");
                return View(model);
            }
        }
    }
}
