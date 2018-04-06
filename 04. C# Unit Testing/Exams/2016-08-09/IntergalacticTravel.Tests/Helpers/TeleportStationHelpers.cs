using System.Collections.Generic;
using IntergalacticTravel.Contracts;

using Moq;

namespace IntergalacticTravel.Tests.Helpers
{
    internal static class TeleportStationHelpers
    {
        private static IResources resources;
        private static ICollection<IUnit> units;

        internal static Mock<IList<IUnit>> UnitsMock { get; set; }

        internal static IPath Path { get; set; }

        internal static ExtendedTeleportStation ArrangeTeleportStation()
        {
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var unitMock = new Mock<IUnit>();

            ownerMock.Setup(o => o.IdentificationNumber).Returns(TeleportStationConstants.IdentificationNumber);

            locationMock.Setup(l => l.Planet.Galaxy.Name).Returns(TeleportStationConstants.Galaxy);
            locationMock.Setup(l => l.Planet.Name).Returns(TeleportStationConstants.Location);
            locationMock.Setup(l => l.Coordinates.Longtitude).Returns(TeleportStationConstants.Longtitude);
            locationMock.Setup(l => l.Coordinates.Latitude).Returns(TeleportStationConstants.Latitude);

            IBusinessOwner expectedOwner = ownerMock.Object;
            IEnumerable<IPath> expectedMap = ArrangeGalacticMock(ref pathMock, ref unitMock);
            ILocation expectedLocation = locationMock.Object;

            ExtendedTeleportStation teleportStation = new ExtendedTeleportStation(expectedOwner, expectedMap, expectedLocation);

            return teleportStation;
        }

        internal static void SetupUnitToTeleport(ref Mock<IUnit> unitToTeleportMock, string targetGalaxy, string targetLocation)
        {
            unitToTeleportMock.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(targetGalaxy);
            unitToTeleportMock.Setup(u => u.CurrentLocation.Planet.Name).Returns(targetLocation);
            unitToTeleportMock.Setup(u => u.CurrentLocation.Planet.Units).Returns(units);
            unitToTeleportMock.Setup(u => u.Pay(resources)).Returns(resources);
        }

        internal static void SetupTargetLocation(ref Mock<ILocation> targetLocationMock, string galaxy, string location, double longtitude, double latitude)
        {
            targetLocationMock.Setup(l => l.Planet.Galaxy.Name).Returns(galaxy);
            targetLocationMock.Setup(l => l.Planet.Name).Returns(location);
            targetLocationMock.Setup(l => l.Coordinates.Longtitude).Returns(longtitude);
            targetLocationMock.Setup(l => l.Coordinates.Latitude).Returns(latitude);
        }

        private static IEnumerable<IPath> ArrangeGalacticMock(ref Mock<IPath> pathMock, ref Mock<IUnit> unitMock)
        {
            var resourcesMock = new Mock<IResources>();

            resourcesMock.Setup(r => r.BronzeCoins).Returns(TeleportStationConstants.BronzeCoins);
            resourcesMock.Setup(r => r.SilverCoins).Returns(TeleportStationConstants.SilverCoins);
            resourcesMock.Setup(r => r.GoldCoins).Returns(TeleportStationConstants.GoldCoins);

            resources = resourcesMock.Object;

            unitMock.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(TeleportStationConstants.Galaxy);
            unitMock.Setup(u => u.CurrentLocation.Planet.Name).Returns(TeleportStationConstants.Location);
            unitMock.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(TeleportStationConstants.Longtitude);
            unitMock.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(TeleportStationConstants.Latitude);

            var unitsCollectionEnumeratorMock = CreateEnumeratorForUnits(unitMock.Object);

            var unitsMock = new Mock<IList<IUnit>>();
            unitsMock.Setup(u => u.GetEnumerator()).Returns(unitsCollectionEnumeratorMock);

            UnitsMock = unitsMock;
            units = unitsMock.Object;

            pathMock.Setup(p => p.TargetLocation.Planet.Galaxy.Name).Returns(TeleportStationConstants.Galaxy);
            pathMock.Setup(p => p.TargetLocation.Planet.Name).Returns(TeleportStationConstants.Location);
            pathMock.Setup(p => p.TargetLocation.Coordinates.Longtitude).Returns(TeleportStationConstants.Longtitude);
            pathMock.Setup(p => p.TargetLocation.Coordinates.Latitude).Returns(TeleportStationConstants.Latitude);
            pathMock.Setup(p => p.TargetLocation.Planet.Units).Returns(unitsMock.Object);
            pathMock.Setup(p => p.Cost).Returns(resourcesMock.Object);

            Path = pathMock.Object;

            IEnumerable<IPath> paths = new List<IPath>() { pathMock.Object };
            IEnumerable<IPath> galacticMapMock = paths;

            return galacticMapMock;
        }

        private static IEnumerator<IUnit> CreateEnumeratorForUnits<IUnit>(params IUnit[] items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}
