using System;

using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;

using Moq;
using NUnit.Framework;

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
            var version = new Mock<IVersion>();

            Package package = new Package(name, version.Object);

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => package.Equals(null));
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedObjectIsNotAPackage()
        {
            // Arrange
            string name = "Package name";
            var version = new Mock<IVersion>();
            object otherPackage = "package";

            Package package = new Package(name, version.Object);

            // Act && Assert
            Assert.Throws<ArgumentException>(() => package.Equals(otherPackage));
        }

        [Test]
        public void ReturnFalse_WhenTheTwoPackagesAreDifferent()
        {
            // Arrange
            string name = "Package name";
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

            bool expectedResult = false;

            Package package = new Package(name, version.Object);

            // Act
            bool actualResult = package.Equals(otherPackage.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ReturnTrue_WhenTheTwoPackagesAreTheSame()
        {
            // Arrange
            string name = "Package name";
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

            bool expectedResult = true;

            Package package = new Package(name, version.Object);

            // Act
            bool actualResult = package.Equals(otherPackage.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
