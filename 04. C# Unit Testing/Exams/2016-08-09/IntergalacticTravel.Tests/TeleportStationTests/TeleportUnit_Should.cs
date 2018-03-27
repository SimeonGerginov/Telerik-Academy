using System;

using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Tests.Helpers;

using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    public class TeleportUnit_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUnitToTeleportIsNull()
        {
            // Arrange
            var targetLocationMock = new Mock<ILocation>();
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "unitToTeleport";

            TeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            // Act
            Exception exception = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(null, expectedTargetLocation));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void ThrowArgumentNullException_WhenDestinationIsNull()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;

            string exceptionMessage = "destination";

            TeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            // Act
            Exception exception = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(expectedUnitToTeleport, null));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void ThrowTeleportOutOfRangeException_WhenAUnitIsUsingTheStationFromADistantLocation()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            TeleportStationHelpers.SetupUnitToTeleport(ref unitToTeleportMock, TeleportStationConstants.TargetGalaxy, TeleportStationConstants.TargetLocation);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "unitToTeleport.CurrentLocation";

            TeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            // Act
            Exception exception = Assert.Throws<TeleportOutOfRangeException>(() => teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void ThrowInvalidTeleportationLocationException_WhenTeleportingAUnitToATakenLocation()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            TeleportStationHelpers.SetupUnitToTeleport(ref unitToTeleportMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location);
            TeleportStationHelpers.SetupTargetLocation(ref targetLocationMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location, TeleportStationConstants.Longtitude, TeleportStationConstants.Latitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "units will overlap";

            TeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            // Act
            Exception exception = Assert.Throws<InvalidTeleportationLocationException>(() => teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void ThrowLocationNotFoundException_WhenGalaxyIsNotFoundInTheLocationsList()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            TeleportStationHelpers.SetupUnitToTeleport(ref unitToTeleportMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location);
            TeleportStationHelpers.SetupTargetLocation(ref targetLocationMock, TeleportStationConstants.TargetGalaxy, TeleportStationConstants.Location, TeleportStationConstants.Longtitude, TeleportStationConstants.Latitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "Galaxy";

            TeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            // Act
            Exception exception = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void ThrowLocationNotFoundException_WhenPlanetIsNotFoundInTheLocationsList()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            TeleportStationHelpers.SetupUnitToTeleport(ref unitToTeleportMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location);
            TeleportStationHelpers.SetupTargetLocation(ref targetLocationMock, TeleportStationConstants.Galaxy, TeleportStationConstants.TargetLocation, TeleportStationConstants.Longtitude, TeleportStationConstants.Latitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "Planet";

            TeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            // Act
            Exception exception = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void ThrowInsufficientResourcesException_WhenTeleportingAUnitCostsMoreThanTheCurrentAvailableResources()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(false);

            TeleportStationHelpers.SetupUnitToTeleport(ref unitToTeleportMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location);
            TeleportStationHelpers.SetupTargetLocation(ref targetLocationMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location, TeleportStationConstants.OtherLongtitude, TeleportStationConstants.OtherLatitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "FREE LUNCH";

            TeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            // Act
            Exception exception = Assert.Throws<InsufficientResourcesException>(() => teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void RequireAPayment_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            TeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            TeleportStationHelpers.SetupUnitToTeleport(ref unitToTeleportMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location);
            TeleportStationHelpers.SetupTargetLocation(ref targetLocationMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location, TeleportStationConstants.OtherLongtitude, TeleportStationConstants.OtherLatitude);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(TeleportStationHelpers.Path.Cost)).Returns(TeleportStationHelpers.Path.Cost);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            unitToTeleportMock.Verify(u => u.Pay(TeleportStationHelpers.Path.Cost), Times.Once());
        }

        [Test]
        public void ObtainAPayment_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            ExtendedTeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            TeleportStationHelpers.SetupUnitToTeleport(ref unitToTeleportMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location);
            TeleportStationHelpers.SetupTargetLocation(ref targetLocationMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location, TeleportStationConstants.OtherLongtitude, TeleportStationConstants.OtherLatitude);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(TeleportStationHelpers.Path.Cost)).Returns(TeleportStationHelpers.Path.Cost);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);
            uint actualBronzeCoins = teleportStation.Resources.BronzeCoins;
            uint actualSilverCoins = teleportStation.Resources.SilverCoins;
            uint actualGoldCoins = teleportStation.Resources.GoldCoins;

            // Assert
            Assert.AreEqual(TeleportStationConstants.BronzeCoins, actualBronzeCoins);
            Assert.AreEqual(TeleportStationConstants.SilverCoins, actualSilverCoins);
            Assert.AreEqual(TeleportStationConstants.GoldCoins, actualGoldCoins);
        }

        [Test]
        public void SetPreviousLocationToTheCurrentLocation_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            ExtendedTeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            TeleportStationHelpers.SetupUnitToTeleport(ref unitToTeleportMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location);
            TeleportStationHelpers.SetupTargetLocation(ref targetLocationMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location, TeleportStationConstants.OtherLongtitude, TeleportStationConstants.OtherLatitude);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(TeleportStationHelpers.Path.Cost)).Returns(TeleportStationHelpers.Path.Cost);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            unitToTeleportMock.VerifySet(u => u.PreviousLocation = u.CurrentLocation, Times.Once());
        }

        [Test]
        public void SetCurrentLocationToTheTargetLocation_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            ExtendedTeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            TeleportStationHelpers.SetupUnitToTeleport(ref unitToTeleportMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location);
            TeleportStationHelpers.SetupTargetLocation(ref targetLocationMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location, TeleportStationConstants.OtherLongtitude, TeleportStationConstants.OtherLatitude);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(TeleportStationHelpers.Path.Cost)).Returns(TeleportStationHelpers.Path.Cost);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            unitToTeleportMock.VerifySet(u => u.CurrentLocation = targetLocationMock.Object, Times.Once());
        }

        [Test]
        public void AddTheTeleportedUnitToThePlanetUnits_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            ExtendedTeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            TeleportStationHelpers.SetupUnitToTeleport(ref unitToTeleportMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location);
            TeleportStationHelpers.SetupTargetLocation(ref targetLocationMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location, TeleportStationConstants.OtherLongtitude, TeleportStationConstants.OtherLatitude);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(TeleportStationHelpers.Path.Cost)).Returns(TeleportStationHelpers.Path.Cost);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            TeleportStationHelpers.UnitsMock.Verify(u => u.Add(unitToTeleportMock.Object), Times.Once());
        }

        [Test]
        public void RemoveTheTeleportedUnitFromTheListsOfUnitsOfTheCurrentLocation_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            ExtendedTeleportStation teleportStation = TeleportStationHelpers.ArrangeTeleportStation();

            TeleportStationHelpers.SetupUnitToTeleport(ref unitToTeleportMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location);
            TeleportStationHelpers.SetupTargetLocation(ref targetLocationMock, TeleportStationConstants.Galaxy, TeleportStationConstants.Location, TeleportStationConstants.OtherLongtitude, TeleportStationConstants.OtherLatitude);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(TeleportStationHelpers.Path.Cost)).Returns(TeleportStationHelpers.Path.Cost);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            TeleportStationHelpers.UnitsMock.Verify(u => u.Remove(unitToTeleportMock.Object), Times.Once());
        }
    }
}
