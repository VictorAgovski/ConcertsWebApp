using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Band;
using LiveMetal.Core.Models.Member;
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

    }
}
