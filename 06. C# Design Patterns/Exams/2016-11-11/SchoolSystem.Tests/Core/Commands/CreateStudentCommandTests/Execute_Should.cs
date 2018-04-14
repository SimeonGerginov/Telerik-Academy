using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Tests.Core.Commands.CreateStudentCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void CreateStudent_WithTheGivenParameters()
        {
            // Arrange
            string firstName = "Pesho";
            string lastName = "Petrov";
            string gradeAsString = "10";
            Grade grade = (Grade)int.Parse(gradeAsString);

            IList<string> parameters = new List<string>()
            {
                firstName,
                lastName,
                gradeAsString
            };

            var studentFactoryMock = new Mock<IStudentFactory>();
            var addStudentMock = new Mock<IAddStudent>();
            var studentMock = new Mock<IStudent>();

            studentFactoryMock.Setup(sf => sf.CreateStudent(firstName, lastName, grade)).Returns(studentMock.Object);

            ICommand createStudentCommand = new CreateStudentCommand(studentFactoryMock.Object, addStudentMock.Object);

            // Act
            createStudentCommand.Execute(parameters);

            // Assert
            studentFactoryMock.Verify(sf => sf.CreateStudent(firstName, lastName, grade), Times.Once());
        }

        [Test]
        public void AddTheStudent_WithTheGivenParameters()
        {
            // Arrange
            int currentStudentId = 0;
            string firstName = "Pesho";
            string lastName = "Petrov";
            string gradeAsString = "10";
            Grade grade = (Grade)int.Parse(gradeAsString);

            IList<string> parameters = new List<string>()
            {
                firstName,
                lastName,
                gradeAsString
            };

            var studentFactoryMock = new Mock<IStudentFactory>();
            var addStudentMock = new Mock<IAddStudent>();
            var studentMock = new Mock<IStudent>();

            studentFactoryMock.Setup(sf => sf.CreateStudent(firstName, lastName, grade)).Returns(studentMock.Object);
            addStudentMock.Setup(s => s.AddStudent(currentStudentId, studentMock.Object));

            ICommand createStudentCommand = new CreateStudentCommand(studentFactoryMock.Object, addStudentMock.Object);

            // Act
            createStudentCommand.Execute(parameters);

            // Assert
            addStudentMock.Verify(s => s.AddStudent(currentStudentId, studentMock.Object), Times.Once());
        }

        [Test]
        public void ReturnSuccessMessage_WhenTheStudentIsAdded()
        {
            // Arrange
            int currentStudentId = 0;
            string firstName = "Pesho";
            string lastName = "Petrov";
            string gradeAsString = "10";
            Grade grade = (Grade)int.Parse(gradeAsString);

            string successMessage = $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentStudentId++} was created.";

            IList<string> parameters = new List<string>()
            {
                firstName,
                lastName,
                gradeAsString
            };

            var studentFactoryMock = new Mock<IStudentFactory>();
            var addStudentMock = new Mock<IAddStudent>();
            var studentMock = new Mock<IStudent>();

            studentFactoryMock.Setup(sf => sf.CreateStudent(firstName, lastName, grade)).Returns(studentMock.Object);
            addStudentMock.Setup(s => s.AddStudent(currentStudentId, studentMock.Object));

            ICommand createStudentCommand = new CreateStudentCommand(studentFactoryMock.Object, addStudentMock.Object);

            // Act
            string executionResult = createStudentCommand.Execute(parameters);

            // Assert
            StringAssert.Contains(successMessage, executionResult);
        }
    }
}
