using PackageManager.Core.Contracts;
using PackageManager.Extensions;
using PackageManager.Models.Contracts;

using Moq;
using NUnit.Framework;

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

            var installCommand = new InstallCommandExtended(installer.Object, package.Object);

            // Act
            installCommand.Execute();

            // Assert
            installer.Verify(i => i.PerformOperation(package.Object), Times.Once());
        }
    }
}
