using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ReturnAnInstanceOfPackage()
        {
            // Arrange
            string name = "Package name";
            var versionMock = new Mock<IVersion>();

            // Act
            Package package = new Package(name, versionMock.Object);

            // Assert
            Assert.IsInstanceOf<Package>(package);
        }

        [Test]
        public void ThrowAnArgumentNullException_WhenPassedNameIsNull()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Package(null, versionMock.Object));
        }

        [Test]
        public void ThrowAnArgumentNullException_WhenPassedVersionIsNull()
        {
            // Arrange
            string name = "Package";

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Package(name, null));
        }

        [Test]
        public void SetTheDependencies_WhenThePassedParameterIsNull()
        {
            // Arrange
            string name = "Package";
            var versionMock = new Mock<IVersion>();

            // Act
            Package package = new Package(name, versionMock.Object);

            // Assert
            Assert.IsInstanceOf<HashSet<IPackage>>(package.Dependencies);
        }

        [Test]
        public void SetTheDependencies_WhenThePassedParameterIsNotNull()
        {
            // Arrange
            string name = "Package";
            var versionMock = new Mock<IVersion>();

            var dependenciesMock = new Mock<ICollection<IPackage>>();
            ICollection<IPackage> expectedDependencies = dependenciesMock.Object;

            // Act
            Package package = new Package(name, versionMock.Object, expectedDependencies);
            ICollection<IPackage> actualDependencies = package.Dependencies;

            // Assert
            Assert.AreEqual(expectedDependencies, actualDependencies);
        }

        [Test]
        public void SetThePropertiesOfThePackageCorrectly()
        {
            // Arrange
            string name = "Package";
            var versionMock = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();

            versionMock.Setup(v => v.Major).Returns(5);
            versionMock.Setup(v => v.Minor).Returns(3);
            versionMock.Setup(v => v.Patch).Returns(4);
            versionMock.Setup(v => v.VersionType).Returns(VersionType.alpha);

            ICollection<IPackage> expectedDependencies = dependenciesMock.Object;
            IVersion expectedVersion = versionMock.Object;
            string expectedUrl = string.Format("{0}.{1}.{2}-{3}", expectedVersion.Major, expectedVersion.Minor, expectedVersion.Patch, expectedVersion.VersionType);

            // Act 
            Package package = new Package(name, expectedVersion, expectedDependencies);
            string actualName = package.Name;
            IVersion actualVersion = package.Version;
            string actualUrl = package.Url;
            ICollection<IPackage> actualDependencies = package.Dependencies;

            // Assert
            Assert.AreEqual(name, actualName);
            Assert.AreEqual(expectedVersion, actualVersion);
            Assert.AreEqual(expectedDependencies, actualDependencies);
            Assert.AreEqual(expectedUrl, actualUrl);
        }
    }
}
