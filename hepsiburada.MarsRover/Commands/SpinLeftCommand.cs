namespace hepsiburada.MarsRover
{
    public class SpinLeftCommand : IRoverCommand
    {
        public void Execute(IRover rover)
        {
            rover.TurnLeft();
        }
    }
}
