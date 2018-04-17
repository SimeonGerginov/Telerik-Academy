using System;

using Moq;
using NUnit.Framework;

using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.Tests.Client.Interceptors.LogErrorInterceptorTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenLoggerIsNull()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(null, writerMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenWriterIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(loggerMock.Object, null));
        }
    }
}
