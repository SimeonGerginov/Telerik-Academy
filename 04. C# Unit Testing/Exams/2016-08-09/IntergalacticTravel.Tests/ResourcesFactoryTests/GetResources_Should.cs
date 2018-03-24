using System;
using IntergalacticTravel.Contracts;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.ResourcesFactoryTests
{
    [TestFixture]
    public class GetResources_Should
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void CreateNewResourcesObject_WhenValidInputIsPassed(string command)
        {
            // Arrange
            ResourcesFactory factory = new ResourcesFactory();
            int bronzeCoins = 40;
            int silverCoins = 30;
            int goldCoins = 20;

            // Act
            IResources resources = factory.GetResources(command);

            // Assert
            Assert.AreEqual(resources.BronzeCoins, bronzeCoins);
            Assert.AreEqual(resources.SilverCoins, silverCoins);
            Assert.AreEqual(resources.GoldCoins, goldCoins);
        }

        [TestCase("create resources x y z")]
        [TestCase("create resources gold20 silver30 bronze40")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void ThrowInvalidOperationException_WhenInvalidInputIsPassed(string command)
        {
            // Arrange
            ResourcesFactory factory = new ResourcesFactory();
            string exceptionMessage = "command";

            // Act
            Exception exception = Assert.Throws<InvalidOperationException>(() => factory.GetResources(command));

            // Assert
            Assert.That(exception.Message, Does.Contain(exceptionMessage));
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void ThrowOverflowException_WhenAnyOfTheParametersIsLargerThanMaxValue(string command)
        {
            // Arrange
            ResourcesFactory factory = new ResourcesFactory();

            // Act && Assert
            Assert.Throws<OverflowException>(() => factory.GetResources(command));
        }
    }
}
