using System;

using Moq;
using Ninject.Extensions.Interception;
using NUnit.Framework;

using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.Tests.Client.Interceptors.LogErrorInterceptorTests
{
    [TestFixture]
    public class Intercept_Should
    {
        [Test]
        public void CallProceedOnce()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var writerMock = new Mock<IWriter>();
            var invocationMock = new Mock<IInvocation>();

            invocationMock.Setup(i => i.Proceed());

            LogErrorInterceptor logErrorInterceptor = new LogErrorInterceptor(loggerMock.Object, writerMock.Object);

            // Act
            logErrorInterceptor.Intercept(invocationMock.Object);

            // Assert
            invocationMock.Verify(i => i.Proceed(), Times.Once());
        }

        [Test]
        public void LogErrorAndWrite_WhenUserValidationErrorOccurs()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var writerMock = new Mock<IWriter>();
            var invocationMock = new Mock<IInvocation>();

            loggerMock.Setup(l => l.Error(It.IsAny<string>()));
            writerMock.Setup(w => w.WriteLine(It.IsAny<string>()));

            LogErrorInterceptor logErrorInterceptor = new LogErrorInterceptor(loggerMock.Object, writerMock.Object);

            invocationMock.Setup(i => i.Proceed()).Throws(new UserValidationException(It.IsAny<string>()));

            // Act
            logErrorInterceptor.Intercept(invocationMock.Object);

            // Assert
            loggerMock.Verify(l => l.Error(It.IsAny<string>()), Times.Once());
            writerMock.Verify(w => w.WriteLine(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void LogFatalAndWrite_WhenExceptionOccurs()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var writerMock = new Mock<IWriter>();
            var invocationMock = new Mock<IInvocation>();

            loggerMock.Setup(l => l.Fatal(It.IsAny<string>()));
            writerMock.Setup(w => w.WriteLine(It.IsAny<string>()));

            LogErrorInterceptor logErrorInterceptor = new LogErrorInterceptor(loggerMock.Object, writerMock.Object);

            invocationMock.Setup(i => i.Proceed()).Throws(new Exception(It.IsAny<string>()));

            // Act
            logErrorInterceptor.Intercept(invocationMock.Object);

            // Assert
            loggerMock.Verify(l => l.Fatal(It.IsAny<string>()), Times.Once());
            writerMock.Verify(w => w.WriteLine(It.IsAny<string>()), Times.Once());
        }
    }
}
