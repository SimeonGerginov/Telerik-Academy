using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using SchoolSystem.CLI.Enums;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.Tests.Models.TeacherTests
{
    [TestFixture]
    public class AddMark_Should
    {
        [Test]
        public void ThrowArgumentException_WhenTheStudentHasTwentyMarks()
        {
            // Arrange
            string firstName = "Ivan";
            string lastName = "Ivanov";
            Subject subject = Subject.Bulgarian;

            var markMock = new Mock<IMark>();
            var studentMock = new Mock<IStudent>();
            IList<IMark> marks = Enumerable.Repeat(markMock.Object, 20).ToList();
            float markValue = 2;

            studentMock.Setup(s => s.Marks).Returns(marks);

            ITeacher teacher = new Teacher(firstName, lastName, subject);

            // Act && Arrange
            Assert.Throws<ArgumentException>(() => teacher.AddMark(studentMock.Object, markValue));
        }

        [Test]
        public void AddTheMarkToTheStudentMarks()
        {
            // Arrange
            string firstName = "Ivan";
            string lastName = "Ivanov";
            Subject subject = Subject.Bulgarian;

            var markMock = new Mock<IMark>();
            var studentMock = new Mock<IStudent>();
            float markValue = 2;

            studentMock.Setup(s => s.Marks).Returns(new List<IMark>());

            ITeacher teacher = new Teacher(firstName, lastName, subject);

            // Act
            teacher.AddMark(studentMock.Object, markValue);

            // Assert
            Assert.AreEqual(subject, studentMock.Object.Marks.Single().Subject);
            Assert.AreEqual(markValue, studentMock.Object.Marks.Single().Value);
        }
    }
}
