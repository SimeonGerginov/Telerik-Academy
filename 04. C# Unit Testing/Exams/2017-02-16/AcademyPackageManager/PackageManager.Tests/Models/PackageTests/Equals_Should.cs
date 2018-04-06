using System;

using Moq;
using NUnit.Framework;

using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class Equals_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenThePassedObjectIsNull()
        {
            // Arrange
            string name = "Package name";
            var versionMock = new Mock<IVersion>();

            Package package = new Package(name, versionMock.Object);

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => package.Equals(null));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedObjectIsNotAPackage()
        {
            // Arrange
            string name = "Package name";
            var versionMock = new Mock<IVersion>();
            object otherPackage = "package";

            Package package = new Package(name, versionMock.Object);

            // Act && Assert
            Assert.Throws<ArgumentException>(() => package.Equals(otherPackage));
        }

        [Test]
        public void ReturnFalse_WhenTheTwoPackagesAreDifferent()
        {
            // Arrange
            string name = "Package name";
            var versionMock = new Mock<IVersion>();
            var otherPackageMock = new Mock<IPackage>();

            versionMock.Setup(v => v.Major).Returns(5);
            versionMock.Setup(v => v.Minor).Returns(3);
            versionMock.Setup(v => v.Patch).Returns(4);
            versionMock.Setup(v => v.VersionType).Returns(VersionType.alpha);

            otherPackageMock.Setup(p => p.Name).Returns(name);
            otherPackageMock.Setup(p => p.Version.Major).Returns(2);
            otherPackageMock.Setup(p => p.Version.Minor).Returns(3);
            otherPackageMock.Setup(p => p.Version.Patch).Returns(4);
            otherPackageMock.Setup(v => v.Version.VersionType).Returns(VersionType.alpha);

            bool expectedResult = false;

            Package package = new Package(name, versionMock.Object);

            // Act
            bool actualResult = package.Equals(otherPackageMock.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ReturnTrue_WhenTheTwoPackagesAreTheSame()
        {
            // Arrange
            string name = "Package name";
            var versionMock = new Mock<IVersion>();
            var otherPackageMock = new Mock<IPackage>();

            versionMock.Setup(v => v.Major).Returns(5);
            versionMock.Setup(v => v.Minor).Returns(3);
            versionMock.Setup(v => v.Patch).Returns(4);
            versionMock.Setup(v => v.VersionType).Returns(VersionType.alpha);

            otherPackageMock.Setup(p => p.Name).Returns(name);
            otherPackageMock.Setup(p => p.Version.Major).Returns(5);
            otherPackageMock.Setup(p => p.Version.Minor).Returns(3);
            otherPackageMock.Setup(p => p.Version.Patch).Returns(4);
            otherPackageMock.Setup(v => v.Version.VersionType).Returns(VersionType.alpha);

            bool expectedResult = true;

            Package package = new Package(name, versionMock.Object);

            // Act
            bool actualResult = package.Equals(otherPackageMock.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
