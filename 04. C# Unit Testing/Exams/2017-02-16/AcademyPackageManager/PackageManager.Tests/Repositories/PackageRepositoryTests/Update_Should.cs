using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPackageIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object);

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => packageRepository.Update(null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPackageIsNotFound()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object);

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => packageRepository.Update(packageMock.Object));
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void ReturnsTrueAndUpdatePackage_WhenThePackageIsFoundWithLowerVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(p => p.Name).Returns("Package");
            packageMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(1);

            ICollection<IPackage> packages = new List<IPackage>()
            {
                packageMock.Object
            };

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object, packages);

            // Act
            bool result = packageRepository.Update(packageMock.Object);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ThrowArgumentException_WhenThePackageIsFoundWithHigherVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(p => p.Name).Returns("Package");
            packageMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            ICollection<IPackage> packages = new List<IPackage>()
            {
                packageMock.Object
            };

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object, packages);

            // Act && Assert
            Assert.Throws<ArgumentException>(() => packageRepository.Update(packageMock.Object));
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void ReturnFalse_WhenThePackageIsFoundWithTheSameVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(p => p.Name).Returns("Package");
            packageMock.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(0);

            ICollection<IPackage> packages = new List<IPackage>()
            {
                packageMock.Object
            };

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object, packages);

            // Act
            bool result = packageRepository.Update(packageMock.Object);

            // Assert
            Assert.IsFalse(result);
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Once());
        }
    }
}
