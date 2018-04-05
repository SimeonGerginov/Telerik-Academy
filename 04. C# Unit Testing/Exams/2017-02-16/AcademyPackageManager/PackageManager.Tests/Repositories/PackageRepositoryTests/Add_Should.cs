using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Tests.CustomExceptions;
using PackageManager.Tests.Repositories.PackageRepositoryTests.Mocks;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPackageIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object);

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => packageRepository.Add(null));
        }

        [Test]
        public void AddThePackage_WhenThePackageIsNotAlreadyAdded()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            packageRepository.Add(packageMock.Object);

            // Assert
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void LogThreeTimes_WhenThePackageIsAlreadyAdded()
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
            packageRepository.Add(packageMock.Object);

            // Assert
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public void CallUpdateMethodAndThrowException_WhenTheAlreadyAddedPackageIsWithLowerVersion()
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

            PackageRepositoryMock packageRepository = new PackageRepositoryMock(loggerMock.Object, packages);

            // Act && Assert
            Assert.Throws<UpdateMethodCalledException>(() => packageRepository.Add(packageMock.Object));
        }

        [Test]
        public void CallUpdateMethodOnce_WhenTheAlreadyAddedPackageIsWithLowerVersion()
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

            var packageRepositorySUT = new Mock<PackageRepository>(loggerMock.Object, packages)
            {
                CallBase = true
            };

            packageRepositorySUT.Object.Add(packageMock.Object);

            // Act && Assert
            packageRepositorySUT.Verify(pr => pr.Update(packageMock.Object), Times.Once());
        }

        [Test]
        public void LogTwoTimes_WhenTheAlreadyAddedPackageIsWithHigherVersion()
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

            // Act
            packageRepository.Add(packageMock.Object);

            // Assert
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
