using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Venue;
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
    public class VenueServiceTests
    {
        [Test]
        public async Task AddVenueAsync_WithValidModel_ShouldAddVenue()
        {
            // Arrange
            var model = new VenueCreateViewModel
            {
                Name = "Venue Name",
                Location = "Location",
                Capacity = 100,
                ContactInfo = "Contact Info"
            };

            var mockRepository = new Mock<IRepository>();
            var service = new VenueService(mockRepository.Object, null, null);

            // Act
            await service.AddVenueAsync(model);

            // Assert
            mockRepository.Verify(r => r.AddAsync<Venue>(It.IsAny<Venue>()), Times.Once);
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task AddVenueAsync_ShouldAddVenue()
        {
            // Arrange
            var model = new VenueCreateViewModel { Name = "Venue Name", Location = "Location", Capacity = 100, ContactInfo = "Contact Info" };
            var mockRepository = new Mock<IRepository>();
            var service = new VenueService(mockRepository.Object, null, null);

            // Act
            await service.AddVenueAsync(model);

            // Assert
            mockRepository.Verify(r => r.AddAsync<Venue>(It.IsAny<Venue>()), Times.Once);
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}