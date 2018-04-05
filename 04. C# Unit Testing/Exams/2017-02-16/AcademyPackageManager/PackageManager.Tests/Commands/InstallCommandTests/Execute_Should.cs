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
            var installer = new Mock<IInstaller<IPackage>>();
            var package = new Mock<IPackage>();

            var installCommand = new InstallCommandMock(installer.Object, package.Object);

            // Act
            installCommand.Execute();

            // Assert
            installer.Verify(i => i.PerformOperation(package.Object), Times.Once());
        }
    }
}
