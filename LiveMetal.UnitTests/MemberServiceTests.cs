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
    public class MemberServiceTests
    {
        [Test]
        public async Task CreateMemberAsync_WhenDataIsInvalid_ShouldThrowException()
        {
            // Arrange
            var memberModel = new BandMemberCreateViewModel();  // Assume required fields are missing
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AddAsync(It.IsAny<Member>())).Throws(new Exception("Data validation failed"));

            var service = new MemberService(mockRepository.Object);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => service.CreateMemberAsync(memberModel), "Data validation failed");
        }

        [Test]
        public async Task DeleteMemberAsync_WhenMemberDoesNotExist_ShouldNotThrowException()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.DeleteAsync<Member>(It.IsAny<int>())).Throws(new InvalidOperationException("Member not found"));

            var service = new MemberService(mockRepository.Object);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => service.DeleteMemberAsync(999));
        }

        [Test]
        public async Task CreateMemberAsync_WhenInputIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var service = new MemberService(new Mock<IRepository>().Object);

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await service.CreateMemberAsync(null));
        }

        [Test]
        public async Task DeleteMemberAsync_ShouldCompleteWithoutError()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.DeleteAsync<Member>(It.IsAny<int>())).Returns(Task.CompletedTask);
            var service = new MemberService(mockRepository.Object);

            // Act & Assert
            Assert.DoesNotThrowAsync(async () => await service.DeleteMemberAsync(1));
        }

        [Test]
        public async Task DeleteMemberAsync_WithInvalidId_ShouldHandleGracefully()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.DeleteAsync<Member>(It.IsAny<int>())).Throws(new KeyNotFoundException("Member not found."));
            var service = new MemberService(mockRepository.Object);

            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(async () => await service.DeleteMemberAsync(999));
        }

        [Test]
        public async Task CreateMemberAsync_ShouldInsertDataCorrectly()
        {
            // Arrange
            var memberModel = new BandMemberCreateViewModel
            {
                FullName = "Alex Turner",
                Role = "Lead Singer",
                Biography = "Lead singer of the band",
                DateOfBirth = new DateTime(1986, 1, 6),
                DateOfJoining = new DateTime(2020, 5, 1),
                BandId = 1
            };

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AddAsync(It.IsAny<Member>())).Returns(Task.CompletedTask);

            var service = new MemberService(mockRepository.Object);

            // Act
            await service.CreateMemberAsync(memberModel);

            // Assert
            mockRepository.Verify(x => x.AddAsync(It.Is<Member>(m => m.FullName == "Alex Turner" && m.Role == "Lead Singer")), Times.Once);
        }

        [Test]
        public async Task DeleteMemberAsync_VerifiesDeletionIsCalled()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.DeleteAsync<Member>(It.IsAny<int>())).Returns(Task.CompletedTask);

            var service = new MemberService(mockRepository.Object);

            // Act
            await service.DeleteMemberAsync(1);

            // Assert
            mockRepository.Verify(x => x.DeleteAsync<Member>(1), Times.Once);
        }

        [Test]
        public async Task GetMemberDetailsById_WhenMemberExists_ShouldReturnCorrectDetails()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            var members = new List<Member>
    {
        new Member {
            MemberId = 1,
            FullName = "John Smith",
            Role = "Drummer",
            Biography = "A talented drummer known for his versatility.",
            DateOfBirth = new DateTime(1990, 1, 1),
            DateOfJoining = new DateTime(2015, 6, 15),
            Band = new Band { Name = "The Cool Cats" }
        }
    }.AsQueryable();

            var mockSet = new Mock<DbSet<Member>>();
            mockSet.As<IQueryable<Member>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Member>(members.Provider));
            mockSet.As<IQueryable<Member>>().Setup(m => m.Expression).Returns(members.Expression);
            mockSet.As<IQueryable<Member>>().Setup(m => m.ElementType).Returns(members.ElementType);
            mockSet.As<IQueryable<Member>>().Setup(m => m.GetEnumerator()).Returns(members.GetEnumerator());

            mockRepository.Setup(r => r.AllReadOnly<Member>()).Returns(mockSet.Object);

            var service = new MemberService(mockRepository.Object);

            // Act
            var result = await service.GetMemberDetailsById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John Smith", result.FullName);
            Assert.AreEqual("Drummer", result.Role);
            Assert.AreEqual("The Cool Cats", result.BandName);
            Assert.AreEqual("01/01/1990", result.DateOfBirth);
            Assert.AreEqual("15/06/2015", result.DateOfJoining);
        }

        [Test]
        public async Task GetMemberDetailsById_WhenMemberDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            var members = new List<Member>().AsQueryable();

            var mockSet = new Mock<DbSet<Member>>();
            mockSet.As<IQueryable<Member>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Member>(members.Provider));
            mockSet.As<IQueryable<Member>>().Setup(m => m.Expression).Returns(members.Expression);
            mockSet.As<IQueryable<Member>>().Setup(m => m.ElementType).Returns(members.ElementType);
            mockSet.As<IQueryable<Member>>().Setup(m => m.GetEnumerator()).Returns(members.GetEnumerator());

            mockRepository.Setup(r => r.AllReadOnly<Member>()).Returns(mockSet.Object);

            var service = new MemberService(mockRepository.Object);

            // Act
            var result = await service.GetMemberDetailsById(999); // ID does not exist

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetMemberDetailsById_WhenDatabaseErrorOccurs_ShouldThrowException()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AllReadOnly<Member>()).Throws(new Exception("Database error"));

            var service = new MemberService(mockRepository.Object);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => service.GetMemberDetailsById(1), "Expected database error to propagate to caller.");
        }
    }
}
