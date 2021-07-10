using NUnit.Framework;

namespace hepsiburada.MarsRover.UnitTests
{
    [TestFixture]
    public class LocationTests
    {
        [Test]
        [TestCase(1, 2, 'N', "1 3 N")]
        [TestCase(0, 0, 'E', "1 0 E")]
        [TestCase(2, 3, 'W', "1 3 W")]
        [TestCase(3, 3, 'S', "3 2 S")]
        [TestCase(4, 5, 'E', "5 5 E")]
        public void When_Location_Forward_Called_NewLocation_Forwarded(int x, int y, char direction, string expectedLocation)
        {
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);

            var newLocation = location.Forward();
            

            Assert.That(newLocation.ToString(), Is.EqualTo(expectedLocation));
        }

        [Test]
        [TestCase(1, 2, 'N', "1 2 E")]
        [TestCase(0, 0, 'E', "0 0 S")]
        [TestCase(2, 3, 'W', "2 3 N")]
        [TestCase(3, 3, 'S', "3 3 W")]
        public void When_Location_ToRight_Called_NewLocation_Direction_Changed(int x, int y, char direction, string expectedLocation)
        {
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);

            var newLocation = location.ToRight();


            Assert.That(newLocation.ToString(), Is.EqualTo(expectedLocation));
        }

        [Test]
        [TestCase(1, 2, 'N', "1 2 W")]
        [TestCase(0, 0, 'E', "0 0 N")]
        [TestCase(2, 3, 'W', "2 3 S")]
        [TestCase(3, 3, 'S', "3 3 E")]
        public void When_Location_ToLeft_Called_NewLocation_Direction_Changed(int x, int y, char direction, string expectedLocation)
        {
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);

            var newLocation = location.ToLeft();


            Assert.That(newLocation.ToString(), Is.EqualTo(expectedLocation));
        }

        [Test]
        [TestCase(1, 2, 'N')]
        [TestCase(0, 0, 'E')]
        [TestCase(2, 3, 'W')]
        [TestCase(3, 3, 'S')]
        [TestCase(4, 5, 'E')]
        public void When_GetCoordinateCalled_Return_CurrentCoordinate(int x, int y, char direction)
        {
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);

            Assert.That(location.GetCooridante(), Is.EqualTo(coordinate));
        }


    }
}
