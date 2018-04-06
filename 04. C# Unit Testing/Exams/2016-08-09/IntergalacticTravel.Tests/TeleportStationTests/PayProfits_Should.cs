using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.Helpers;

using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    public class PayProfits_Should
    {
        [Test]
        public void ReturnTheTotalAmountOfProfits_WhenTheArgumentPassedIsTheActualOwner()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();
            var ownerMock = new Mock<IBusinessOwner>();

            ExtendedTeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            TeleportStationHelpers.SetupUnitToTeleport(ref unitToTeleportMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location);
            TeleportStationHelpers.SetupTargetLocation(ref targetLocationMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location, TeleportStationConstants.OtherLongtitude, TeleportStationConstants.OtherLatitude);

            ownerMock.Setup(o => o.IdentificationNumber).Returns(TeleportStationConstants.IdentificationNumber);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(TeleportStationHelpers.Path.Cost)).Returns(TeleportStationHelpers.Path.Cost);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;
            IBusinessOwner expectedOwner = ownerMock.Object;

            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);
            uint expectedBronzeCoins = teleportStation.Resources.BronzeCoins;
            uint expectedSilverCoins = teleportStation.Resources.SilverCoins;
            uint expectedGoldCoins = teleportStation.Resources.GoldCoins;

            // Act
            IResources resources = teleportStation.PayProfits(expectedOwner);
            uint actualBronzeCoins = resources.BronzeCoins;
            uint actualSilverCoins = resources.SilverCoins;
            uint actualGoldCoins = resources.GoldCoins;

            // Assert
            Assert.AreEqual(expectedBronzeCoins, actualBronzeCoins);
            Assert.AreEqual(expectedSilverCoins, actualSilverCoins);
            Assert.AreEqual(expectedGoldCoins, actualGoldCoins);
        }
    }
}
