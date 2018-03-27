using System.Collections.Generic;
using IntergalacticTravel.Contracts;

using Moq;

namespace IntergalacticTravel.Tests.Helpers
{
    internal static class TeleportStationHelpers
    {
        private static IResources Resources;
        private static ICollection<IUnit> Units;
        internal static Mock<IList<IUnit>> UnitsMock;
        internal static IPath Path;

        internal static ExtendedTeleportStation ArrangeTeleportStation()
        {
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var unitMock = new Mock<IUnit>();

            ownerMock.SetupGet(o => o.IdentificationNumber).Returns(TeleportStationConstants.IdentificationNumber);

            locationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(TeleportStationConstants.Galaxy);
            locationMock.SetupGet(l => l.Planet.Name).Returns(TeleportStationConstants.Location);
            locationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(TeleportStationConstants.Longtitude);
            locationMock.SetupGet(l => l.Coordinates.Latitude).Returns(TeleportStationConstants.Latitude);

            IBusinessOwner expectedOwner = ownerMock.Object;
            IEnumerable<IPath> expectedMap = ArrangeGalacticMock(ref pathMock, ref unitMock);
            ILocation expectedLocation = locationMock.Object;

            ExtendedTeleportStation teleportStation = new ExtendedTeleportStation(expectedOwner, expectedMap, expectedLocation);

            return teleportStation;
        }

        internal static void SetupUnitToTeleport(ref Mock<IUnit> unitToTeleportMock, string targetGalaxy, string targetLocation)
        {
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(targetGalaxy);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Name).Returns(targetLocation);
            unitToTeleportMock.SetupGet(u => u.CurrentLocation.Planet.Units).Returns(Units);
            unitToTeleportMock.Setup(u => u.Pay(Resources)).Returns(Resources);
        }

        internal static void SetupTargetLocation(ref Mock<ILocation> targetLocationMock, string galaxy, string location, double longtitude, double latitude)
        {
            targetLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns(galaxy);
            targetLocationMock.SetupGet(l => l.Planet.Name).Returns(location);
            targetLocationMock.SetupGet(l => l.Coordinates.Longtitude).Returns(longtitude);
            targetLocationMock.SetupGet(l => l.Coordinates.Latitude).Returns(latitude);
        }

        private static IEnumerable<IPath> ArrangeGalacticMock(ref Mock<IPath> pathMock, ref Mock<IUnit> unitMock)
        {
            var resources = new Mock<IResources>();

            resources.SetupGet(r => r.BronzeCoins).Returns(TeleportStationConstants.BronzeCoins);
            resources.SetupGet(r => r.SilverCoins).Returns(TeleportStationConstants.SilverCoins);
            resources.SetupGet(r => r.GoldCoins).Returns(TeleportStationConstants.GoldCoins);

            Resources = resources.Object;

            unitMock.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(TeleportStationConstants.Galaxy);
            unitMock.Setup(u => u.CurrentLocation.Planet.Name).Returns(TeleportStationConstants.Location);
            unitMock.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(TeleportStationConstants.Longtitude);
            unitMock.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(TeleportStationConstants.Latitude);

            var unitsCollectionEnumeratorMock = CreateEnumeratorForUnits(unitMock.Object);

            var unitsMock = new Mock<IList<IUnit>>();
            unitsMock.Setup(u => u.GetEnumerator()).Returns(unitsCollectionEnumeratorMock);

            UnitsMock = unitsMock;
            Units = unitsMock.Object;

            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns(TeleportStationConstants.Galaxy);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns(TeleportStationConstants.Location);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Longtitude).Returns(TeleportStationConstants.Longtitude);
            pathMock.SetupGet(p => p.TargetLocation.Coordinates.Latitude).Returns(TeleportStationConstants.Latitude);
            pathMock.SetupGet(p => p.TargetLocation.Planet.Units).Returns(unitsMock.Object);
            pathMock.SetupGet(p => p.Cost).Returns(resources.Object);

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
