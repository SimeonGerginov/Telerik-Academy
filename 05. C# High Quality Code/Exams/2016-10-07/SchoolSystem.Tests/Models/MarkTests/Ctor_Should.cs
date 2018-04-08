using System;
using NUnit.Framework;

using SchoolSystem.CLI.Enums;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.Tests.Models.MarkTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ReturnAnInstanceOfMark()
        {
            // Arrange
            float value = 2;
            Subject subject = Subject.Bulgarian;

            // Act
            IMark mark = new Mark(value, subject);

            // Assert
            Assert.IsInstanceOf<Mark>(mark);
        }

        [Test]
        public void SetTheMembersOfTheClassProperly()
        {
            // Arrange
            float value = 2;
            Subject subject = Subject.Bulgarian;

            // Act
            IMark mark = new Mark(value, subject);

            // Assert
            Assert.AreEqual(value, mark.Value);
            Assert.AreEqual(subject, mark.Subject);
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedValueIsInvalid()
        {
            // Arrange
            float value = 1;
            Subject subject = Subject.Bulgarian;

            // Act && Assert
            Assert.Throws<ArgumentException>(() => new Mark(value, subject));
        }
    }
}
