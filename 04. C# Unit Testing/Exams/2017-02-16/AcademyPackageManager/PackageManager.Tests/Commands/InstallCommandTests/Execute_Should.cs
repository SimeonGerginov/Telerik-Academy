using Moq;
using NUnit.Framework;

using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Commands.InstallCommandTests.Mocks;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void CallPerformOperation_WithThePassedPackage()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            var installCommand = new InstallCommandMock(installerMock.Object, packageMock.Object);

            // Act
            installCommand.Execute();

            // Assert
            installerMock.Verify(i => i.PerformOperation(packageMock.Object), Times.Once());
        }
    }
}
