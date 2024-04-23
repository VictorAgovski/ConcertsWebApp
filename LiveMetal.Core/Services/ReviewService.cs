﻿using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Concert;
using LiveMetal.Core.Models.Review;
using LiveMetal.Infrastructure.Data.Common;
using LiveMetal.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static LiveMetal.Infrastructure.Constants.DataConstants;

namespace LiveMetal.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository _repository;

        public ReviewService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task AddReviewAsync(ReviewCreateViewModel model, string userId)
        {
            await _repository.AddAsync<Review>(new Review
            {
                Title = model.Title,
                Content = model.Content,
                Rating = model.Rating,
                IssuedOn = DateTime.UtcNow,
                UserId = userId,
                ConcertId = model.ConcertId
            });

            await _repository.SaveChangesAsync();
        }

        public async Task<Review> EditReviewAsync(Review model)
        {
            var review = await _repository.GetByIdAsync<Review>(model.ReviewId);

            if (review != null)
            {
                review.Title = model.Title;
                review.Content = model.Content;
                review.Rating = model.Rating;
                review.IssuedOn = DateTime.Parse(model.IssuedOn.ToString(DateFormat));
                review.UserId = model.UserId;
                review.ConcertId = model.ConcertId;
                review.ReviewId = model.ReviewId;

                await _repository.SaveChangesAsync();
                return review;
            }

            return null;
        }

        public async Task<IEnumerable<ReviewViewModel>> GetAllReviewsAsync()
        {
            return await _repository
                .AllReadOnly<Review>()
                .OrderByDescending(r => r.IssuedOn)
                .Select(r => new ReviewViewModel
                {
                    ReviewId = r.ReviewId,
                    Content = r.Content,
                    Rating = r.Rating,
                    UserName = r.User.UserName,
                    IssuedOn = r.IssuedOn.ToString(DateFormat),
                    Title = r.Title,
                    ConcertName = r.Concert.Name,
                    UserId = r.UserId
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<RatingViewModel>> GetRatingsAsync()
        {
            return await _repository
                .AllReadOnly<Review>()
                .Select(b => new RatingViewModel
                {
                    Id = b.Rating,
                    Name = b.Rating.ToString()
                })
                .ToListAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
            => await _repository.GetByIdAsync<Review>(id);
    }
}
