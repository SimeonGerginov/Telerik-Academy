using System;

using NUnit.Framework;

using PackageManager.Enums;
using PackageManager.Models;

namespace PackageManager.Tests.Models.PackageVersionTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ReturnAnInstanceOfAPackageVersion()
        {
            // Arrange
            int major = 5;
            int minor = 1;
            int patch = 3;
            VersionType versionType = VersionType.alpha;

            // Act
            PackageVersion packageVersion = new PackageVersion(major, minor, patch, versionType);

            // Assert
            Assert.IsInstanceOf<PackageVersion>(packageVersion);
        }

        [Test]
        public void SetTheAppropriatePassedValues()
        {
            // Arrange
            int major = 5;
            int minor = 1;
            int patch = 3;
            VersionType versionType = VersionType.alpha;

            // Act
            PackageVersion packageVersion = new PackageVersion(major, minor, patch, versionType);

            // Assert
            Assert.AreEqual(major, packageVersion.Major);
            Assert.AreEqual(minor, packageVersion.Minor);
            Assert.AreEqual(patch, packageVersion.Patch);
            Assert.AreEqual(versionType, packageVersion.VersionType);
        }

        [Test]
        public void ThrowsArgumentExceptionWhenMajorIsNegative()
        {
            // Arrange
            int major = -5;
            int minor = 1;
            int patch = 3;
            VersionType versionType = VersionType.alpha;

            // Act && Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, versionType));
        }

        [Test]
        public void ThrowsArgumentExceptionWhenMinorIsNegative()
        {
            // Arrange
            int major = 5;
            int minor = -1;
            int patch = 3;
            VersionType versionType = VersionType.alpha;

            // Act && Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, versionType));
        }

        [Test]
        public void ThrowsArgumentExceptionWhenPatchIsNegative()
        {
            // Arrange
            int major = 5;
            int minor = 1;
            int patch = -3;
            VersionType versionType = VersionType.alpha;

            // Act && Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, versionType));
        }

        [Test]
        public void ThrowsArgumentExceptionWhenVersionTypeIsInvalid()
        {
            // Arrange
            int major = 5;
            int minor = 1;
            int patch = 3;
            VersionType versionType = (VersionType)10;

            // Act && Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, versionType));
        }
    }
}
