using NUnit.Framework;

namespace hepsiburada.MarsRover.UnitTests
{
    [TestFixture]
    public class CoordinateTests
    {
        [Test]
        [TestCase(0, 0, 1)]
        [TestCase(1, 3, 4)]
        public void On_OneStepForwardOnYCoordinate_IncrementYCoordinate(int x, int y, int expecteedCoordinate)
        {
            var coordinate = new Coordinate(x, y);
            coordinate = coordinate.OneStepForwardOnYCoordinate();

            Assert.IsTrue(coordinate.YCoordinate == expecteedCoordinate);
        }
        [Test]
        [TestCase(5, 5, 4)]
        [TestCase(4, 4, 3)]
        public void On_OneStepBackwardOnYCoordinate_DecrementYCoordinate(int x, int y, int expecteedCoordinate)
        {
            var coordinate = new Coordinate(x, y);
            coordinate = coordinate.OneStepBackwardOnYCoordinate();

            Assert.IsTrue(coordinate.YCoordinate == expecteedCoordinate);
        }
        [Test]
        [TestCase(0, 0, 1)]
        [TestCase(1, 3, 2)]
        public void On_OneStepForwardOnXCoordinate_IncrementXCoordinate(int x, int y, int expecteedCoordinate)
        {
            var coordinate = new Coordinate(x, y);
            coordinate = coordinate.OneStepForwardOnXCoordinate();

            Assert.IsTrue(coordinate.XCoordinate == expecteedCoordinate);
        }
        [Test]
        [TestCase(5, 5, 4)]
        [TestCase(4, 4, 3)]
        public void On_OneStepBackwardOnXCoordinate_DecrementXCoordinate(int x, int y, int expecteedCoordinate)
        {
            var coordinate = new Coordinate(x, y);
            coordinate = coordinate.OneStepBackwardOnXCoordinate();

            Assert.IsTrue(coordinate.XCoordinate == expecteedCoordinate);
        }

        [Test]
        [TestCase(5, 5, true)]
        [TestCase(0, 7, false)]
        public void Coordinates_Are_Within_Boundry(int x, int y, bool expectedResult)
        {
            var boundryCoordinates = new Coordinate(5, 5);
            var coordinate = new Coordinate(x, y);

            Assert.AreEqual(boundryCoordinates.IsCoordinateWithinBoundry(coordinate), expectedResult);
        }
        [Test]
        [TestCase(1, 2, false)]
        [TestCase(6, 7, true)]
        [TestCase(5, 7, true)]
        public void Coordinates_Are_Out_Of_Boundry(int x, int y, bool expectedResult)
        {
            var boundryCoordinates = new Coordinate(5, 5);
            var coordinate = new Coordinate(x, y);

            Assert.AreEqual(boundryCoordinates.IsCoordinateOutBoundry(coordinate), expectedResult);
        }


    }
}
