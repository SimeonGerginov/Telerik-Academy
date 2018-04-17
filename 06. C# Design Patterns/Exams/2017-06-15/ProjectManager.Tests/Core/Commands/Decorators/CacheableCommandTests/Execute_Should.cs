using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.Core.Commands.Decorators.CacheableCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTheParametersAreNull()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var cachingServiceMock = new Mock<ICachingService>();

            ICommand cacheableCommand = new CacheableCommand(commandMock.Object, cachingServiceMock.Object);

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => cacheableCommand.Execute(null));
        }

        [Test]
        public void CallExecuteAndResetCacheAndAddCacheValueOnce_WhenTheCacheHasExpired()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var cachingServiceMock = new Mock<ICachingService>();

            IList<string> parameters = new List<string>()
            {
                "DeathStar",
                "2016-1-1",
                "2018-05-04",
                "Active"
            };
            string methodName = "Execute";
            string result = "Result of command execution";

            commandMock.Setup(c => c.Execute(parameters)).Returns(result);

            cachingServiceMock.Setup(c => c.IsExpired).Returns(true);
            cachingServiceMock.Setup(c => c.ResetCache());
            cachingServiceMock.Setup(c => c.AddCacheValue(It.IsAny<string>(), methodName, result));

            ICommand cacheableCommand = new CacheableCommand(commandMock.Object, cachingServiceMock.Object);

            // Act
            cacheableCommand.Execute(parameters);

            // Assert
            commandMock.Verify(c => c.Execute(parameters), Times.Once());
            cachingServiceMock.Verify(c => c.ResetCache(), Times.Once());
            cachingServiceMock.Verify(c => c.AddCacheValue(It.IsAny<string>(), methodName, result), Times.Once());
        }

        [Test]
        public void CallGetCacheValueOnce_WhenTheCacheHasNotExpired()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var cachingServiceMock = new Mock<ICachingService>();

            IList<string> parameters = new List<string>()
            {
                "DeathStar",
                "2016-1-1",
                "2018-05-04",
                "Active"
            };
            string methodName = "Execute";
            string result = "Result of command execution";
            
            cachingServiceMock.Setup(c => c.IsExpired).Returns(false);
            cachingServiceMock.Setup(c => c.GetCacheValue(It.IsAny<string>(), methodName)).Returns(result);

            ICommand cacheableCommand = new CacheableCommand(commandMock.Object, cachingServiceMock.Object);

            // Act
            cacheableCommand.Execute(parameters);

            // Assert
            cachingServiceMock.Verify(c => c.GetCacheValue(It.IsAny<string>(), methodName), Times.Once());
        }

        [Test]
        public void ReturnTheCorrectResult_WhenTheCacheHasExpired()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var cachingServiceMock = new Mock<ICachingService>();

            IList<string> parameters = new List<string>()
            {
                "DeathStar",
                "2016-1-1",
                "2018-05-04",
                "Active"
            };
            string methodName = "Execute";
            string result = "Result of command execution";

            commandMock.Setup(c => c.Execute(parameters)).Returns(result);

            cachingServiceMock.Setup(c => c.IsExpired).Returns(true);
            cachingServiceMock.Setup(c => c.ResetCache());
            cachingServiceMock.Setup(c => c.AddCacheValue(It.IsAny<string>(), methodName, result));

            ICommand cacheableCommand = new CacheableCommand(commandMock.Object, cachingServiceMock.Object);

            // Act
            string actualResult = cacheableCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(result, actualResult);
        }

        [Test]
        public void ReturnTheCorrectResult_WhenTheCacheHasNotExpired()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var cachingServiceMock = new Mock<ICachingService>();

            IList<string> parameters = new List<string>()
            {
                "DeathStar",
                "2016-1-1",
                "2018-05-04",
                "Active"
            };
            string methodName = "Execute";
            string result = "Result of command execution";

            cachingServiceMock.Setup(c => c.IsExpired).Returns(false);
            cachingServiceMock.Setup(c => c.GetCacheValue(It.IsAny<string>(), methodName)).Returns(result);

            ICommand cacheableCommand = new CacheableCommand(commandMock.Object, cachingServiceMock.Object);

            // Act
            string actualResult = cacheableCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(result, actualResult);
        }
    }
}
