using System;

using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;

using Moq;
using NUnit.Framework;

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
            var version = new Mock<IVersion>();

            Package package = new Package(name, version.Object);

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => package.CompareTo(null));
        }

        [Test]
        public void ThrowArgumentException_WhenPackageNameIsDifferent()
        {
            // Arrange
            string name = "Package name";
            var version = new Mock<IVersion>();
            var otherPackage = new Mock<IPackage>();

            otherPackage.Setup(p => p.Name).Returns("Other Package");

            Package package = new Package(name, version.Object);

            // Act && Assert
            Assert.Throws<ArgumentException>(() => package.CompareTo(otherPackage.Object));
        }

        [Test]
        public void ReturnMinusOne_WhenThePassedPackageHasHigherVersion()
        {
            // Arrange
            string name = "Package";
            var version = new Mock<IVersion>();
            var otherPackage = new Mock<IPackage>();

            version.Setup(v => v.Major).Returns(5);
            version.Setup(v => v.Minor).Returns(3);
            version.Setup(v => v.Patch).Returns(4);
            version.Setup(v => v.VersionType).Returns(VersionType.alpha);

            otherPackage.Setup(p => p.Name).Returns(name);
            otherPackage.Setup(p => p.Version.Major).Returns(6);
            otherPackage.Setup(p => p.Version.Minor).Returns(3);
            otherPackage.Setup(p => p.Version.Patch).Returns(4);
            otherPackage.Setup(v => v.Version.VersionType).Returns(VersionType.alpha);

            int expectedResult = -1;

            Package package = new Package(name, version.Object);

            // Act
            int actualResult = package.CompareTo(otherPackage.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ReturnOne_WhenThePassedPackageHasLowerVersion()
        {
            // Arrange
            string name = "Package";
            var version = new Mock<IVersion>();
            var otherPackage = new Mock<IPackage>();

            version.Setup(v => v.Major).Returns(5);
            version.Setup(v => v.Minor).Returns(3);
            version.Setup(v => v.Patch).Returns(4);
            version.Setup(v => v.VersionType).Returns(VersionType.alpha);

            otherPackage.Setup(p => p.Name).Returns(name);
            otherPackage.Setup(p => p.Version.Major).Returns(2);
            otherPackage.Setup(p => p.Version.Minor).Returns(3);
            otherPackage.Setup(p => p.Version.Patch).Returns(4);
            otherPackage.Setup(v => v.Version.VersionType).Returns(VersionType.alpha);

            int expectedResult = 1;

            Package package = new Package(name, version.Object);

            // Act
            int actualResult = package.CompareTo(otherPackage.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ReturnZero_WhenThePassedPackageHasEqualVersion()
        {
            // Arrange
            string name = "Package";
            var version = new Mock<IVersion>();
            var otherPackage = new Mock<IPackage>();

            version.Setup(v => v.Major).Returns(5);
            version.Setup(v => v.Minor).Returns(3);
            version.Setup(v => v.Patch).Returns(4);
            version.Setup(v => v.VersionType).Returns(VersionType.alpha);

            otherPackage.Setup(p => p.Name).Returns(name);
            otherPackage.Setup(p => p.Version.Major).Returns(5);
            otherPackage.Setup(p => p.Version.Minor).Returns(3);
            otherPackage.Setup(p => p.Version.Patch).Returns(4);
            otherPackage.Setup(v => v.Version.VersionType).Returns(VersionType.alpha);

            int expectedResult = 0;

            Package package = new Package(name, version.Object);

            // Act
            int actualResult = package.CompareTo(otherPackage.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
