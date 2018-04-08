using Moq;
using NUnit.Framework;

using SchoolSystem.CLI.Enums;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.Tests.Models.StudentTests
{
    [TestFixture]
    public class ListMarks_Should
    {
        [Test]
        public void ReturnOneLineString_WhenTheStudentsHasNoMarks()
        {
            // Arrange
            string firstName = "Ivan";
            string lastName = "Ivanov";
            Grade grade = Grade.Eleventh;
            string expectedString = "no marks";

            IStudent student = new Student(firstName, lastName, grade);

            // Act
            string marksList = student.ListMarks();

            // Assert
            StringAssert.Contains(expectedString, marksList);
        }

        [Test]
        public void ReturnListOfTheMarks_WhenTheStudentsHasMarks()
        {
            // Arrange
            string firstName = "Ivan";
            string lastName = "Ivanov";
            Grade grade = Grade.Eleventh;

            int markValue = 3;
            Subject subject = Subject.Programming;

            var markMock = new Mock<IMark>();
            markMock.Setup(m => m.Value).Returns(markValue);
            markMock.Setup(m => m.Subject).Returns(subject);

            IStudent student = new Student(firstName, lastName, grade);
            student.Marks.Add(markMock.Object);

            // Act
            string marksList = student.ListMarks();

            // Assert
            StringAssert.Contains("these marks", marksList);
            StringAssert.Contains(markValue.ToString(), marksList);
            StringAssert.Contains(subject.ToString(), marksList);
        }
    }
}
