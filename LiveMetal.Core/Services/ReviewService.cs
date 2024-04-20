using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Review;
using LiveMetal.Infrastructure.Data.Common;
using LiveMetal.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    BandName = r.Band.Name,
                    ConcertName = r.Concert.Name
                })
                .ToListAsync();
        }

        public Task<IEnumerable<Review>> GetReviewsByUserIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewViewModel>> GetTopThreeReviewsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
