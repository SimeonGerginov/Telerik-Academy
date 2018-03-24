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
        [Test]
        public void ThrowArgumentNullException_WhenUnitToTeleportIsNull()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var galacticMapMock = new Mock<IEnumerable<IPath>>();
            var locationMock = new Mock<ILocation>();

            IBusinessOwner expectedOwner = ownerMock.Object;
            IEnumerable<IPath> expectedMap = galacticMapMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var targetLocationMock = new Mock<ILocation>();
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "unitToTeleport";

            TeleportStation teleportStation = new TeleportStation(expectedOwner, expectedMap, expectedLocation);

            // Act
            Exception exception = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(null, expectedTargetLocation));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void ThrowArgumentNullException_WhenDestinationIsNull()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var galacticMapMock = new Mock<IEnumerable<IPath>>();
            var locationMock = new Mock<ILocation>();

            IBusinessOwner expectedOwner = ownerMock.Object;
            IEnumerable<IPath> expectedMap = galacticMapMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var unitToTeleportMock = new Mock<IUnit>();
            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;

            string exceptionMessage = "destination";

            TeleportStation teleportStation = new TeleportStation(expectedOwner, expectedMap, expectedLocation);

            // Act
            Exception exception = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(expectedUnitToTeleport, null));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void ThrowTeleportOutOfRangeException_WhenAUnitIsUsingTheStationFromADistantLocation()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var galacticMapMock = new Mock<IEnumerable<IPath>>();
            var locationMock = new Mock<ILocation>();

            string galaxy = "Galaxy 1";
            string location = "Mars";

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(location);

            IBusinessOwner expectedOwner = ownerMock.Object;
            IEnumerable<IPath> expectedMap = galacticMapMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            string targetGalaxy = "Galaxy 2";
            string targetLocation = "Earth";

            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(targetGalaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(targetLocation);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "unitToTeleport.CurrentLocation";

            TeleportStation teleportStation = new TeleportStation(expectedOwner, expectedMap, expectedLocation);

            // Act
            Exception exception = Assert.Throws<TeleportOutOfRangeException>(() => teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void ThrowInvalidTeleportationLocationException_WhenTeleportingAUnitToATakenLocation()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var unitMock = new Mock<IUnit>();

            string galaxy = "Galaxy 1";
            string location = "Mars";
            double longtitude = 45d;
            double latitude = 45d;

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(location);
            locationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(longtitude);
            locationMock.SetupGet(l => l.Coordinates.Latitude).Returns(latitude);

            unitMock.SetupGet(u => u.CurrentLocation).Returns(locationMock.Object);

            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns(galaxy);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns(location);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Longtitude).Returns(longtitude);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Latitude).Returns(latitude);

            ICollection<IUnit> units = new List<IUnit>() { unitMock.Object };
            pathMock.SetupGet(p => p.TargetLocation.Planet.Units).Returns(units);

            IEnumerable<IPath> paths = new List<IPath>() { pathMock.Object };
            IEnumerable<IPath> galacticMapMock = paths;

            IBusinessOwner expectedOwner = ownerMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(galaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(location);

            targetLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            targetLocationMock.SetupGet(l => l.Planet.Name).Returns(location);
            targetLocationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(longtitude);
            targetLocationMock.SetupGet(l => l.Coordinates.Latitude).Returns(latitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "units will overlap";

            TeleportStation teleportStation = new TeleportStation(expectedOwner, galacticMapMock, expectedLocation);

            // Act
            Exception exception = Assert.Throws<InvalidTeleportationLocationException>(() => teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void ThrowLocationNotFoundException_WhenGalaxyIsNotFoundInTheLocationsList()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();

            string galaxy = "Galaxy 1";
            string anotherGalaxy = "Galaxy 2";
            string location = "Mars";

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(location);

            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns(galaxy);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns(location);

            IEnumerable<IPath> paths = new List<IPath>() { pathMock.Object };
            IEnumerable<IPath> galacticMapMock = paths;

            IBusinessOwner expectedOwner = ownerMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(galaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(location);

            targetLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(anotherGalaxy);
            targetLocationMock.SetupGet(l => l.Planet.Name).Returns(location);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "Galaxy";

            TeleportStation teleportStation = new TeleportStation(expectedOwner, galacticMapMock, expectedLocation);

            // Act
            Exception exception = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void ThrowLocationNotFoundException_WhenPlanetIsNotFoundInTheLocationsList()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();

            string galaxy = "Galaxy 1";
            string location = "Mars";
            string anotherLocation = "Earth";

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(location);

            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns(galaxy);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns(location);

            IEnumerable<IPath> paths = new List<IPath>() { pathMock.Object };
            IEnumerable<IPath> galacticMapMock = paths;

            IBusinessOwner expectedOwner = ownerMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(galaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(location);

            targetLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            targetLocationMock.SetupGet(l => l.Planet.Name).Returns(anotherLocation);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "Planet";

            TeleportStation teleportStation = new TeleportStation(expectedOwner, galacticMapMock, expectedLocation);

            // Act
            Exception exception = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void ThrowInsufficientResourcesException_WhenTeleportingAUnitCostsMoreThanTheCurrentAvailableResources()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var unitMock = new Mock<IUnit>();
            var resources = new Mock<IResources>();

            string galaxy = "Galaxy 1";
            string location = "Mars";
            double longtitude = 45d;
            double latitude = 45d;
            double anotherLongtitude = 46d;
            double anotherLatitude = 46d;

            uint bronzeCoins = 20;
            uint silverCoins = 30;
            uint goldCoins = 40;

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(location);
            locationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(longtitude);
            locationMock.SetupGet(l => l.Coordinates.Latitude).Returns(latitude);

            unitMock.SetupGet(u => u.CurrentLocation).Returns(locationMock.Object);

            resources.SetupGet(r => r.BronzeCoins).Returns(bronzeCoins);
            resources.SetupGet(r => r.SilverCoins).Returns(silverCoins);
            resources.SetupGet(r => r.GoldCoins).Returns(goldCoins);

            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns(galaxy);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns(location);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Longtitude).Returns(longtitude);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Latitude).Returns(latitude);
            pathMock.SetupGet(p => p.Cost).Returns(resources.Object);

            ICollection<IUnit> units = new List<IUnit>() { unitMock.Object };
            pathMock.SetupGet(p => p.TargetLocation.Planet.Units).Returns(units);

            IEnumerable<IPath> paths = new List<IPath>() { pathMock.Object };
            IEnumerable<IPath> galacticMapMock = paths;

            IBusinessOwner expectedOwner = ownerMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(galaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(location);
            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(false);

            targetLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            targetLocationMock.SetupGet(l => l.Planet.Name).Returns(location);
            targetLocationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(anotherLongtitude);
            targetLocationMock.SetupGet(l => l.Coordinates.Latitude).Returns(anotherLatitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            string exceptionMessage = "FREE LUNCH";

            TeleportStation teleportStation = new TeleportStation(expectedOwner, galacticMapMock, expectedLocation);

            // Act
            Exception exception = Assert.Throws<InsufficientResourcesException>(() => teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [Test]
        public void RequireAPayment_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var unitMock = new Mock<IUnit>();
            var resources = new Mock<IResources>();

            string galaxy = "Galaxy 1";
            string location = "Mars";
            double longtitude = 45d;
            double latitude = 45d;
            double anotherLongtitude = 46d;
            double anotherLatitude = 46d;

            uint bronzeCoins = 20;
            uint silverCoins = 30;
            uint goldCoins = 40;

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(location);
            locationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(longtitude);
            locationMock.SetupGet(l => l.Coordinates.Latitude).Returns(latitude);

            unitMock.SetupGet(u => u.CurrentLocation).Returns(locationMock.Object);

            resources.SetupGet(r => r.BronzeCoins).Returns(bronzeCoins);
            resources.SetupGet(r => r.SilverCoins).Returns(silverCoins);
            resources.SetupGet(r => r.GoldCoins).Returns(goldCoins);

            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns(galaxy);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns(location);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Longtitude).Returns(longtitude);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Latitude).Returns(latitude);
            pathMock.SetupGet(p => p.Cost).Returns(resources.Object);

            ICollection<IUnit> units = new List<IUnit>() { unitMock.Object };
            pathMock.SetupGet(p => p.TargetLocation.Planet.Units).Returns(units);

            IEnumerable<IPath> paths = new List<IPath>() { pathMock.Object };
            IEnumerable<IPath> galacticMapMock = paths;

            IBusinessOwner expectedOwner = ownerMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(galaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(location);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Units).Returns(units);
            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(resources.Object)).Returns(resources.Object);

            targetLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            targetLocationMock.SetupGet(l => l.Planet.Name).Returns(location);
            targetLocationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(anotherLongtitude);
            targetLocationMock.SetupGet(l => l.Coordinates.Latitude).Returns(anotherLatitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            TeleportStation teleportStation = new TeleportStation(expectedOwner, galacticMapMock, expectedLocation);

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            unitToTeleportMock.Verify(u => u.Pay(pathMock.Object.Cost), Times.Once());
        }

        [Test]
        public void ObtainAPayment_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var unitMock = new Mock<IUnit>();
            var resources = new Mock<IResources>();

            string galaxy = "Galaxy 1";
            string location = "Mars";
            double longtitude = 45d;
            double latitude = 45d;
            double anotherLongtitude = 46d;
            double anotherLatitude = 46d;

            uint bronzeCoins = 20;
            uint silverCoins = 30;
            uint goldCoins = 40;

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(location);
            locationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(longtitude);
            locationMock.SetupGet(l => l.Coordinates.Latitude).Returns(latitude);

            unitMock.SetupGet(u => u.CurrentLocation).Returns(locationMock.Object);

            resources.SetupGet(r => r.BronzeCoins).Returns(bronzeCoins);
            resources.SetupGet(r => r.SilverCoins).Returns(silverCoins);
            resources.SetupGet(r => r.GoldCoins).Returns(goldCoins);

            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns(galaxy);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns(location);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Longtitude).Returns(longtitude);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Latitude).Returns(latitude);
            pathMock.SetupGet(p => p.Cost).Returns(resources.Object);

            ICollection<IUnit> units = new List<IUnit>() { unitMock.Object };
            pathMock.SetupGet(p => p.TargetLocation.Planet.Units).Returns(units);

            IEnumerable<IPath> paths = new List<IPath>() { pathMock.Object };
            IEnumerable<IPath> galacticMapMock = paths;

            IBusinessOwner expectedOwner = ownerMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(galaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(location);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Units).Returns(units);
            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(resources.Object)).Returns(resources.Object);

            targetLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            targetLocationMock.SetupGet(l => l.Planet.Name).Returns(location);
            targetLocationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(anotherLongtitude);
            targetLocationMock.SetupGet(l => l.Coordinates.Latitude).Returns(anotherLatitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            ExtendedTeleportStation teleportStation = new ExtendedTeleportStation(expectedOwner, galacticMapMock, expectedLocation);

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);
            uint actualBronzeCoins = teleportStation.Resources.BronzeCoins;
            uint actualSilverCoins = teleportStation.Resources.SilverCoins;
            uint actualGoldCoins = teleportStation.Resources.GoldCoins;

            // Assert
            Assert.AreEqual(bronzeCoins, actualBronzeCoins);
            Assert.AreEqual(silverCoins, actualSilverCoins);
            Assert.AreEqual(goldCoins, actualGoldCoins);
        }

        [Test]
        public void SetPreviousLocationToTheCurrentLocation_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var unitMock = new Mock<IUnit>();
            var resources = new Mock<IResources>();

            string galaxy = "Galaxy 1";
            string location = "Mars";
            double longtitude = 45d;
            double latitude = 45d;
            double anotherLongtitude = 46d;
            double anotherLatitude = 46d;

            uint bronzeCoins = 20;
            uint silverCoins = 30;
            uint goldCoins = 40;

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(location);
            locationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(longtitude);
            locationMock.SetupGet(l => l.Coordinates.Latitude).Returns(latitude);

            unitMock.SetupGet(u => u.CurrentLocation).Returns(locationMock.Object);

            resources.SetupGet(r => r.BronzeCoins).Returns(bronzeCoins);
            resources.SetupGet(r => r.SilverCoins).Returns(silverCoins);
            resources.SetupGet(r => r.GoldCoins).Returns(goldCoins);

            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns(galaxy);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns(location);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Longtitude).Returns(longtitude);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Latitude).Returns(latitude);
            pathMock.SetupGet(p => p.Cost).Returns(resources.Object);

            ICollection<IUnit> units = new List<IUnit>() { unitMock.Object };
            pathMock.SetupGet(p => p.TargetLocation.Planet.Units).Returns(units);

            IEnumerable<IPath> paths = new List<IPath>() { pathMock.Object };
            IEnumerable<IPath> galacticMapMock = paths;

            IBusinessOwner expectedOwner = ownerMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(galaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(location);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Units).Returns(units);
            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(resources.Object)).Returns(resources.Object);

            targetLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            targetLocationMock.SetupGet(l => l.Planet.Name).Returns(location);
            targetLocationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(anotherLongtitude);
            targetLocationMock.SetupGet(l => l.Coordinates.Latitude).Returns(anotherLatitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            ExtendedTeleportStation teleportStation = new ExtendedTeleportStation(expectedOwner, galacticMapMock, expectedLocation);

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            unitToTeleportMock.VerifySet(u => u.PreviousLocation = u.CurrentLocation, Times.Once());
        }

        [Test]
        public void SetCurrentLocationToTheTargetLocation_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var unitMock = new Mock<IUnit>();
            var resources = new Mock<IResources>();

            string galaxy = "Galaxy 1";
            string location = "Mars";
            double longtitude = 45d;
            double latitude = 45d;
            double anotherLongtitude = 46d;
            double anotherLatitude = 46d;

            uint bronzeCoins = 20;
            uint silverCoins = 30;
            uint goldCoins = 40;

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(location);
            locationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(longtitude);
            locationMock.SetupGet(l => l.Coordinates.Latitude).Returns(latitude);

            unitMock.SetupGet(u => u.CurrentLocation).Returns(locationMock.Object);

            resources.SetupGet(r => r.BronzeCoins).Returns(bronzeCoins);
            resources.SetupGet(r => r.SilverCoins).Returns(silverCoins);
            resources.SetupGet(r => r.GoldCoins).Returns(goldCoins);

            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns(galaxy);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns(location);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Longtitude).Returns(longtitude);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Latitude).Returns(latitude);
            pathMock.SetupGet(p => p.Cost).Returns(resources.Object);

            ICollection<IUnit> units = new List<IUnit>() { unitMock.Object };
            pathMock.SetupGet(p => p.TargetLocation.Planet.Units).Returns(units);

            IEnumerable<IPath> paths = new List<IPath>() { pathMock.Object };
            IEnumerable<IPath> galacticMapMock = paths;

            IBusinessOwner expectedOwner = ownerMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(galaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(location);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Units).Returns(units);
            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(resources.Object)).Returns(resources.Object);

            targetLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            targetLocationMock.SetupGet(l => l.Planet.Name).Returns(location);
            targetLocationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(anotherLongtitude);
            targetLocationMock.SetupGet(l => l.Coordinates.Latitude).Returns(anotherLatitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            ExtendedTeleportStation teleportStation = new ExtendedTeleportStation(expectedOwner, galacticMapMock, expectedLocation);

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            unitToTeleportMock.VerifySet(u => u.CurrentLocation = targetLocationMock.Object, Times.Once());
        }

        [Test]
        public void AddTheTeleportedUnitToThePlanetUnits_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var unitMock = new Mock<IUnit>();
            var resources = new Mock<IResources>();

            string galaxy = "Galaxy 1";
            string location = "Mars";
            double longtitude = 45d;
            double latitude = 45d;
            double anotherLongtitude = 46d;
            double anotherLatitude = 46d;

            uint bronzeCoins = 20;
            uint silverCoins = 30;
            uint goldCoins = 40;

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(location);
            locationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(longtitude);
            locationMock.SetupGet(l => l.Coordinates.Latitude).Returns(latitude);

            unitMock.SetupGet(u => u.CurrentLocation).Returns(locationMock.Object);

            resources.SetupGet(r => r.BronzeCoins).Returns(bronzeCoins);
            resources.SetupGet(r => r.SilverCoins).Returns(silverCoins);
            resources.SetupGet(r => r.GoldCoins).Returns(goldCoins);

            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns(galaxy);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns(location);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Longtitude).Returns(longtitude);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Latitude).Returns(latitude);
            pathMock.SetupGet(p => p.Cost).Returns(resources.Object);

            var unitsCollectionEnumeratorMock = new Mock<IEnumerator<IUnit>>();
            unitsCollectionEnumeratorMock.Setup(x => x.Current).Returns(unitMock.Object);

            var unitsMock = new Mock<IList<IUnit>>();
            unitsMock.Setup(u => u.GetEnumerator()).Returns(unitsCollectionEnumeratorMock.Object);

            pathMock.SetupGet(p => p.TargetLocation.Planet.Units).Returns(unitsMock.Object);

            IEnumerable<IPath> paths = new List<IPath>() { pathMock.Object };
            IEnumerable<IPath> galacticMapMock = paths;

            IBusinessOwner expectedOwner = ownerMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(galaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(location);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Units).Returns(unitsMock.Object);
            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(resources.Object)).Returns(resources.Object);

            targetLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            targetLocationMock.SetupGet(l => l.Planet.Name).Returns(location);
            targetLocationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(anotherLongtitude);
            targetLocationMock.SetupGet(l => l.Coordinates.Latitude).Returns(anotherLatitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            ExtendedTeleportStation teleportStation = new ExtendedTeleportStation(expectedOwner, galacticMapMock, expectedLocation);

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            unitsMock.Verify(u => u.Add(unitToTeleportMock.Object), Times.Once());
        }

        [Test]
        public void RemoveTheTeleportedUnitFromTheListsOfUnitsOfTheCurrentLocation_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var unitMock = new Mock<IUnit>();
            var resources = new Mock<IResources>();

            string galaxy = "Galaxy 1";
            string location = "Mars";
            double longtitude = 45d;
            double latitude = 45d;
            double anotherLongtitude = 46d;
            double anotherLatitude = 46d;

            uint bronzeCoins = 20;
            uint silverCoins = 30;
            uint goldCoins = 40;

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(location);
            locationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(longtitude);
            locationMock.SetupGet(l => l.Coordinates.Latitude).Returns(latitude);

            unitMock.SetupGet(u => u.CurrentLocation).Returns(locationMock.Object);

            resources.SetupGet(r => r.BronzeCoins).Returns(bronzeCoins);
            resources.SetupGet(r => r.SilverCoins).Returns(silverCoins);
            resources.SetupGet(r => r.GoldCoins).Returns(goldCoins);

            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns(galaxy);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns(location);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Longtitude).Returns(longtitude);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Latitude).Returns(latitude);
            pathMock.SetupGet(p => p.Cost).Returns(resources.Object);

            var unitsCollectionEnumeratorMock = new Mock<IEnumerator<IUnit>>();
            unitsCollectionEnumeratorMock.Setup(x => x.Current).Returns(unitMock.Object);

            var unitsMock = new Mock<IList<IUnit>>();
            unitsMock.Setup(u => u.GetEnumerator()).Returns(unitsCollectionEnumeratorMock.Object);

            pathMock.SetupGet(p => p.TargetLocation.Planet.Units).Returns(unitsMock.Object);

            IEnumerable<IPath> paths = new List<IPath>() { pathMock.Object };
            IEnumerable<IPath> galacticMapMock = paths;

            IBusinessOwner expectedOwner = ownerMock.Object;
            ILocation expectedLocation = locationMock.Object;

            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(galaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(location);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Units).Returns(unitsMock.Object);
            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(resources.Object)).Returns(resources.Object);

            targetLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            targetLocationMock.SetupGet(l => l.Planet.Name).Returns(location);
            targetLocationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(anotherLongtitude);
            targetLocationMock.SetupGet(l => l.Coordinates.Latitude).Returns(anotherLatitude);

            IUnit expectedUnitToTeleport = unitToTeleportMock.Object;
            ILocation expectedTargetLocation = targetLocationMock.Object;

            ExtendedTeleportStation teleportStation = new ExtendedTeleportStation(expectedOwner, galacticMapMock, expectedLocation);

            // Act
            teleportStation.TeleportUnit(expectedUnitToTeleport, expectedTargetLocation);

            // Assert
            unitsMock.Verify(u => u.Remove(unitToTeleportMock.Object), Times.Once());
        }
    }
}
