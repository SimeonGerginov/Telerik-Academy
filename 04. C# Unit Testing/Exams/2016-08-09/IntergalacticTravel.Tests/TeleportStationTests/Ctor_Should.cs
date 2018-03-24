using System.Collections.Generic;
using IntergalacticTravel.Contracts;

using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void SetUpAllTheProdivedFields_WhenNewInstanceIsCreated()
        {
            // Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var galacticMapMock = new Mock<IEnumerable<IPath>>();
            var locationMock = new Mock<ILocation>();

            IBusinessOwner expectedOwner = ownerMock.Object;
            IEnumerable<IPath> expectedMap = galacticMapMock.Object;
            ILocation expectedLocation = locationMock.Object;

            // Act
            ExtendedTeleportStation teleportStation = new ExtendedTeleportStation(expectedOwner, expectedMap, expectedLocation);
            IBusinessOwner actualOwner = teleportStation.Owner;
            IEnumerable<IPath> actualMap = teleportStation.GalacticMap;
            ILocation actualLocation = teleportStation.Location;

            // Assert
            Assert.AreEqual(expectedOwner, actualOwner);
            Assert.AreEqual(expectedMap, actualMap);
            Assert.AreEqual(expectedLocation, actualLocation);
        }
    }
}
