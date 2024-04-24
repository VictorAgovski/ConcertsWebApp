using LiveMetal.Core.Models.Review;
using LiveMetal.Core.Services;
using LiveMetal.Infrastructure.Data.Common;
using LiveMetal.Infrastructure.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.UnitTests
{
    public class ReviewServiceTests
    {
        [Test]
        public async Task AddReviewAsync_WithValidData_ShouldAddReview()
        {
            // Arrange
            var reviewModel = new ReviewCreateViewModel { Title = "Great concert", Content = "Amazing performance", Rating = 5, ConcertId = 1 };
            var mockRepository = new Mock<IRepository>();
            var service = new ReviewService(mockRepository.Object);

            // Act
            await service.AddReviewAsync(reviewModel, "userId");

            // Assert
            mockRepository.Verify(r => r.AddAsync<Review>(It.IsAny<Review>()), Times.Once);
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task EditReviewAsync_WithValidReview_ShouldEditReview()
        {
            // Arrange
            var originalReview = new Review { ReviewId = 1, Title = "Original Title", Content = "Original Content", Rating = 3, ConcertId = 1 };
            var editedReview = new Review { ReviewId = 1, Title = "Updated Title", Content = "Updated Content", Rating = 5, ConcertId = 2 };
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Review>(1)).ReturnsAsync(originalReview);
            var service = new ReviewService(mockRepository.Object);

            // Act
            var result = await service.EditReviewAsync(editedReview);

            // Assert
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.AreEqual(editedReview.Title, result.Title);
            Assert.AreEqual(editedReview.Content, result.Content);
            Assert.AreEqual(editedReview.Rating, result.Rating);
            Assert.AreEqual(editedReview.ConcertId, result.ConcertId);
        }

        [Test]
        public async Task GetReviewByIdAsync_WithExistingId_ShouldReturnReview()
        {
            // Arrange
            var review = new Review { ReviewId = 1, Title = "Review 1", Content = "Content 1", Rating = 4, UserId = "userId1", IssuedOn = DateTime.Now, ConcertId = 1 };
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Review>(1)).ReturnsAsync(review);
            var service = new ReviewService(mockRepository.Object);

            // Act
            var result = await service.GetReviewByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.ReviewId);
            Assert.AreEqual("Review 1", result.Title);
        }

        [Test]
        public async Task GetReviewByIdAsync_WithNonExistingId_ShouldReturnNull()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Review>(1)).ReturnsAsync((Review)null);
            var service = new ReviewService(mockRepository.Object);

            // Act
            var result = await service.GetReviewByIdAsync(1);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public async Task AddReviewAsync_WithNullModel_ShouldThrowArgumentNullException()
        {
            // Arrange
            var service = new ReviewService(Mock.Of<IRepository>());

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(() => service.AddReviewAsync(null, "userId"));
        }

        [Test]
        public async Task DeleteReviewAsync_WithNullReview_ShouldThrowArgumentNullException()
        {
            // Arrange
            var service = new ReviewService(Mock.Of<IRepository>());

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => service.DeleteReviewAsync(null));
        }

        [Test]
        public async Task EditReviewAsync_WithNonExistingReview_ShouldReturnNull()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Review>(1)).ReturnsAsync((Review)null);
            var service = new ReviewService(mockRepository.Object);

            // Act
            var result = await service.EditReviewAsync(new Review { ReviewId = 1 });

            // Assert
            Assert.Null(result);
        }
    }
}
