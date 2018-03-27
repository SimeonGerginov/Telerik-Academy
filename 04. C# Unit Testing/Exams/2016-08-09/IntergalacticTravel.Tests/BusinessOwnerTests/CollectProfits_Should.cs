using System.Collections.Generic;
using IntergalacticTravel.Contracts;

using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.BusinessOwnerTests
{
    [TestFixture]
    public class CollectProfits_Should
    {
        private const uint BronzeCoins = 40;
        private const uint SilverCoins = 30;
        private const uint GoldCoins = 35;

        [Test]
        public void IncreaseTheOwnerResourcesByTheTotalAmountGeneratedFromTheTStations_ThatAreInHisPossession()
        {
            // Arrange
            int identificationNumber = 100;
            string nickName = "Owner nickName";
            IEnumerable<ITeleportStation> teleportStations = this.ArrangeTeleportStations();

            BusinessOwner owner = new BusinessOwner(identificationNumber, nickName, teleportStations);
            uint expectedBronzeCoins = BronzeCoins;
            uint expectedSilverCoins = SilverCoins;
            uint expectedGoldCoins = GoldCoins;

            // Act
            owner.CollectProfits();
            uint actualBronzeCoins = owner.Resources.BronzeCoins;
            uint actualSilverCoins = owner.Resources.SilverCoins;
            uint actualGoldCoins = owner.Resources.GoldCoins;

            // Assert
            Assert.AreEqual(expectedBronzeCoins, actualBronzeCoins);
            Assert.AreEqual(expectedSilverCoins, actualSilverCoins);
            Assert.AreEqual(expectedGoldCoins, actualGoldCoins);
        }

        private IEnumerable<ITeleportStation> ArrangeTeleportStations()
        {
            var teleportStationMock = new Mock<ITeleportStation>();
            var resourcesMock = new Mock<IResources>();
            IEnumerable<ITeleportStation> teleportStations;

            resourcesMock.SetupGet(r => r.BronzeCoins).Returns(BronzeCoins);
            resourcesMock.SetupGet(r => r.SilverCoins).Returns(SilverCoins);
            resourcesMock.SetupGet(r => r.GoldCoins).Returns(GoldCoins);

            teleportStationMock.Setup(ts => ts.PayProfits(It.IsAny<IBusinessOwner>())).Returns(resourcesMock.Object);

            var teleportStationCollectionEnumeratorMock = this.CreateEnumeratorForTeleportStation(teleportStationMock.Object);

            var teleportStationsMock = new Mock<IList<ITeleportStation>>();
            teleportStationsMock.Setup(ts => ts.GetEnumerator()).Returns(teleportStationCollectionEnumeratorMock);

            teleportStations = teleportStationsMock.Object;

            return teleportStations;
        }

        private IEnumerator<ITeleportStation> CreateEnumeratorForTeleportStation<ITeleportStation>(params ITeleportStation[] items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}
