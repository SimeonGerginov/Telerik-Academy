using System;
using System.Collections.Generic;

using PackageManager.Models;
using PackageManager.Enums;
using PackageManager.Models.Contracts;

using Moq;
using NUnit.Framework;

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
            var version = new Mock<IVersion>();

            // Act
            Package package = new Package(name, version.Object);

            // Assert
            Assert.IsInstanceOf<Package>(package);
        }

        [Test]
        public void ThrowAnArgumentNullException_WhenPassedNameIsNull()
        {
            // Arrange
            var version = new Mock<IVersion>();

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Package(null, version.Object));
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
            var version = new Mock<IVersion>();

            // Act
            Package package = new Package(name, version.Object);

            // Assert
            Assert.IsInstanceOf<HashSet<IPackage>>(package.Dependencies);
        }

        [Test]
        public void SetTheDependencies_WhenThePassedParameterIsNotNull()
        {
            // Arrange
            string name = "Package";
            var version = new Mock<IVersion>();

            var dependencies = new Mock<ICollection<IPackage>>();
            ICollection<IPackage> expectedDependencies = dependencies.Object;

            // Act
            Package package = new Package(name, version.Object, expectedDependencies);
            ICollection<IPackage> actualDependencies = package.Dependencies;

            // Assert
            Assert.AreEqual(expectedDependencies, actualDependencies);
        }

        [Test]
        public void SetThePropertiesOfThePackageCorrectly()
        {
            // Arrange
            string name = "Package";
            var version = new Mock<IVersion>();
            var dependencies = new Mock<ICollection<IPackage>>();

            version.Setup(v => v.Major).Returns(5);
            version.Setup(v => v.Minor).Returns(3);
            version.Setup(v => v.Patch).Returns(4);
            version.Setup(v => v.VersionType).Returns(VersionType.alpha);

            ICollection<IPackage> expectedDependencies = dependencies.Object;
            IVersion expectedVersion = version.Object;
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
