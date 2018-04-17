using System;

using Moq;
using NUnit.Framework;

using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.Core.Commands.Decorators.CacheableCommandTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ReturnAnInstanceOfCacheableCommand()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            var cachingServiceMock = new Mock<ICachingService>();

            // Act
            ICommand cacheableCommand = new CacheableCommand(commandMock.Object, cachingServiceMock.Object);

            // Assert
            Assert.IsInstanceOf<CacheableCommand>(cacheableCommand);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedCommandIsNull()
        {
            // Arrange
            var cachingServiceMock = new Mock<ICachingService>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(null, cachingServiceMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedCachingServiceIsNull()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(commandMock.Object, null));
        }

        [Test]
        public void SetTheParametersCountPropertyCorrectly()
        {
            // Arrange
            int parametersCount = 4;
            var commandMock = new Mock<ICommand>();
            var cachingServiceMock = new Mock<ICachingService>();

            commandMock.Setup(c => c.ParameterCount).Returns(parametersCount);

            // Act
            ICommand cacheableCommand = new CacheableCommand(commandMock.Object, cachingServiceMock.Object);

            // Assert
            Assert.AreEqual(parametersCount, cacheableCommand.ParameterCount);
        }
    }
}
