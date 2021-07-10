using NUnit.Framework;

namespace hepsiburada.MarsRover.UnitTests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        [TestCase(1, 2, 'N', "1 3 N")]
        [TestCase(0, 0, 'E', "1 0 E")]
        [TestCase(2, 3, 'W', "1 3 W")]
        [TestCase(3, 3, 'S', "3 2 S")]
        [TestCase(4, 5, 'E', "5 5 E")]
        public void MoveForward_WhenCalled_RoverMoveForward(int x, int y, char direction, string expectedLocation)
        {
            var plateau = new Plateau(5, 5);
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);
            var rover = new Rover(plateau, location);

            rover.Forward();

            Assert.That(rover.GetCurrentLocation(), Is.EqualTo(expectedLocation));
        }

        [Test]
        [TestCase(5, 5, 'N', "5 5 N")]
        [TestCase(0, 3, 'W', "0 3 W")]
        [TestCase(5, 1, 'E', "5 1 E")]
        [TestCase(0, 0, 'S', "0 0 S")]
        public void DoNotMove_WhenMoveForwardCalled_IfAtPlateauBoundry(int x, int y, char direction, string expectedLocation)
        {
            var plateau = new Plateau(5, 5);
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);
            var rover = new Rover(plateau, location);

            rover.Forward();

            Assert.That(rover.GetCurrentLocation(), Is.EqualTo(expectedLocation));
        }

        [Test]
        [TestCase(0, 0, 'S', "0 0 E")]
        [TestCase(0, 0, 'N', "0 0 W")]
        [TestCase(0, 0, 'E', "0 0 N")]
        [TestCase(0, 0, 'W', "0 0 S")]
        public void TurnLeft_WhenCalled_RoverTurnLeft(int x, int y, char direction, string expectedLocation)
        {
            var plateau = new Plateau(5, 5);
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);
            var rover = new Rover(plateau, location);

            rover.TurnLeft();

            Assert.That(rover.GetCurrentLocation(), Is.EqualTo(expectedLocation));
        }

        [Test]
        [TestCase(0, 0, 'S', "0 0 W")]
        [TestCase(0, 0, 'N', "0 0 E")]
        [TestCase(0, 0, 'E', "0 0 S")]
        [TestCase(0, 0, 'W', "0 0 N")]
        public void TurnRight_WhenCalled_RoverTurnRight(int x, int y, char direction, string expectedLocation)
        {
            var plateau = new Plateau(5, 5);
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);
            var rover = new Rover(plateau, location);

            rover.TurnRight();

            Assert.That(rover.GetCurrentLocation(), Is.EqualTo(expectedLocation));
        }

        [Test]
        [TestCase(1, 2, 'N', "LMLMLMLMM", "1 3 N")]
        [TestCase(3, 3, 'E', "MMRMMRMRRM", "5 1 E")]
        public void Can_Rover_Move_Instructions(int x, int y, char direction, string instructions, string expectedLocation)
        {
            var plateau = new Plateau(5, 5);
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);
            var rover = new Rover(plateau, location);

            rover.Move(instructions);

            Assert.That(rover.GetCurrentLocation(), Is.EqualTo(expectedLocation));
        }
        [Test]
        [TestCase(0, 0, 'N', "LM", "0 0 W")]
        [TestCase(0, 0, 'N', "MMMMMMMM", "0 5 N")]
        public void Rover_Cannot_Go_Out_Of_Plateau(int x, int y, char direction, string instructions, string expectedLocation)
        {
            var plateau = new Plateau(5, 5);
            var coordinate = new Coordinate(x, y);
            var location = new Location(coordinate, direction);
            var rover = new Rover(plateau, location);

            rover.Move(instructions);

            Assert.That(rover.GetCurrentLocation(), Is.EqualTo(expectedLocation));
        }
    }
}
