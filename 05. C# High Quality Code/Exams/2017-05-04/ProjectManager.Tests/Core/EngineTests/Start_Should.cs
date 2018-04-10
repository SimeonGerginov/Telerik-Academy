using System;
using System.Text;

using Moq;
using NUnit.Framework;

using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Core;
using ProjectManager.Core.Contracts;

namespace ProjectManager.Tests.Core.EngineTests
{
    [TestFixture]
    public class Start_Should
    {
        [Test]
        public void CallReadLineMethodOfReaderOnce()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var processorMock = new Mock<ICommandProcessor>();
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();

            readerMock.Setup(r => r.ReadLine()).Returns("Exit");

            IEngine engine = new Engine(loggerMock.Object, processorMock.Object, readerMock.Object, writerMock.Object);

            // Act
            engine.Start();

            // Assert
            readerMock.Verify(r => r.ReadLine(), Times.Once());
        }

        [Test]
        public void CallWriteLineMethodOfWriterOnce()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var processorMock = new Mock<ICommandProcessor>();
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();

            string terminationMessage = "Program terminated.";

            readerMock.Setup(r => r.ReadLine()).Returns("Exit");
            writerMock.Setup(w => w.WriteLine(terminationMessage));

            IEngine engine = new Engine(loggerMock.Object, processorMock.Object, readerMock.Object, writerMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(w => w.WriteLine(terminationMessage), Times.Once());
        }

        [Test]
        public void WriteTheCommandExecutionResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var processorMock = new Mock<ICommandProcessor>();
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();

            string commandAsString = "CreateProject DeathStar 2016-1-1 2018-05-04 Active";
            string executionResult = "Successfully created a new project!";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(executionResult);

            readerMock.Setup(r => r.ReadLine()).Returns(commandAsString).Callback(() => 
            {
                readerMock.Setup(r => r.ReadLine()).Returns("Exit");
            });
            processorMock.Setup(p => p.Process(commandAsString)).Returns(executionResult);
            writerMock.Setup(w => w.Write(sb.ToString()));

            IEngine engine = new Engine(loggerMock.Object, processorMock.Object, readerMock.Object, writerMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(w => w.Write(sb.ToString()), Times.Once());
        }

        [Test]
        public void WriteExceptionMessage_WhenUserValidationExceptionOccurs()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var processorMock = new Mock<ICommandProcessor>();
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();

            string commandAsString = "CreateProject DeathStar 2016-1-1 2018-05-04";
            string exceptionMessage = "Invalid command parameters count!";
            UserValidationException userValidationException = new UserValidationException(exceptionMessage);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(userValidationException.Message);

            readerMock.Setup(r => r.ReadLine()).Returns(commandAsString).Callback(() =>
            {
                readerMock.Setup(r => r.ReadLine()).Returns("Exit");
            });
            processorMock.Setup(p => p.Process(commandAsString)).Throws(userValidationException);
            writerMock.Setup(w => w.Write(sb.ToString()));

            IEngine engine = new Engine(loggerMock.Object, processorMock.Object, readerMock.Object, writerMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(w => w.Write(sb.ToString()), Times.Once());
        }

        [Test]
        public void LogExceptionMessage_WhenGenericExceptionOccurs()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var processorMock = new Mock<ICommandProcessor>();
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();

            string commandAsString = "CreateProject DeathStar 2016-1-1 2018-05-04 Active";
            string exceptionMessage = "Invalid command!";
            Exception genericException = new Exception(exceptionMessage);

            readerMock.Setup(r => r.ReadLine()).Returns(commandAsString).Callback(() =>
            {
                readerMock.Setup(r => r.ReadLine()).Returns("Exit");
            });
            loggerMock.Setup(l => l.Error(genericException.Message));
            processorMock.Setup(p => p.Process(commandAsString)).Throws(genericException);

            IEngine engine = new Engine(loggerMock.Object, processorMock.Object, readerMock.Object, writerMock.Object);

            // Act
            engine.Start();

            // Assert
            loggerMock.Verify(l => l.Error(genericException.Message), Times.Once());
        }

        [Test]
        public void WriteSomethingHappened_WhenGenericExceptionOccurs()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var processorMock = new Mock<ICommandProcessor>();
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();

            string commandAsString = "CreateProject DeathStar 2016-1-1 2018-05-04 Active";
            string exceptionMessage = "Invalid command!";
            Exception genericException = new Exception(exceptionMessage);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Something happened!");

            readerMock.Setup(r => r.ReadLine()).Returns(commandAsString).Callback(() =>
            {
                readerMock.Setup(r => r.ReadLine()).Returns("Exit");
            });
            processorMock.Setup(p => p.Process(commandAsString)).Throws(genericException);
            writerMock.Setup(w => w.Write(sb.ToString()));

            IEngine engine = new Engine(loggerMock.Object, processorMock.Object, readerMock.Object, writerMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(w => w.Write(sb.ToString()), Times.Once());
        }
    }
}
