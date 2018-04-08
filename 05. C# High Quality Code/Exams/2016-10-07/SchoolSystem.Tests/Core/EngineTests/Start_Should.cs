using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using SchoolSystem.CLI.Core;
using SchoolSystem.CLI.Core.Contracts;

namespace SchoolSystem.Tests.Core.EngineTests
{
    [TestFixture]
    public class Start_Should
    {
        [Test, Timeout(3000)]
        public void NotFallInAnInfiniteLoop_WhenValidTerminationCommandIsPassed()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandParserMock = new Mock<IParser>();

            readerMock.Setup(r => r.ReadLine()).Returns("End");

            Engine engine = new Engine(readerMock.Object, writerMock.Object, commandParserMock.Object);

            // Act && Assert
            engine.Start();
        }

        [Test]
        public void CallWriteLineOnce_WhenPassedCommandIsEmpty()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandParserMock = new Mock<IParser>();

            readerMock.Setup(r => r.ReadLine()).Returns(string.Empty).Callback(() => 
            {
                readerMock.Setup(r => r.ReadLine()).Returns("End");
            });

            Engine engine = new Engine(readerMock.Object, writerMock.Object, commandParserMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(w => w.WriteLine(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void CallWriteLineOnce_WithValidCommand()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandParserMock = new Mock<IParser>();

            readerMock.Setup(r => r.ReadLine()).Returns("CreateStudent Ivan Ivanov 1").Callback(() =>
            {
                readerMock.Setup(r => r.ReadLine()).Returns("End");
            });

            Engine engine = new Engine(readerMock.Object, writerMock.Object, commandParserMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(w => w.WriteLine(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void CallParseCommandOnce_WithValidCommand()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandParserMock = new Mock<IParser>();

            string fullCommand = "CreateStudent Ivan Ivanov 1";

            readerMock.Setup(r => r.ReadLine()).Returns(fullCommand).Callback(() =>
            {
                readerMock.Setup(r => r.ReadLine()).Returns("End");
            });

            Engine engine = new Engine(readerMock.Object, writerMock.Object, commandParserMock.Object);

            // Act
            engine.Start();

            // Assert
            commandParserMock.Verify(p => p.ParseCommand(fullCommand), Times.Once());
        }

        [Test]
        public void CallParseParametersOnce_WithValidCommand()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandParserMock = new Mock<IParser>();

            string fullCommand = "CreateStudent Ivan Ivanov 1";

            readerMock.Setup(r => r.ReadLine()).Returns(fullCommand).Callback(() =>
            {
                readerMock.Setup(r => r.ReadLine()).Returns("End");
            });

            Engine engine = new Engine(readerMock.Object, writerMock.Object, commandParserMock.Object);

            // Act
            engine.Start();

            // Assert
            commandParserMock.Verify(p => p.ParseParameters(fullCommand), Times.Once());
        }

        [Test]
        public void CallExecuteOnce_WithValidCommand()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandParserMock = new Mock<IParser>();
            var commandMock = new Mock<ICommand>();

            string fullCommand = "CreateStudent Ivan Ivanov 1";

            readerMock.Setup(r => r.ReadLine()).Returns(fullCommand).Callback(() =>
            {
                readerMock.Setup(r => r.ReadLine()).Returns("End");
            });

            commandParserMock.Setup(p => p.ParseCommand(fullCommand)).Returns(commandMock.Object);
            commandParserMock.Setup(p => p.ParseParameters(fullCommand)).Returns(new List<string>());

            Engine engine = new Engine(readerMock.Object, writerMock.Object, commandParserMock.Object);

            // Act
            engine.Start();

            // Assert
            commandMock.Verify(c => c.Execute(It.IsAny<IList<string>>()), Times.Once());
        }
    }
}
