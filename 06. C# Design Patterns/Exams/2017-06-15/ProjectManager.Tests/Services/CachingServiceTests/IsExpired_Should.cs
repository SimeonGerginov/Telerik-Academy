using System;

using Moq;
using NUnit.Framework;

using ProjectManager.Common;
using ProjectManager.Tests.Services.CachingServiceTests.Mocks;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class IsExpired_Should
    {
        [Test]
        public void ReturnTrue_IfCurrentDateIsBiggerThanTheTimeExpiring()
        {
            // Arrange
            DateTime returnDate = new DateTime(2018, 4, 17, 12, 0, 0);
            DateTime anotherReturnDate = new DateTime(2018, 4, 17, 12, 5, 0);

            var dateTimeMock = new Mock<DateTimeProvider>();

            dateTimeMock.Setup(d => d.UtcNow).Returns(returnDate);
            DateTimeProvider.Current = dateTimeMock.Object;

            var cachingService = new CachingServiceMock(TimeSpan.FromSeconds(20));

            dateTimeMock.Setup(d => d.UtcNow).Returns(anotherReturnDate);
            DateTimeProvider.Current = dateTimeMock.Object;

            // Act
            bool result = cachingService.IsExpired;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnFakse_IfCurrentDateIsNotBiggerThanTheTimeExpiring()
        {
            // Arrange
            DateTime returnDate = new DateTime(2018, 4, 17, 12, 0, 0);
            DateTime anotherReturnDate = new DateTime(2018, 4, 17, 11, 50, 0);

            var dateTimeMock = new Mock<DateTimeProvider>();

            dateTimeMock.Setup(d => d.UtcNow).Returns(returnDate);
            DateTimeProvider.Current = dateTimeMock.Object;

            var cachingService = new CachingServiceMock(TimeSpan.FromSeconds(20));

            dateTimeMock.Setup(d => d.UtcNow).Returns(anotherReturnDate);
            DateTimeProvider.Current = dateTimeMock.Object;

            // Act
            bool result = cachingService.IsExpired;

            // Assert
            Assert.IsFalse(result);
        }

        [TearDown]
        public void ResetDateTimeProvider()
        {
            DateTimeProvider.ResetToDefault();
        }
    }
}
