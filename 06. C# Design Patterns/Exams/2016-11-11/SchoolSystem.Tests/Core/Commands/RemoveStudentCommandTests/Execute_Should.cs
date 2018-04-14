using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Tests.Core.Commands.RemoveStudentCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void RemoveTheStudent_WithTheGivenId()
        {
            // Arrange
            string studentId = "0";
            IList<string> parameters = new List<string>()
            {
                studentId
            };

            var removeStudentMock = new Mock<IRemoveStudent>();
            removeStudentMock.Setup(rs => rs.RemoveStudent(int.Parse(studentId)));

            ICommand removeStudent = new RemoveStudentCommand(removeStudentMock.Object);

            // Act
            removeStudent.Execute(parameters);

            // Assert
            removeStudentMock.Verify(rs => rs.RemoveStudent(int.Parse(studentId)), Times.Once());
        }

        [Test]
        public void ReturnSuccessMessage_WhenTheStudentIsRemoved()
        {
            // Arrange
            string studentId = "0";
            IList<string> parameters = new List<string>()
            {
                studentId
            };

            string successMessage = $"Student with ID {studentId} was sucessfully removed.";

            var removeStudentMock = new Mock<IRemoveStudent>();
            removeStudentMock.Setup(rs => rs.RemoveStudent(int.Parse(studentId)));

            ICommand removeStudent = new RemoveStudentCommand(removeStudentMock.Object);

            // Act
            string executionResult = removeStudent.Execute(parameters);

            // Assert
            StringAssert.Contains(successMessage, executionResult);
        }
    }
}
