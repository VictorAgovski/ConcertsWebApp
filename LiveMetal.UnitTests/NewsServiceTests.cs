using LiveMetal.Core.Exceptions;
using LiveMetal.Core.Models.News;
using LiveMetal.Core.Services;
using LiveMetal.Infrastructure.Data.Common;
using LiveMetal.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.UnitTests
{
    public class NewsServiceTests
    {
        [Test]
        public async Task GetAllNewsAsync_ShouldReturnAllNewsOrderedByPublicationDate()
        {
            // Arrange
            var news = new List<News>
    {
        new News { NewsId = 1, Title = "Latest News", PublishedOn = DateTime.Now.AddDays(-1) },
        new News { NewsId = 2, Title = "Older News", PublishedOn = DateTime.Now.AddDays(-2) }
    }.AsQueryable();

            var mockSet = new Mock<DbSet<News>>();
            mockSet.As<IQueryable<News>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<News>(news.Provider));
            mockSet.As<IQueryable<News>>().Setup(m => m.Expression).Returns(news.Expression);
            mockSet.As<IQueryable<News>>().Setup(m => m.ElementType).Returns(news.ElementType);
            mockSet.As<IQueryable<News>>().Setup(m => m.GetEnumerator()).Returns(news.GetEnumerator());

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AllReadOnly<News>()).Returns(mockSet.Object);

            var service = new NewsService(mockRepository.Object);

            // Act
            var result = await service.GetAllNewsAsync();

            // Assert
            var resultList = result.ToList();
            Assert.AreEqual(2, resultList.Count);
            Assert.AreEqual("Latest News", resultList[0].Title);  // Latest news should come first
            Assert.AreEqual("Older News", resultList[1].Title);
        }

        [Test]
        public async Task CreateNewsAsync_ShouldAddNewsSuccessfully()
        {
            // Arrange
            var newsModel = new NewsCreateViewModel { Title = "New Event", Content = "Details of the new event", ImageUrl = "image_url" };
            var userId = "user123";

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AddAsync(It.IsAny<News>())).Returns(Task.CompletedTask);

            var service = new NewsService(mockRepository.Object);

            // Act
            await service.CreateNewsAsync(newsModel, userId);

            // Assert
            mockRepository.Verify(r => r.AddAsync(It.Is<News>(n => n.Title == "New Event" && n.UserId == userId)), Times.Once());
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once());
        }

        [Test]
        public async Task GetTopThreeNewsAsync_ShouldReturnOnlyTopThreeNews()
        {
            // Arrange
            var newsItems = new List<News>
    {
        new News { NewsId = 1, Title = "News One", PublishedOn = DateTime.Now.AddDays(-1) },
        new News { NewsId = 2, Title = "News Two", PublishedOn = DateTime.Now.AddDays(-2) },
        new News { NewsId = 3, Title = "News Three", PublishedOn = DateTime.Now },
        new News { NewsId = 4, Title = "News Four", PublishedOn = DateTime.Now.AddDays(-3) }
    }.AsQueryable();

            var mockSet = new Mock<DbSet<News>>();
            mockSet.As<IQueryable<News>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<News>(newsItems.Provider));
            mockSet.As<IQueryable<News>>().Setup(m => m.Expression).Returns(newsItems.Expression);
            mockSet.As<IQueryable<News>>().Setup(m => m.ElementType).Returns(newsItems.ElementType);
            mockSet.As<IQueryable<News>>().Setup(m => m.GetEnumerator()).Returns(newsItems.GetEnumerator());

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AllReadOnly<News>()).Returns(mockSet.Object);

            var service = new NewsService(mockRepository.Object);

            // Act
            var result = await service.GetTopThreeNewsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("News Three", result.First().Title); // Checking if the newest is on top
        }

        [Test]
        public async Task GetNewsByIdAsync_WhenNewsDoesNotExist_ShouldThrowNewsNotFoundException()
        {
            // Arrange
            var newsId = 1;
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<News>(newsId)).ReturnsAsync(() => null);

            var service = new NewsService(mockRepository.Object);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => service.GetNewsByIdAsync(newsId));
        }
    }
}
