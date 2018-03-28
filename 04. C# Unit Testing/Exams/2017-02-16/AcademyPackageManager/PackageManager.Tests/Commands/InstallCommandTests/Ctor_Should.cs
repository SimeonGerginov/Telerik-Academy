using System;

using PackageManager.Enums;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Extensions;
using PackageManager.Commands;

using Moq;
using NUnit.Framework;

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
            var installCommand = new InstallCommandExtended(installer.Object, package.Object);

            // Assert
            Assert.IsInstanceOf<InstallCommand>(installCommand);
        }

        [Test]
        public void ThrowArgumentNullException_WhenInstallerIsNull()
        {
            // Arrange
            var package = new Mock<IPackage>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommandExtended(null, package.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPackageIsNull()
        {
            // Arrange
            var installer = new Mock<IInstaller<IPackage>>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommandExtended(installer.Object, null));
        }

        [Test]
        public void SetTheCorrectValuesForTheMembersOfTheClass()
        {
            // Arrange
            var installer = new Mock<IInstaller<IPackage>>();
            var package = new Mock<IPackage>();
            var expectedOperation = InstallerOperation.Install;

            // Act
            var installCommand = new InstallCommandExtended(installer.Object, package.Object);
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
