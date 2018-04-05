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
    public class Delete_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPackageIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object);

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => packageRepository.Delete(null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPackageIsNotFound()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object);

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => packageRepository.Delete(packageMock.Object));
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void LogThreeTimes_WhenPackageIsADependencyOfAnotherPackage()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packageMockWithDependency = new Mock<IPackage>();

            packageMock.Setup(p => p.Equals(packageMock.Object)).Returns(true);
            packageMock.Setup(p => p.Dependencies).Returns(new List<IPackage>());
            
            packageMockWithDependency.Setup(p => p.Dependencies).Returns(new List<IPackage>()
            {
                packageMock.Object
            });

            ICollection<IPackage> packages = new List<IPackage>()
            {
                packageMock.Object,
                packageMockWithDependency.Object
            };

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object, packages);

            // Act
            packageRepository.Delete(packageMock.Object);

            // Assert
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public void ReturnTheDeletedPackage_WhenThePackageIsDeletedSuccessfullyFromTheCollection()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(p => p.Equals(packageMock.Object)).Returns(true);
            packageMock.Setup(p => p.Dependencies).Returns(new List<IPackage>());

            ICollection<IPackage> packages = new List<IPackage>()
            {
                packageMock.Object
            };

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object, packages);

            // Act
            IPackage deletedPackage = packageRepository.Delete(packageMock.Object);

            // Assert
            Assert.AreEqual(packageMock.Object, deletedPackage);
        }
    }
}
