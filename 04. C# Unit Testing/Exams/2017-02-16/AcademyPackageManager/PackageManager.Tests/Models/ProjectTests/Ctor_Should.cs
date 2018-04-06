using System;

using Moq;
using NUnit.Framework;

using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Repositories.Contracts;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ReturnAnInstanceOfAProject()
        {
            // Arrange
            string name = "Project";
            string location = "Location";

            // Act
            Project project = new Project(name, location);

            // Assert
            Assert.IsInstanceOf<Project>(project);
        }

        [Test]
        public void ThrowAnArgumentNullException_WhenPassedNameIsNull()
        {
            // Arrange
            string location = "Location";

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Project(null, location));
        }

        [Test]
        public void ThrowAnArgumentNullException_WhenPassedLocationIsNull()
        {
            // Arrange
            string name = "Project";

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Project(name, null));
        }

        [Test]
        public void SetThePackages_WhenThePassedParameterIsNull()
        {
            // Arrange
            string name = "Project";
            string location = "Location";

            // Act
            Project project = new Project(name, location, null);

            // Assert
            Assert.IsInstanceOf<PackageRepository>(project.PackageRepository);
        }

        [Test]
        public void SetThePackages_WhenThePassedParameterIsNotNull()
        {
            // Arrange
            string name = "Project";
            string location = "Location";

            var packagesMock = new Mock<IRepository<IPackage>>();
            IRepository<IPackage> expectedPackages = packagesMock.Object;

            // Act
            Project project = new Project(name, location, expectedPackages);
            IRepository<IPackage> actualPackages = project.PackageRepository;

            // Assert
            Assert.AreEqual(expectedPackages, actualPackages);
        }

        [Test]
        public void SetThePropertiesOfTheProjectCorrectly()
        {
            // Arrange
            string name = "Project";
            string location = "Location";

            var packagesMock = new Mock<IRepository<IPackage>>();
            IRepository<IPackage> expectedPackages = packagesMock.Object;

            // Act
            Project project = new Project(name, location, expectedPackages);
            string actualName = project.Name;
            string actualLocation = project.Location;
            IRepository<IPackage> actualPackages = project.PackageRepository;

            // Assert
            Assert.AreEqual(name, actualName);
            Assert.AreEqual(location, actualLocation);
            Assert.AreEqual(expectedPackages, actualPackages);
        }
    }
}
