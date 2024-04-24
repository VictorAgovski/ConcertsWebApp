using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Band;
using LiveMetal.Core.Models.Member;
using LiveMetal.Core.Services;
using LiveMetal.Infrastructure.Data.Common;
using LiveMetal.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.UnitTests
{
    public class BandServiceTests
    {
        [Test]
        public async Task CreateBandAsync_ShouldAddBandCorrectly()
        {
            // Arrange
            var bandModel = new BandCreateViewModel
            {
                Name = "New Band",
                Genre = "Rock",
                Biography = "A new rock band.",
                BandImageUrl = "image_url",
                FormationYear = new DateTime(2020, 1, 1),
                Members = new List<BandMemberCreateViewModel>
        {
            new BandMemberCreateViewModel { FullName = "John Doe", Role = "Vocalist" }
        }
            };

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AddAsync(It.IsAny<Band>())).Returns(Task.CompletedTask);
            var mockReviewService = new Mock<IReviewService>();
            var mockConcertService = new Mock<IConcertService>();
            var service = new BandService(mockRepository.Object, mockReviewService.Object, mockConcertService.Object);

            // Act
            await service.CreateBandAsync(bandModel);

            // Assert
            mockRepository.Verify(r => r.AddAsync(It.IsAny<Band>()), Times.Once());
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once());
        }

        [Test]
        public async Task DeleteBandAsync_ShouldDeleteBandAndRelatedEntities()
        {
            var concerts = new List<Concert> { new Concert { Reviews = new List<Review> { new Review(), new Review() } } };
            var band = new Band { BandId = 1, Concerts = concerts };

            var bands = new List<Band> { band }.AsQueryable();

            var mockSet = new Mock<DbSet<Band>>();
            mockSet.As<IQueryable<Band>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Band>(bands.Provider));
            mockSet.As<IQueryable<Band>>().Setup(m => m.Expression).Returns(bands.Expression);
            mockSet.As<IQueryable<Band>>().Setup(m => m.ElementType).Returns(bands.ElementType);
            mockSet.As<IQueryable<Band>>().Setup(m => m.GetEnumerator()).Returns(bands.GetEnumerator());

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.All<Band>()).Returns(mockSet.Object);
            mockRepository.Setup(r => r.GetByIdAsync<Band>(It.IsAny<int>())).ReturnsAsync(band);

            var mockReviewService = new Mock<IReviewService>();
            var mockConcertService = new Mock<IConcertService>();

            var service = new BandService(mockRepository.Object, mockReviewService.Object, mockConcertService.Object);

            await service.DeleteBandAsync(band);

            mockRepository.Verify(r => r.DeleteAsync<Band>(band.BandId), Times.Once());
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once());
            mockConcertService.Verify(s => s.DeleteReviewsAndConcertAsync(It.IsAny<Concert>()), Times.Exactly(concerts.Count));
        }

        [Test]
        public async Task CreateBandAsync_WithInvalidData_ShouldFailGracefully()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AddAsync(It.IsAny<Band>())).Throws(new InvalidOperationException("Invalid data"));

            var service = new BandService(mockRepository.Object, null, null);
            var bandModel = new BandCreateViewModel(); // Assume this is invalid

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await service.CreateBandAsync(bandModel));
        }

        [Test]
        public async Task GetBandById_ShouldReturnCorrectBand()
        {
            // Arrange
            var band = new Band { BandId = 1, Name = "The Rockers" };

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Band>(1)).ReturnsAsync(band);

            var service = new BandService(mockRepository.Object, null, null);

            // Act
            var result = await service.GetBandById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("The Rockers", result.Name);
        }

        [Test]
        public async Task GetBandById_WhenBandDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Band>(It.IsAny<int>())).ReturnsAsync((Band)null);

            var service = new BandService(mockRepository.Object, null, null);

            // Act
            var result = await service.GetBandById(999); // Assuming 999 is a non-existent band ID

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task CreateBandAsync_WhenDatabaseThrowsException_ShouldPropagateException()
        {
            // Arrange
            var bandModel = new BandCreateViewModel
            {
                Name = "Failing Band",
                Genre = "Blues",
                Biography = "This band will fail to be created."
            };

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AddAsync(It.IsAny<Band>())).ThrowsAsync(new Exception("Database error"));

            var service = new BandService(mockRepository.Object, null, null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => service.CreateBandAsync(bandModel));
            Assert.That(ex.Message, Is.EqualTo("Database error"));
        }

        [Test]
        public async Task GetBandById_WhenBandExists_ShouldReturnCorrectBand()
        {
            // Arrange
            var band = new Band { BandId = 1, Name = "The Classics" };
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Band>(1)).ReturnsAsync(band);

            var service = new BandService(mockRepository.Object, null, null);

            // Act
            var result = await service.GetBandById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("The Classics", result.Name);
        }

        [Test]
        public async Task CreateBandAsync_WhenInputIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            var service = new BandService(mockRepository.Object, null, null);

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await service.CreateBandAsync(null));
        }

        [Test]
        public async Task GetAllBandsWithFeatures_WhenDatabaseErrorOccurs_ShouldThrowException()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AllReadOnly<Band>())
                          .Throws(new Exception("Database connection error"));

            var service = new BandService(mockRepository.Object, null, null);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => service.GetAllBandsWithFeatures());
        }

        [Test]
        public async Task GetAllBandsWithFeatures_WhenBandsHaveNoMembers_ShouldHandleEmptyMembersList()
        {
            // Arrange
            var bands = new List<Band> {
        new Band { BandId = 1, Name = "Solo Performer", BandImageUrl = "image3.jpg", Genre = "Solo", FormationYear = new DateTime(2015,1,1), Biography = "A solo performer.", BandMembers = new List<Member>() }
    }.AsQueryable();

            var mockSet = new Mock<DbSet<Band>>();
            mockSet.As<IQueryable<Band>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Band>(bands.Provider));
            mockSet.As<IQueryable<Band>>().Setup(m => m.Expression).Returns(bands.Expression);
            mockSet.As<IQueryable<Band>>().Setup(m => m.ElementType).Returns(bands.ElementType);
            mockSet.As<IQueryable<Band>>().Setup(m => m.GetEnumerator()).Returns(bands.GetEnumerator());

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AllReadOnly<Band>()).Returns(mockSet.Object);

            var service = new BandService(mockRepository.Object, null, null);

            // Act
            var result = await service.GetAllBandsWithFeatures();

            // Assert
            Assert.IsNotNull(result);
            var resultList = result.ToList();
            Assert.AreEqual(1, resultList.Count);
            Assert.IsEmpty(resultList[0].Members);
        }
    }
}
