using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnEmptyCollection_WhenNoCollectionIsPassedToTheConstructor()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            int expectedCount = 0;

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object);

            // Act
            IEnumerable<IPackage> allPackages = packageRepository.GetAll();

            // Assert
            Assert.AreEqual(expectedCount, allPackages.Count());
        }

        [Test]
        public void ReturnCollectionWithTheSameSize_WhenACollectionIsPassedToTheConstructor()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            ICollection<IPackage> packages = new List<IPackage>()
            {
                packageMock.Object
            };

            PackageRepository packageRepository = new PackageRepository(loggerMock.Object, packages);

            // Act
            var allPackages = packageRepository.GetAll();

            // Assert
            Assert.AreEqual(packages.Count(), allPackages.Count());
        }
    }
}
