using System;
using System.Collections.Generic;

using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;

using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    public class TeleportUnit_Should
    {
        private const string Galaxy = "Galaxy 1";
        private const string Location = "Mars";
        private const string TargetGalaxy = "Galaxy 2";
        private const string TargetLocation = "Earth";
        private const double Longtitude = 45d;
        private const double Latitude = 45d;
        private const double OtherLongtitude = 46d;
        private const double OtherLatitude = 46d;
        private const uint BronzeCoins = 20;
        private const uint SilverCoins = 30;
        private const uint GoldCoins = 40;

        private static IResources Resources;
        private static ICollection<IUnit> Units;
        private static Mock<IList<IUnit>> UnitsMock;
        private static IPath Path;

        private ExtendedTeleportStation ArrangeTeleportStation()
        {
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var unitMock = new Mock<IUnit>();

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(Galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(Location);
            locationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(Longtitude);
            locationMock.SetupGet(l => l.Coordinates.Latitude).Returns(Latitude);

            IBusinessOwner expectedOwner = ownerMock.Object;
            IEnumerable<IPath> expectedMap = this.ArrangeGalacticMock(ref pathMock, ref unitMock);
            ILocation expectedLocation = locationMock.Object;

            ExtendedTeleportStation teleportStation = new ExtendedTeleportStation(expectedOwner, expectedMap, expectedLocation);

            return teleportStation;
        }

        private void SetupUnitToTeleport(ref Mock<IUnit> unitToTeleportMock, string targetGalaxy, string targetLocation)
        {
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(targetGalaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(targetLocation);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Units).Returns(Units);
            unitToTeleportMock.Setup(u => u.Pay(Resources)).Returns(Resources);
        }

        private void SetupTargetLocation(ref Mock<ILocation> targetLocationMock, string galaxy, string location, double longtitude, double latitude)
        {
            targetLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            targetLocationMock.SetupGet(l => l.Planet.Name).Returns(location);
            targetLocationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(longtitude);
            targetLocationMock.SetupGet(l => l.Coordinates.Latitude).Returns(latitude);
        }

        private IEnumerator<IUnit> CreateEnumeratorForUnits<IUnit>(params IUnit[] items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        private IEnumerable<IPath> ArrangeGalacticMock(ref Mock<IPath> pathMock, ref Mock<IUnit> unitMock)
        {
            var resources = new Mock<IResources>();

            resources.SetupGet(r => r.BronzeCoins).Returns(BronzeCoins);
            resources.SetupGet(r => r.SilverCoins).Returns(SilverCoins);
            resources.SetupGet(r => r.GoldCoins).Returns(GoldCoins);

            Resources = resources.Object;

            unitMock.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(Galaxy);
            unitMock.Setup(u => u.CurrentLocation.Planet.Name).Returns(Location);
            unitMock.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(Longtitude);
            unitMock.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(Latitude);

            var unitsCollectionEnumeratorMock = this.CreateEnumeratorForUnits(unitMock.Object);

            var unitsMock = new Mock<IList<IUnit>>();
            unitsMock.Setup(u => u.GetEnumerator()).Returns(unitsCollectionEnumeratorMock);

            UnitsMock = unitsMock;
            Units = unitsMock.Object;

            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns(Galaxy);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns(Location);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Longtitude).Returns(Longtitude);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Latitude).Returns(Latitude);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Units).Returns(unitsMock.Object);
            pathMock.SetupGet(p => p.Cost).Returns(resources.Object);

            Path = pathMock.Object;

            IEnumerable<IPath> paths = new List<IPath>() { pathMock.Object };
            IEnumerable<IPath> galacticMapMock = paths;

            return galacticMapMock;
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitToTeleportIsNull()
        {
            // Arrange
            var targetLocationMock = new Mock<ILocation>();
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "unitToTeleport";

            TeleportStation teleportStation = this.ArrangeTeleportStation();

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

            TeleportStation teleportStation = this.ArrangeTeleportStation();

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

            this.SetupUnitToTeleport(ref unitToTeleportMock, TargetGalaxy, TargetLocation);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "unitToTeleport.CurrentLocation";

            TeleportStation teleportStation = this.ArrangeTeleportStation();

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

            this.SetupUnitToTeleport(ref unitToTeleportMock, Galaxy, Location);
            this.SetupTargetLocation(ref targetLocationMock, Galaxy, Location, Longtitude, Latitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "units will overlap";

            TeleportStation teleportStation = this.ArrangeTeleportStation();

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

            this.SetupUnitToTeleport(ref unitToTeleportMock, Galaxy, Location);
            this.SetupTargetLocation(ref targetLocationMock, TargetGalaxy, Location, Longtitude, Latitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "Galaxy";

            TeleportStation teleportStation = this.ArrangeTeleportStation();

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

            this.SetupUnitToTeleport(ref unitToTeleportMock, Galaxy, Location);
            this.SetupTargetLocation(ref targetLocationMock, Galaxy, TargetLocation, Longtitude, Latitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "Planet";

            TeleportStation teleportStation = this.ArrangeTeleportStation();

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

            this.SetupUnitToTeleport(ref unitToTeleportMock, Galaxy, Location);
            this.SetupTargetLocation(ref targetLocationMock, Galaxy, Location, OtherLongtitude, OtherLatitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "FREE LUNCH";

            TeleportStation teleportStation = this.ArrangeTeleportStation();

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

            TeleportStation teleportStation = this.ArrangeTeleportStation();

            this.SetupUnitToTeleport(ref unitToTeleportMock, Galaxy, Location);
            this.SetupTargetLocation(ref targetLocationMock, Galaxy, Location, OtherLongtitude, OtherLatitude);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(Path.Cost)).Returns(Path.Cost);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            unitToTeleportMock.Verify(u => u.Pay(Path.Cost), Times.Once());
        }

        [Test]
        public void ObtainAPayment_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            ExtendedTeleportStation teleportStation = this.ArrangeTeleportStation();

            this.SetupUnitToTeleport(ref unitToTeleportMock, Galaxy, Location);
            this.SetupTargetLocation(ref targetLocationMock, Galaxy, Location, OtherLongtitude, OtherLatitude);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(Path.Cost)).Returns(Path.Cost);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);
            uint actualBronzeCoins = teleportStation.Resources.BronzeCoins;
            uint actualSilverCoins = teleportStation.Resources.SilverCoins;
            uint actualGoldCoins = teleportStation.Resources.GoldCoins;

            // Assert
            Assert.AreEqual(BronzeCoins, actualBronzeCoins);
            Assert.AreEqual(SilverCoins, actualSilverCoins);
            Assert.AreEqual(GoldCoins, actualGoldCoins);
        }

        [Test]
        public void SetPreviousLocationToTheCurrentLocation_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            ExtendedTeleportStation teleportStation = this.ArrangeTeleportStation();

            this.SetupUnitToTeleport(ref unitToTeleportMock, Galaxy, Location);
            this.SetupTargetLocation(ref targetLocationMock, Galaxy, Location, OtherLongtitude, OtherLatitude);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(Path.Cost)).Returns(Path.Cost);

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

            ExtendedTeleportStation teleportStation = this.ArrangeTeleportStation();

            this.SetupUnitToTeleport(ref unitToTeleportMock, Galaxy, Location);
            this.SetupTargetLocation(ref targetLocationMock, Galaxy, Location, OtherLongtitude, OtherLatitude);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(Path.Cost)).Returns(Path.Cost);

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

            ExtendedTeleportStation teleportStation = this.ArrangeTeleportStation();

            this.SetupUnitToTeleport(ref unitToTeleportMock, Galaxy, Location);
            this.SetupTargetLocation(ref targetLocationMock, Galaxy, Location, OtherLongtitude, OtherLatitude);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(Path.Cost)).Returns(Path.Cost);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            UnitsMock.Verify(u => u.Add(unitToTeleportMock.Object), Times.Once());
        }

        [Test]
        public void RemoveTheTeleportedUnitFromTheListsOfUnitsOfTheCurrentLocation_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            ExtendedTeleportStation teleportStation = this.ArrangeTeleportStation();

            this.SetupUnitToTeleport(ref unitToTeleportMock, Galaxy, Location);
            this.SetupTargetLocation(ref targetLocationMock, Galaxy, Location, OtherLongtitude, OtherLatitude);

            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(Path.Cost)).Returns(Path.Cost);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            UnitsMock.Verify(u => u.Remove(unitToTeleportMock.Object), Times.Once());
        }
    }
}
