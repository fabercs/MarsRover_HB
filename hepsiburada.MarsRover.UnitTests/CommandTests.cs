using NUnit.Framework;

namespace hepsiburada.MarsRover.UnitTests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        [TestCase(0, 0, 'S', "0 0 E")]
        [TestCase(0, 0, 'N', "0 0 W")]
        [TestCase(0, 0, 'E', "0 0 N")]
        [TestCase(0, 0, 'W', "0 0 S")]
        public void SpinLeftCommand_WhenCalled_RoverRotateLeft(int x, int y, char direction, string expectedLocation)
        {
            var plateau = new Plateau(5, 5);
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);
            var rover = new Rover(plateau, location);

            var spinLeftCommand = new SpinLeftCommand();

            spinLeftCommand.Execute(rover);

            Assert.That(rover.GetCurrentLocation(), Is.EqualTo(expectedLocation));
        }

        [Test]
        [TestCase(0, 0, 'S', "0 0 W")]
        [TestCase(0, 0, 'N', "0 0 E")]
        [TestCase(0, 0, 'E', "0 0 S")]
        [TestCase(0, 0, 'W', "0 0 N")]
        public void SpinRightCommand_WhenCalled_RoverRotateRight(int x, int y, char direction, string expectedLocation)
        {
            var plateau = new Plateau(5, 5);
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);
            var rover = new Rover(plateau, location);

            var spinLeftCommand = new SpinRightCommand();

            spinLeftCommand.Execute(rover);

            Assert.That(rover.GetCurrentLocation(), Is.EqualTo(expectedLocation));
        }

        [Test]
        [TestCase(1, 1, 'S', "1 0 S")]
        [TestCase(1, 1, 'N', "1 2 N")]
        [TestCase(0, 0, 'E', "1 0 E")]
        [TestCase(3, 3, 'W', "2 3 W")]
        public void MoveForwardCommand_WhenCalled_RoverMoveForward(int x, int y, char direction, string expectedLocation)
        {
            var plateau = new Plateau(5, 5);
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);
            var rover = new Rover(plateau, location);

            var spinLeftCommand = new MoveForwardCommand();

            spinLeftCommand.Execute(rover);

            Assert.That(rover.GetCurrentLocation(), Is.EqualTo(expectedLocation));
        }

       
    }
}
