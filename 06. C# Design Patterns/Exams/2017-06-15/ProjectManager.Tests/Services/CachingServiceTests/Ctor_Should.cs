using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using ProjectManager.Common;
using ProjectManager.Tests.Services.CachingServiceTests.Mocks;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTheDurationIsLessThanZero()
        {
            // Arrange && Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new CachingServiceMock(TimeSpan.FromSeconds(-5.0)));
        }

        [Test]
        public void SetTheCacheDictionaryAndTimeExpiringCorrectly()
        {
            // Arrange
            DateTime returnDate = new DateTime(2018, 4, 17, 12, 0, 0);

            var dateTimeMock = new Mock<DateTimeProvider>();
            dateTimeMock.Setup(d => d.UtcNow).Returns(returnDate);

            DateTimeProvider.Current = dateTimeMock.Object;

            // Act
            var cachingService = new CachingServiceMock(TimeSpan.FromSeconds(It.IsAny<double>()));

            // Assert
            Assert.AreEqual(returnDate, cachingService.DateTimeExpiring);
            Assert.IsInstanceOf<Dictionary<string, object>>(cachingService.CacheStorage);
            Assert.AreEqual(0, cachingService.CacheStorage.Count);
        }

        [TearDown]
        public void ResetDateTimeProvider()
        {
            DateTimeProvider.ResetToDefault();
        }
    }
}
