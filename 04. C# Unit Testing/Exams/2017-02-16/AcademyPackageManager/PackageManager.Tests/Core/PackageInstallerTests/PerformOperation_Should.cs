using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestFixture]
    public class PerformOperation_Should
    {
        [Test]
        public void CallTwoTimesDownloadAndOneTimeRemove_WithEmptyDependenciesList()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();

            projectMock.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage>());
            packageMock.Setup(p => p.Dependencies).Returns(new List<IPackage>());
            
            PackageInstaller packageInstaller = new PackageInstaller(downloaderMock.Object, projectMock.Object);
            packageInstaller.Operation = InstallerOperation.Install;

            // Act
            packageInstaller.PerformOperation(packageMock.Object);

            // Assert
            downloaderMock.Verify(d => d.Download(It.IsAny<string>()), Times.Exactly(2));
            downloaderMock.Verify(d => d.Remove(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void CallDownloadFourTimesAndRemoveTwoTimes_WithOneDependencyInTheList()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();
            var packageDependencyMock = new Mock<IPackage>();

            projectMock.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage>());
            packageDependencyMock.Setup(p => p.Dependencies).Returns(new List<IPackage>());
            packageMock.Setup(p => p.Dependencies).Returns(new List<IPackage>()
            {
                packageDependencyMock.Object
            });

            PackageInstaller packageInstaller = new PackageInstaller(downloaderMock.Object, projectMock.Object);
            packageInstaller.Operation = InstallerOperation.Install;

            // Act
            packageInstaller.PerformOperation(packageMock.Object);

            // Assert
            downloaderMock.Verify(d => d.Download(It.IsAny<string>()), Times.Exactly(4));
            downloaderMock.Verify(d => d.Remove(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
