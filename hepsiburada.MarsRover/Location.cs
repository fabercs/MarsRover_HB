using System.Collections.Generic;

namespace hepsiburada.MarsRover
{
    public class Location
    {
        private readonly Dictionary<string, char> directionLookup =
            new Dictionary<string, char>()
            {
                {"LN",'W'},
                {"LS",'E'},
                {"LW",'S'},
                {"LE",'N'},
                {"RN",'E'},
                {"RS",'W'},
                {"RW",'N'},
                {"RE",'S' }
            };

        private readonly char _direction;
        private readonly Coordinate _coordinate;
        
        public Location(Coordinate coordinate, char direction)
        {
            _coordinate = coordinate;
            _direction = direction;
        }
        public Location Forward()
        {
            return _direction switch
            {
                Direction.North => new Location(_coordinate.OneStepForwardOnYCoordinate(), _direction),
                Direction.South => new Location(_coordinate.OneStepBackwardOnYCoordinate(), _direction),
                Direction.West => new Location(_coordinate.OneStepBackwardOnXCoordinate(), _direction),
                Direction.East => new Location(_coordinate.OneStepForwardOnXCoordinate(), _direction),
                _ => this,
            };
        }
        public Location ToLeft()
        {
            return new Location(_coordinate, directionLookup.GetValueOrDefault("L" + _direction));
        }
        public Location ToRight()
        {
            return new Location(_coordinate, directionLookup.GetValueOrDefault("R" + _direction));
        }
        public Coordinate GetCooridante() => _coordinate;
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _coordinate.XCoordinate, _coordinate.YCoordinate, _direction);
        }

    }
}
