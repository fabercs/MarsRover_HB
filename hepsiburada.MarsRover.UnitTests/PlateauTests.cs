using NUnit.Framework;

namespace hepsiburada.MarsRover.UnitTests
{
    [TestFixture]
    public class PlateauTests
    {
        [Test]
        [TestCase(6, 7, false)]
        [TestCase(1, 3, true)]
        public void Is_Given_Coordinate_Valid_On_Plateau(int x, int y, bool expectedResult)
        {
            var plateau = new Plateau(5, 5);
            var coordinate = new Coordinate(x, y);

            Assert.AreEqual(plateau.IsCoordinateWithinBoundry(coordinate), expectedResult);
        }

    }
}
