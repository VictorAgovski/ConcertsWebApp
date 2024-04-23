using LiveMetal.Core.Models.Band;
using LiveMetal.Core.Models.Review;
using LiveMetal.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Contracts
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewViewModel>> GetAllReviewsAsync();

        Task<IEnumerable<Review>> GetReviewsByUserIdAsync(string id);

        Task<IEnumerable<ReviewViewModel>> GetTopThreeReviewsAsync();

        Task AddReviewAsync(ReviewCreateViewModel model, string userId);

        Task<IEnumerable<RatingViewModel>> GetRatingsAsync();
    }
}
