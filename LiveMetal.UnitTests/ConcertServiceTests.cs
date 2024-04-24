using LiveMetal.Core.Models.Concert;
using LiveMetal.Core.Services;
using LiveMetal.Infrastructure.Data.Common;
using LiveMetal.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LiveMetal.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CreateConcertAsync_ShouldAddConcert()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            var service = new ConcertService(mockRepository.Object);
            var model = new ConcertCreateViewModel
            {
                BandId = 1,
                Date = "2024-05-01",
                Time = "20:00",
                Description = "Rock Night",
                Name = "Spring Fest",
                TicketPrice = 15.00M,
                VenueId = 1
            };

            // Act
            await service.CreateConcertAsync(model, "userId123");

            // Assert
            mockRepository.Verify(r => r.AddAsync(It.IsAny<Concert>()), Times.Once());
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once());
        }

        [Test]
        public async Task DeleteReviewsAndConcertAsync_ShouldDeleteConcertAndReviews()
        {
            // Arrange
            var reviews = new List<Review> { new Review { ReviewId = 1 }, new Review { ReviewId = 2 } };
            var concerts = new List<Concert> { new Concert { ConcertId = 1, Reviews = reviews } };

            var mockSet = new Mock<DbSet<Concert>>();
            mockSet.As<IAsyncEnumerable<Concert>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                .Returns(new TestAsyncEnumerator<Concert>(concerts.GetEnumerator()));
            mockSet.As<IQueryable<Concert>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Concert>(concerts.AsQueryable().Provider));
            mockSet.As<IQueryable<Concert>>().Setup(m => m.Expression).Returns(concerts.AsQueryable().Expression);
            mockSet.As<IQueryable<Concert>>().Setup(m => m.ElementType).Returns(concerts.AsQueryable().ElementType);
            mockSet.As<IQueryable<Concert>>().Setup(m => m.GetEnumerator()).Returns(concerts.GetEnumerator());

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.All<Concert>()).Returns(mockSet.Object);

            var service = new ConcertService(mockRepository.Object);

            // Act
            await service.DeleteReviewsAndConcertAsync(new Concert { ConcertId = 1 });

            // Assert
            mockRepository.Verify(r => r.DeleteAsync<Concert>(It.IsAny<int>()), Times.Once());
            foreach (var review in reviews)
            {
                mockRepository.Verify(r => r.DeleteAsync<Review>(review.ReviewId), Times.Once());
            }
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once());
        }

        [Test]
        public async Task EditConcertAsync_WhenConcertExists_ShouldUpdateProperties()
        {
            // Arrange
            var concert = new Concert { ConcertId = 1, Name = "Original" };
            var mockSet = new Mock<DbSet<Concert>>();
            mockSet.As<IQueryable<Concert>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Concert>(new List<Concert> { concert }.AsQueryable().Provider));

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Concert>(1)).Returns(Task.FromResult(concert));

            var service = new ConcertService(mockRepository.Object);
            var model = new ConcertCreateViewModel
            {
                BandId = 1,
                Date = "2024-12-01",
                Time = "19:00",
                Description = "Updated Description",
                Name = "Updated Name",
                TicketPrice = 20.00M,
                VenueId = 2
            };

            // Act
            await service.EditConcertAsync(1, model);

            // Assert
            Assert.AreEqual("Updated Name", concert.Name);
            Assert.AreEqual(DateTime.Parse("2024-12-01"), concert.Date);
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once());
        }

        [Test]
        public async Task GetAllConcerts_ShouldReturnConcertViewModelsSortedByDate()
        {
            // Arrange
            var mockBand = new Band { Name = "Mock Band", BandImageUrl = "url_to_image" };
            var mockVenue = new Venue { Name = "Mock Venue" };

            var concerts = new List<Concert>
    {
        new Concert { ConcertId = 1, Date = new DateTime(2024, 12, 01), Name = "Concert A", Band = mockBand, Venue = mockVenue },
        new Concert { ConcertId = 2, Date = new DateTime(2024, 11, 01), Name = "Concert B", Band = mockBand, Venue = mockVenue }
    };

            var mockSet = new Mock<DbSet<Concert>>();
            mockSet.As<IQueryable<Concert>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Concert>(concerts.AsQueryable().Provider));
            mockSet.As<IQueryable<Concert>>().Setup(m => m.Expression).Returns(concerts.AsQueryable().Expression);
            mockSet.As<IQueryable<Concert>>().Setup(m => m.ElementType).Returns(concerts.AsQueryable().ElementType);
            mockSet.As<IQueryable<Concert>>().Setup(m => m.GetEnumerator()).Returns(concerts.GetEnumerator());

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AllReadOnly<Concert>()).Returns(mockSet.Object);

            var service = new ConcertService(mockRepository.Object);

            // Act
            var result = await service.GetAllConcerts();

            // Assert
            var resultList = result.ToList();
            Assert.AreEqual(2, resultList.Count);
            Assert.AreEqual("Concert B", resultList[0].Name);  // Checking if sorted by date
            Assert.AreEqual("Concert A", resultList[1].Name);
        }



        [Test]
        public async Task GetConcertByIdAsync_WhenConcertExists_ShouldReturnConcert()
        {
            // Arrange
            var concert = new Concert { ConcertId = 1, Name = "Concert A" };
            var concerts = new List<Concert> { concert }.AsQueryable();

            var mockSet = new Mock<DbSet<Concert>>();
            mockSet.As<IQueryable<Concert>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Concert>(concerts.Provider));
            mockSet.As<IQueryable<Concert>>().Setup(m => m.Expression).Returns(concerts.Expression);
            mockSet.As<IQueryable<Concert>>().Setup(m => m.ElementType).Returns(concerts.ElementType);
            mockSet.As<IQueryable<Concert>>().Setup(m => m.GetEnumerator()).Returns(concerts.GetEnumerator());

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.All<Concert>()).Returns(mockSet.Object);

            var service = new ConcertService(mockRepository.Object);

            // Act
            var result = await service.GetConcertByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Concert A", result.Name);
        }

        [Test]
        public async Task EditConcertAsync_WhenConcertNotFound_ShouldNotSaveChanges()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Concert>(It.IsAny<int>())).ReturnsAsync((Concert)null);

            var service = new ConcertService(mockRepository.Object);
            var model = new ConcertCreateViewModel { BandId = 1, Date = "2024-01-01", Time = "19:00", Name = "Non-Existent Concert" };

            // Act
            await service.EditConcertAsync(999, model); // Non-existent concert ID

            // Assert
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Never());
        }

        [Test]
        public async Task EditConcertAsync_WhenConcertDoesNotExist_ShouldNotPerformUpdate()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Concert>(It.IsAny<int>())).ReturnsAsync((Concert)null);

            var service = new ConcertService(mockRepository.Object);
            var model = new ConcertCreateViewModel { BandId = 1, Date = "2025-01-01", Time = "20:00", Name = "Updated Concert" };

            // Act
            await service.EditConcertAsync(999, model); // Assuming 999 is a non-existent concert ID

            // Assert
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Never()); // Ensure SaveChangesAsync is never called
        }
    }
}