using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Core.PackageInstallerTests.Mocks;

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void RestorePackages_WhenObjectIsConstructed()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();

            projectMock.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage>()
            {
                packageMock.Object,
                packageMock.Object,
                packageMock.Object
            });

            int expectedCount = 3;

            // Act 
            PackageInstallerMock packageInstaller = new PackageInstallerMock(downloaderMock.Object, projectMock.Object);

            // Assert
            Assert.AreEqual(expectedCount, packageInstaller.Counter);
        }

        [Test]
        public void RestorePackages_WhenMockedObjectIsConstructed()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();

            projectMock.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage>()
            {
                packageMock.Object,
                packageMock.Object,
                packageMock.Object
            });

            var packageInstallerSUT = new Mock<PackageInstaller>(downloaderMock.Object, projectMock.Object);

            packageInstallerSUT.Setup(i => i.PerformOperation(It.IsAny<IPackage>()));

            // Act
            PackageInstaller packageInstallerObject = packageInstallerSUT.Object;

            // Assert
            packageInstallerSUT.Verify(i => i.PerformOperation(It.IsAny<IPackage>()), Times.Exactly(3));
        }
    }
}
