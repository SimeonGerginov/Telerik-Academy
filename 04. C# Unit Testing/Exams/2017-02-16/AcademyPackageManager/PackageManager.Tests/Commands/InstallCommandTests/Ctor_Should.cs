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
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var installCommand = new InstallCommandMock(installerMock.Object, packageMock.Object);

            // Assert
            Assert.IsInstanceOf<InstallCommand>(installCommand);
        }

        [Test]
        public void ThrowArgumentNullException_WhenInstallerIsNull()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommandMock(null, packageMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPackageIsNull()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommandMock(installerMock.Object, null));
        }

        [Test]
        public void SetTheCorrectValuesForTheMembersOfTheClass()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();
            var expectedOperation = InstallerOperation.Install;

            // Act
            var installCommand = new InstallCommandMock(installerMock.Object, packageMock.Object);
            var actualInstaller = installCommand.MyInstaller;
            var actualPackage = installCommand.MyPackage;
            var actualOperation = installCommand.MyInstaller.Operation;

            // Assert
            Assert.AreEqual(installerMock.Object, actualInstaller);
            Assert.AreEqual(packageMock.Object, actualPackage);
            Assert.AreEqual(expectedOperation, actualOperation);
        }
    }
}
