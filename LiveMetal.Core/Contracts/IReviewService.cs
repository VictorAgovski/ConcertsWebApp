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

        Task<Review> EditReviewAsync(Review model);

        Task DeleteReviewAsync(Review review);

        Task<ReviewDeleteViewModel?> GetReviewDeleteModelByIdAsync(int id);
    }
}
