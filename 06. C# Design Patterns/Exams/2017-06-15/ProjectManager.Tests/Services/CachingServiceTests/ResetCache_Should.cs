using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using ProjectManager.Common;
using ProjectManager.Tests.Services.CachingServiceTests.Mocks;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class ResetCache_Should
    {
        [Test]
        public void AddProperValueToTheTimeExpiring_WhenInvoked()
        {
            // Arrange
            DateTime returnDate = new DateTime(2018, 4, 17, 12, 0, 0);

            var dateTimeMock = new Mock<DateTimeProvider>();

            dateTimeMock.Setup(d => d.UtcNow).Returns(returnDate);
            DateTimeProvider.Current = dateTimeMock.Object;

            var cachingService = new CachingServiceMock(TimeSpan.FromSeconds(20));

            // Act
            cachingService.ResetCache();

            // Assert
            Assert.AreEqual(returnDate.AddSeconds(20), cachingService.DateTimeExpiring);
        }

        [Test]
        public void ClearTheCache_WhenInvoked()
        {
            // Arrange
            var cachingService = new CachingServiceMock(TimeSpan.FromSeconds(20));

            // Act
            cachingService.ResetCache();

            // Assert
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
