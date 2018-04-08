using System;

using Moq;
using NUnit.Framework;

using SchoolSystem.CLI.Core;
using SchoolSystem.CLI.Core.Contracts;

namespace SchoolSystem.Tests.Core.EngineTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ReturnAnInstanceOfEngine()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var commandParserMock = new Mock<IParser>();

            // Act
            Engine engine = new Engine(readerMock.Object, writerMock.Object, commandParserMock.Object);

            // Assert
            Assert.IsInstanceOf<Engine>(engine);
        }

        [Test]
        public void ThrowArgumentNullException_WhenReaderIsNull()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();
            var commandParserMock = new Mock<IParser>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(null, writerMock.Object, commandParserMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenWriterIsNull()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var commandParserMock = new Mock<IParser>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(readerMock.Object, null, commandParserMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenParserIsNull()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(readerMock.Object, writerMock.Object, null));
        }
    }
}
