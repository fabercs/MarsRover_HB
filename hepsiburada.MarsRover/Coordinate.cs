namespace hepsiburada.MarsRover
{
    public class Coordinate
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }

        public Coordinate(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
        public Coordinate OneStepForwardOnYCoordinate() => new Coordinate(XCoordinate, YCoordinate + 1);
        public Coordinate OneStepForwardOnXCoordinate() => new Coordinate(XCoordinate + 1, YCoordinate);
        public Coordinate OneStepBackwardOnYCoordinate() => new Coordinate(XCoordinate, YCoordinate - 1);
        public Coordinate OneStepBackwardOnXCoordinate() => new Coordinate(XCoordinate - 1, YCoordinate);
        public Coordinate CreateCoordinate(int xCoordinate, int yCoordinate) => new Coordinate(xCoordinate, yCoordinate);
        public bool IsCoordinateWithinBoundry(Coordinate coordinate)
        {
            return IsXCoordinateWithinBoundry(coordinate.XCoordinate) && IsYCoordinateWithinBoundry(coordinate.YCoordinate);
        }
        public bool IsCoordinateOutBoundry(Coordinate coordinate)
        {
            return IsXCoordinateOutBoundry(coordinate.XCoordinate) && IsYCoordinateOutBoundry(coordinate.YCoordinate);
        }
        private bool IsXCoordinateWithinBoundry(int x)
        {
            return x <= XCoordinate;
        }
        private bool IsYCoordinateWithinBoundry(int y)
        {
            return y <= YCoordinate;
        }
        private bool IsXCoordinateOutBoundry(int x)
        {
            return x >= XCoordinate;
        }
        private bool IsYCoordinateOutBoundry(int y)
        {
            return y >= YCoordinate;
        }
    }
}
