namespace hepsiburada.MarsRover
{
    public class SpinRightCommand : IRoverCommand
    {
        public void Execute(IRover rover)
        {
            rover.TurnRight();
        }
    }
}
