using System;
using System.Collections.Generic;

using NUnit.Framework;

using SchoolSystem.CLI.Enums;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.Tests.Models.StudentTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ReturnAnInstanceOfStudent()
        {
            // Arrange
            string firstName = "Ivan";
            string lastName = "Ivanov";
            Grade grade = Grade.Eleventh;

            // Act
            IStudent student = new Student(firstName, lastName, grade);

            // Assert
            Assert.IsInstanceOf<Student>(student);
        }

        [Test]
        public void SetTheMembersOfTheClassProperly()
        {
            // Arrange
            string firstName = "Ivan";
            string lastName = "Ivanov";
            Grade grade = Grade.Eleventh;

            // Act
            IStudent student = new Student(firstName, lastName, grade);

            // Assert
            Assert.AreEqual(firstName, student.FirstName);
            Assert.AreEqual(lastName, student.LastName);
            Assert.AreEqual(grade, student.Grade);
            Assert.IsInstanceOf<List<IMark>>(student.Marks);
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedFirstNameIsInvalid()
        {
            // Arrange
            string firstName = "I";
            string lastName = "Ivanov";
            Grade grade = Grade.Eleventh;

            // Act
            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedLastNameIsInvalid()
        {
            // Arrange
            string firstName = "Ivan";
            string lastName = "I";
            Grade grade = Grade.Eleventh;

            // Act
            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }
    }
}
