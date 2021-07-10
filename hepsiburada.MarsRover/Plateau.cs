namespace hepsiburada.MarsRover
{
    public interface IPlateau
    {
        bool IsCoordinateWithinBoundry(Coordinate coordinate);
    }
    public class Plateau : IPlateau
    {
        private readonly Coordinate lowerLeftcoordinate = new Coordinate(0, 0);
        private readonly Coordinate topRightcoordinate = new Coordinate(0, 0);

        public Plateau(int xCoordinate, int yCoordinate)
        {
            topRightcoordinate = topRightcoordinate.CreateCoordinate(xCoordinate, yCoordinate);
        }

        public bool IsCoordinateWithinBoundry(Coordinate coordinate)
        {
            return lowerLeftcoordinate.IsCoordinateOutBoundry(coordinate) && topRightcoordinate.IsCoordinateWithinBoundry(coordinate);
        }

    }
}
