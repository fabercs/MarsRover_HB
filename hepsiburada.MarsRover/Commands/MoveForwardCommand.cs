namespace hepsiburada.MarsRover
{
    public class MoveForwardCommand : IRoverCommand
    {
        public void Execute(IRover rover)
        {
            rover.Forward();
        }
    }
}
