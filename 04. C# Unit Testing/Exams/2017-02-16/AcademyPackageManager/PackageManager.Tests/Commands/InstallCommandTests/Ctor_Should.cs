using System;

using Moq;
using NUnit.Framework;

using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Commands.InstallCommandTests.Mocks;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ReturnAnInstanceOfInstallCommand()
        {
            // Arrange
            var installer = new Mock<IInstaller<IPackage>>();
            var package = new Mock<IPackage>();

            // Act
            var installCommand = new InstallCommandMock(installer.Object, package.Object);

            // Assert
            Assert.IsInstanceOf<InstallCommand>(installCommand);
        }

        [Test]
        public void ThrowArgumentNullException_WhenInstallerIsNull()
        {
            // Arrange
            var package = new Mock<IPackage>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommandMock(null, package.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPackageIsNull()
        {
            // Arrange
            var installer = new Mock<IInstaller<IPackage>>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommandMock(installer.Object, null));
        }

        [Test]
        public void SetTheCorrectValuesForTheMembersOfTheClass()
        {
            // Arrange
            var installer = new Mock<IInstaller<IPackage>>();
            var package = new Mock<IPackage>();
            var expectedOperation = InstallerOperation.Install;

            // Act
            var installCommand = new InstallCommandMock(installer.Object, package.Object);
            var actualInstaller = installCommand.MyInstaller;
            var actualPackage = installCommand.MyPackage;
            var actualOperation = installCommand.MyInstaller.Operation;

            // Assert
            Assert.AreEqual(installer.Object, actualInstaller);
            Assert.AreEqual(package.Object, actualPackage);
            Assert.AreEqual(expectedOperation, actualOperation);
        }
    }
}
