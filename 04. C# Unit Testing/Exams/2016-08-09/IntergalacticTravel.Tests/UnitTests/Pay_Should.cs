using System;
using IntergalacticTravel.Contracts;

using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.UnitTests
{
    [TestFixture]
    public class Pay_Should
    {
        private const uint BronzeCoins = 40;
        private const uint OtherBronzeCoins = 50;
        private const uint SilverCoins = 60;
        private const uint OtherSilverCoins = 10;
        private const uint GoldCoins = 30;
        private const uint OtherGoldCoins = 90;

        [Test]
        public void ThrowNullReferenceException_IfThePassedObjectIsNull()
        {
            // Arrange
            int identificationNumber = 100;
            string nickName = "Owner nickName";

            Unit unit = new Unit(identificationNumber, nickName);

            // Act && Assert
            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void DecreaseTheOwnersAmountOfResources_ByTheAmountOfTheCost()
        {
            // Arrange
            int identificationNumber = 100;
            string nickName = "Owner nickName";

            Unit unit = new Unit(identificationNumber, nickName);

            var resourcesMock = new Mock<IResources>();
            resourcesMock.Setup(r => r.BronzeCoins).Returns(BronzeCoins);
            resourcesMock.Setup(r => r.SilverCoins).Returns(SilverCoins);
            resourcesMock.Setup(r => r.GoldCoins).Returns(GoldCoins);

            var otherResourcesMock = new Mock<IResources>();
            otherResourcesMock.Setup(r => r.BronzeCoins).Returns(OtherBronzeCoins);
            otherResourcesMock.Setup(r => r.SilverCoins).Returns(OtherSilverCoins);
            otherResourcesMock.Setup(r => r.GoldCoins).Returns(OtherGoldCoins);

            unit.Resources.Add(resourcesMock.Object);
            unit.Resources.Add(otherResourcesMock.Object);

            // Act
            unit.Pay(otherResourcesMock.Object);
            uint expectedBronzeCoins = BronzeCoins;
            uint expectedSilverCoins = SilverCoins;
            uint expectedGoldCoins = GoldCoins;

            uint actualBronzeCoins = unit.Resources.BronzeCoins;
            uint actualSilverCoins = unit.Resources.SilverCoins;
            uint actualGoldCoins = unit.Resources.GoldCoins;

            // Assert
            Assert.AreEqual(expectedBronzeCoins, actualBronzeCoins);
            Assert.AreEqual(expectedSilverCoins, actualSilverCoins);
            Assert.AreEqual(expectedGoldCoins, actualGoldCoins);
        }

        [Test]
        public void ReturnResourceObject_WithTheAmountOfResourcesInTheCostObject()
        {
            // Arrange
            int identificationNumber = 100;
            string nickName = "Owner nickName";

            Unit unit = new Unit(identificationNumber, nickName);

            var resourcesMock = new Mock<IResources>();
            resourcesMock.Setup(r => r.BronzeCoins).Returns(BronzeCoins);
            resourcesMock.Setup(r => r.SilverCoins).Returns(SilverCoins);
            resourcesMock.Setup(r => r.GoldCoins).Returns(GoldCoins);

            var otherResourcesMock = new Mock<IResources>();
            otherResourcesMock.Setup(r => r.BronzeCoins).Returns(OtherBronzeCoins);
            otherResourcesMock.Setup(r => r.SilverCoins).Returns(OtherSilverCoins);
            otherResourcesMock.Setup(r => r.GoldCoins).Returns(OtherGoldCoins);

            unit.Resources.Add(resourcesMock.Object);
            unit.Resources.Add(otherResourcesMock.Object);

            // Act
            IResources resources = unit.Pay(otherResourcesMock.Object);
            uint expectedBronzeCoins = OtherBronzeCoins;
            uint expectedSilverCoins = OtherSilverCoins;
            uint expectedGoldCoins = OtherGoldCoins;

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
