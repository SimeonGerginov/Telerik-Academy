using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using ProjectManager.Commands.Contracts;
using ProjectManager.Commands.Creational;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Factories.Contracts;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Tests.Commands.Creational.CreateTaskCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void ThrowUserValidationException_WhenTheParametersCountIsInvalid()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();

            IList<string> parameters = new List<string>()
            {
                "parameter 1",
                "parameter 2",
                "parameter 3"
            };

            ICommand createTaskCommand = new CreateTaskCommand(databaseMock.Object, factoryMock.Object);

            // Act && Assert
            Assert.Throws<UserValidationException>(() => createTaskCommand.Execute(parameters));
        }

        [Test]
        public void ThrowUserValidationException_WhenEmptyParametersArePassed()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();

            IList<string> parameters = new List<string>()
            {
                "parameter 1",
                "parameter 2",
                "parameter 3",
                string.Empty
            };

            ICommand createTaskCommand = new CreateTaskCommand(databaseMock.Object, factoryMock.Object);

            // Act && Assert
            Assert.Throws<UserValidationException>(() => createTaskCommand.Execute(parameters));
        }

        [Test]
        public void CallTheProjectsPropertyIndexer_WithThePassedId()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();
            var projectMock = new Mock<IProject>();
            var userMock = new Mock<IUser>();

            int projectId = 0;
            int userId = 0;

            IList<string> parameters = new List<string>()
            {
                "0",
                "0",
                "BuildTheStar",
                "Pending"
            };

            databaseMock.Setup(d => d.Projects[projectId]).Returns(projectMock.Object);
            databaseMock.Setup(d => d.Projects[projectId].Users[userId]).Returns(userMock.Object);
            databaseMock.Setup(d => d.Projects[projectId].Tasks).Returns(new List<ITask>());

            ICommand createTaskCommand = new CreateTaskCommand(databaseMock.Object, factoryMock.Object);

            // Act 
            createTaskCommand.Execute(parameters);

            // Assert
            databaseMock.Verify(d => d.Projects[projectId], Times.Exactly(2));
        }

        [Test]
        public void CallTheUsersPropertyIndexerOfTheProject_WithThePassedId()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();
            var projectMock = new Mock<IProject>();
            var userMock = new Mock<IUser>();

            int projectId = 0;
            int userId = 0;

            IList<string> parameters = new List<string>()
            {
                "0",
                "0",
                "BuildTheStar",
                "Pending"
            };

            databaseMock.Setup(d => d.Projects[projectId]).Returns(projectMock.Object);
            databaseMock.Setup(d => d.Projects[projectId].Users[userId]).Returns(userMock.Object);
            databaseMock.Setup(d => d.Projects[projectId].Tasks).Returns(new List<ITask>());

            ICommand createTaskCommand = new CreateTaskCommand(databaseMock.Object, factoryMock.Object);

            // Act 
            createTaskCommand.Execute(parameters);

            // Assert
            databaseMock.Verify(d => d.Projects[projectId].Users[userId], Times.Exactly(2));
        }

        [Test]
        public void CreateTask_WithExactlyThoseParameters()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();
            var projectMock = new Mock<IProject>();
            var userMock = new Mock<IUser>();
            var taskMock = new Mock<ITask>();

            int projectId = 0;
            int userId = 0;
            string taskName = "BuildTheStar";
            string taskStateAsString = "Pending";

            IList<string> parameters = new List<string>()
            {
                "0",
                "0",
                taskName,
                taskStateAsString
            };

            databaseMock.Setup(d => d.Projects[projectId]).Returns(projectMock.Object);
            databaseMock.Setup(d => d.Projects[projectId].Users[userId]).Returns(userMock.Object);
            databaseMock.Setup(d => d.Projects[projectId].Tasks).Returns(new List<ITask>());

            factoryMock.Setup(f => f.CreateTask(userMock.Object, taskName, taskStateAsString)).Returns(taskMock.Object);

            ICommand createTaskCommand = new CreateTaskCommand(databaseMock.Object, factoryMock.Object);

            // Act 
            createTaskCommand.Execute(parameters);

            // Assert
            factoryMock.Verify(f => f.CreateTask(userMock.Object, taskName, taskStateAsString), Times.Once());
        }

        [Test]
        public void AddTheTaskToTheProjectsTasks()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();
            var projectMock = new Mock<IProject>();
            var userMock = new Mock<IUser>();
            var taskMock = new Mock<ITask>();

            int projectId = 0;
            int userId = 0;
            string taskName = "BuildTheStar";
            string taskStateAsString = "Pending";

            IList<string> parameters = new List<string>()
            {
                "0",
                "0",
                taskName,
                taskStateAsString
            };

            IList<ITask> tasks = new List<ITask>();

            databaseMock.Setup(d => d.Projects[projectId]).Returns(projectMock.Object);
            databaseMock.Setup(d => d.Projects[projectId].Users[userId]).Returns(userMock.Object);
            databaseMock.Setup(d => d.Projects[projectId].Tasks).Returns(tasks);

            factoryMock.Setup(f => f.CreateTask(userMock.Object, taskName, taskStateAsString)).Returns(taskMock.Object);

            ICommand createTaskCommand = new CreateTaskCommand(databaseMock.Object, factoryMock.Object);

            // Act 
            createTaskCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(1, tasks.Count);
            Assert.That(tasks.Contains(taskMock.Object));
        }

        [Test]
        public void ReturnSuccessMessage_WhenTheTaskIsAddedToTheProjectTasks()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();
            var projectMock = new Mock<IProject>();
            var userMock = new Mock<IUser>();
            var taskMock = new Mock<ITask>();

            int projectId = 0;
            int userId = 0;
            string taskName = "BuildTheStar";
            string taskStateAsString = "Pending";
            string successMessage = "Successfully created";

            IList<string> parameters = new List<string>()
            {
                "0",
                "0",
                taskName,
                taskStateAsString
            };

            IList<ITask> tasks = new List<ITask>();

            databaseMock.Setup(d => d.Projects[projectId]).Returns(projectMock.Object);
            databaseMock.Setup(d => d.Projects[projectId].Users[userId]).Returns(userMock.Object);
            databaseMock.Setup(d => d.Projects[projectId].Tasks).Returns(tasks);

            factoryMock.Setup(f => f.CreateTask(userMock.Object, taskName, taskStateAsString)).Returns(taskMock.Object);

            ICommand createTaskCommand = new CreateTaskCommand(databaseMock.Object, factoryMock.Object);

            // Act 
            string executionResult = createTaskCommand.Execute(parameters);

            // Assert
            StringAssert.Contains(successMessage, executionResult);
        }
    }
}
