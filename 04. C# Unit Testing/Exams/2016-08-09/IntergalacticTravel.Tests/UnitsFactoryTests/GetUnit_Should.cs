using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.UnitsFactoryTests
{
    [TestFixture]
    public class GetUnit_Should
    {
        [Test]
        public void ReturnNewProcyonUnit_WhenValidCommandIsPassed()
        {
            // Arrange
            string command = "create unit Procyon Gosho 1";
            UnitsFactory unitsFactory = new UnitsFactory();

            // Act
            IUnit unit = unitsFactory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Procyon>(unit);
        }

        [Test]
        public void ReturnNewLuytenUnit_WhenValidCommandIsPassed()
        {
            // Arrange
            string command = "create unit Luyten Pesho 2";
            UnitsFactory unitsFactory = new UnitsFactory();

            // Act
            IUnit unit = unitsFactory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Luyten>(unit);
        }

        [Test]
        public void ReturnNewLacailleUnit_WhenValidCommandIsPassed()
        {
            // Arrange
            string command = "create unit Lacaille Tosho 3";
            UnitsFactory unitsFactory = new UnitsFactory();

            // Act
            IUnit unit = unitsFactory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Lacaille>(unit);
        }

        [Test]
        public void ThrowException_WhenInvalidUnitIsPassed()
        {
            // Arrange
            string command = "create unit Fake Tosho 3";
            UnitsFactory unitsFactory = new UnitsFactory();

            // Act && Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => unitsFactory.GetUnit(command));
        }

        [Test]
        public void ThrowException_WhenInvalidParameterCountIsPassed()
        {
            // Arrange
            string command = "create Luyten Tosho 3";
            UnitsFactory unitsFactory = new UnitsFactory();

            // Act && Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => unitsFactory.GetUnit(command));
        }
    }
}
