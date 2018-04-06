using System;

using Moq;
using NUnit.Framework;

using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class CompareTo_Should
    {
        [Test]
        public void ThrowArgumentNullException_IfPassedPackageIsNull()
        {
            // Arrange
            string name = "Package name";
            var versionMock = new Mock<IVersion>();

            Package package = new Package(name, versionMock.Object);

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => package.CompareTo(null));
        }

        [Test]
        public void ThrowArgumentException_WhenPackageNameIsDifferent()
        {
            // Arrange
            string name = "Package name";
            var versionMock = new Mock<IVersion>();
            var otherPackageMock = new Mock<IPackage>();

            otherPackageMock.Setup(p => p.Name).Returns("Other Package");

            Package package = new Package(name, versionMock.Object);

            // Act && Assert
            Assert.Throws<ArgumentException>(() => package.CompareTo(otherPackageMock.Object));
        }

        [Test]
        public void ReturnMinusOne_WhenThePassedPackageHasHigherVersion()
        {
            // Arrange
            string name = "Package";
            var versionMock = new Mock<IVersion>();
            var otherPackageMock = new Mock<IPackage>();

            versionMock.Setup(v => v.Major).Returns(5);
            versionMock.Setup(v => v.Minor).Returns(3);
            versionMock.Setup(v => v.Patch).Returns(4);
            versionMock.Setup(v => v.VersionType).Returns(VersionType.alpha);

            otherPackageMock.Setup(p => p.Name).Returns(name);
            otherPackageMock.Setup(p => p.Version.Major).Returns(6);
            otherPackageMock.Setup(p => p.Version.Minor).Returns(3);
            otherPackageMock.Setup(p => p.Version.Patch).Returns(4);
            otherPackageMock.Setup(v => v.Version.VersionType).Returns(VersionType.alpha);

            int expectedResult = -1;

            Package package = new Package(name, versionMock.Object);

            // Act
            int actualResult = package.CompareTo(otherPackageMock.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ReturnOne_WhenThePassedPackageHasLowerVersion()
        {
            // Arrange
            string name = "Package";
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

            int expectedResult = 1;

            Package package = new Package(name, versionMock.Object);

            // Act
            int actualResult = package.CompareTo(otherPackageMock.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ReturnZero_WhenThePassedPackageHasEqualVersion()
        {
            // Arrange
            string name = "Package";
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

            int expectedResult = 0;

            Package package = new Package(name, versionMock.Object);

            // Act
            int actualResult = package.CompareTo(otherPackageMock.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
