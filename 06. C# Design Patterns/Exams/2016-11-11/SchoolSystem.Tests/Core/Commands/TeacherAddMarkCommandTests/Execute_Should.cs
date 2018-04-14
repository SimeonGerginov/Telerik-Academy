using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Tests.Core.Commands.TeacherAddMarkCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void GetTheStudent_WithThePassedId()
        {
            // Arrange
            string teacherId = "0";
            string studentId = "1";
            string mark = "3.5";

            IList<string> parameters = new List<string>()
            {
                teacherId,
                studentId,
                mark
            };

            var getStudentAndTeacherMock = new Mock<IGetStudentAndTeacher>();
            var studentMock = new Mock<IStudent>();
            var teacherMock = new Mock<ITeacher>();

            getStudentAndTeacherMock.Setup(st => st.GetStudent(int.Parse(studentId))).Returns(studentMock.Object);
            getStudentAndTeacherMock.Setup(st => st.GetTeacher(int.Parse(teacherId))).Returns(teacherMock.Object);

            ICommand teacherAddMarkCommand = new TeacherAddMarkCommand(getStudentAndTeacherMock.Object);

            // Act
            teacherAddMarkCommand.Execute(parameters);

            // Assert
            getStudentAndTeacherMock.Verify(st => st.GetStudent(int.Parse(studentId)), Times.Once());
        }

        [Test]
        public void GetTheTeacher_WithThePassedId()
        {
            // Arrange
            string teacherId = "0";
            string studentId = "1";
            string mark = "3.5";

            IList<string> parameters = new List<string>()
            {
                teacherId,
                studentId,
                mark
            };

            var getStudentAndTeacherMock = new Mock<IGetStudentAndTeacher>();
            var studentMock = new Mock<IStudent>();
            var teacherMock = new Mock<ITeacher>();

            getStudentAndTeacherMock.Setup(st => st.GetStudent(int.Parse(studentId))).Returns(studentMock.Object);
            getStudentAndTeacherMock.Setup(st => st.GetTeacher(int.Parse(teacherId))).Returns(teacherMock.Object);

            ICommand teacherAddMarkCommand = new TeacherAddMarkCommand(getStudentAndTeacherMock.Object);

            // Act
            teacherAddMarkCommand.Execute(parameters);

            // Assert
            getStudentAndTeacherMock.Verify(st => st.GetTeacher(int.Parse(teacherId)), Times.Once());
        }

        [Test]
        public void AddTheMarkToTheCollectionOfMarksOfTheStudent()
        {
            // Arrange
            string teacherId = "0";
            string studentId = "1";
            string mark = "3.5";

            IList<string> parameters = new List<string>()
            {
                teacherId,
                studentId,
                mark
            };

            var getStudentAndTeacherMock = new Mock<IGetStudentAndTeacher>();
            var studentMock = new Mock<IStudent>();
            var teacherMock = new Mock<ITeacher>();

            getStudentAndTeacherMock.Setup(st => st.GetStudent(int.Parse(studentId))).Returns(studentMock.Object);
            getStudentAndTeacherMock.Setup(st => st.GetTeacher(int.Parse(teacherId))).Returns(teacherMock.Object);

            teacherMock.Setup(t => t.AddMark(studentMock.Object, float.Parse(mark)));

            ICommand teacherAddMarkCommand = new TeacherAddMarkCommand(getStudentAndTeacherMock.Object);

            // Act
            teacherAddMarkCommand.Execute(parameters);

            // Assert
            teacherMock.Verify(t => t.AddMark(studentMock.Object, float.Parse(mark)), Times.Once());
        }

        [Test]
        public void ReturnSuccessMessage_WhenTheMarkIsAdded()
        {
            // Arrange
            string teacherId = "0";
            string teacherFirstName = "Teacher first name";
            string teacherLastName = "Teacher last name";
            Subject subject = Subject.Bulgarian;

            string studentId = "1";
            string studentFirstName = "Student first name";
            string studentLastName = "Student last name";
            string mark = "3.5";

            IList<string> parameters = new List<string>()
            {
                teacherId,
                studentId,
                mark
            };

            string successMessage = $"Teacher {teacherFirstName} {teacherLastName} added mark {mark} to student {studentFirstName} {studentLastName} in {subject}.";

            var getStudentAndTeacherMock = new Mock<IGetStudentAndTeacher>();
            var studentMock = new Mock<IStudent>();
            var teacherMock = new Mock<ITeacher>();

            getStudentAndTeacherMock.Setup(st => st.GetStudent(int.Parse(studentId))).Returns(studentMock.Object);
            getStudentAndTeacherMock.Setup(st => st.GetTeacher(int.Parse(teacherId))).Returns(teacherMock.Object);

            teacherMock.Setup(t => t.FirstName).Returns(teacherFirstName);
            teacherMock.Setup(t => t.LastName).Returns(teacherLastName);
            teacherMock.Setup(t => t.Subject).Returns(subject);
            teacherMock.Setup(t => t.AddMark(studentMock.Object, float.Parse(mark)));

            studentMock.Setup(s => s.FirstName).Returns(studentFirstName);
            studentMock.Setup(s => s.LastName).Returns(studentLastName);

            ICommand teacherAddMarkCommand = new TeacherAddMarkCommand(getStudentAndTeacherMock.Object);

            // Act
            string executionResult = teacherAddMarkCommand.Execute(parameters);

            // Assert
            StringAssert.Contains(successMessage, executionResult);
        }
    }
}
