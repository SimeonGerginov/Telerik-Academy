using System;
using NUnit.Framework;

using SchoolSystem.CLI.Enums;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.Tests.Models.TeacherTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ReturnAnInstanceOfTeacher()
        {
            // Arrange
            string firstName = "Ivan";
            string lastName = "Ivanov";
            Subject subject = Subject.Bulgarian;

            // Act
            ITeacher teacher = new Teacher(firstName, lastName, subject);

            // Assert
            Assert.IsInstanceOf<Teacher>(teacher);
        }

        [Test]
        public void SetTheMembersOfTheClassProperly()
        {
            // Arrange
            string firstName = "Ivan";
            string lastName = "Ivanov";
            Subject subject = Subject.Bulgarian;

            // Act
            ITeacher teacher = new Teacher(firstName, lastName, subject);

            // Assert
            Assert.AreEqual(firstName, teacher.FirstName);
            Assert.AreEqual(lastName, teacher.LastName);
            Assert.AreEqual(subject, teacher.Subject);
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedFirstNameIsInvalid()
        {
            // Arrange
            string firstName = "I";
            string lastName = "Ivanov";
            Subject subject = Subject.Bulgarian;

            // Act
            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedLastNameIsInvalid()
        {
            // Arrange
            string firstName = "Ivan";
            string lastName = "I";
            Subject subject = Subject.Bulgarian;

            // Act
            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }
    }
}
