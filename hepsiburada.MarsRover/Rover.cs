namespace hepsiburada.MarsRover
{
    public interface IRover
    {
        void Forward();
        void TurnLeft();
        void TurnRight();
        void Move(string instructions);
        string GetCurrentLocation();
    }
    public class Rover : IRover
    {
        private Location _location;
        private readonly IPlateau _plateau;

        public Rover(IPlateau plateau, Location location)
        {
            _location = location;
            _plateau = plateau;
        }
        public void Forward()
        {
            var nextLocation = _location.Forward();
            if (_plateau.IsCoordinateWithinBoundry(nextLocation.GetCooridante()))
                _location = nextLocation;
        }
        public void TurnLeft()
        {
            _location = _location.ToLeft();
        }
        public void TurnRight()
        {
            _location = _location.ToRight();
        }
        public string GetCurrentLocation() => _location.ToString();

        public void Move(string instructions)
        {
            var commandParser = new CommandParser(instructions);
            var commands = commandParser.GetCommands();
            foreach (var command in commands)
            {
                command.Execute(this);
            }
        }

    }
}
