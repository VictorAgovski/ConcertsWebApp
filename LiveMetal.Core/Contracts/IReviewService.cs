using LiveMetal.Core.Models.Concert;
using LiveMetal.Core.Models.Review;
using LiveMetal.Infrastructure.Data.Models;

namespace LiveMetal.Core.Contracts
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewViewModel>> GetAllReviewsAsync();

        Task<Review> GetReviewByIdAsync(int id);

        Task AddReviewAsync(ReviewCreateViewModel model, string userId);

        Task<IEnumerable<RatingViewModel>> GetRatingsAsync();

        Task<Review> EditReviewAsync(Review model);
    }
}
