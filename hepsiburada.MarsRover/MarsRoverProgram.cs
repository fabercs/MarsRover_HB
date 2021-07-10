using hepsiburada.MarsRover.Helpers.Validator;
using System;
using System.Collections.Generic;

namespace hepsiburada.MarsRover
{
    public class MarsRoverProgram
    {
        static Plateau plateau;
        static readonly List<Rover> rovers = new List<Rover>();
        static readonly List<string> roverInstructions = new List<string>();
        static int roverCounter = 1;
        
        static void Main()
        {


            try
            {
                SetPlateauSize();

                bool stop = false;

                while (!stop)
                {
                    LoadRover();
                    LoadInstructions();
                    stop = AskToStop();
                    roverCounter++;
                }

                MoveRovers(rovers, roverInstructions);
                DisplayRoversFinalLocation(rovers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        private static void SetPlateauSize()
        {
            Console.WriteLine(ScreenMessages.ASK_PLATEAU_SIZE);
            var plateauSize = Console.ReadLine().Trim();

            var validator = new PlateauSizeInputValidator();
            var validationResult = validator.Validate(plateauSize);

            if (!validationResult.Succeeded)
            {
                Console.WriteLine(validationResult.ErrorMessage);
                Environment.Exit(0);
            }
            var coordinates = plateauSize.Split(' ');
            plateau = new Plateau(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
        }
        private static void LoadRover()
        {
            Console.WriteLine(string.Format(ScreenMessages.ASK_ROVER_COORDINATE, roverCounter));
            var location = Console.ReadLine().Trim();

            var validator = new RoverLocationInputValidator();
            var validationResult = validator.Validate(location);

            if (!validationResult.Succeeded)
            {
                Console.WriteLine(validationResult.ErrorMessage);
                Environment.Exit(0);
            }
            var coordinates = location.Split(' ');

            var roverCoordinate = new Coordinate(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            var roverDirection = Convert.ToChar(coordinates[2]);
            var roverLocation = new Location(roverCoordinate, roverDirection);
            var rover = new Rover(plateau, roverLocation);
            rovers.Add(rover);
        }
        private static void LoadInstructions()
        {
            Console.WriteLine(string.Format(ScreenMessages.ASK_ROVER_MOVEMENTS, roverCounter));
            var instructions = Console.ReadLine().Trim();

            var validator = new RoverInstructionInputValidator();
            var validationResult = validator.Validate(instructions);

            if(!validationResult.Succeeded)
            {
                Console.WriteLine(validationResult.ErrorMessage);
                Environment.Exit(0);
            }
            
            roverInstructions.Add(instructions);
        }
        private static bool AskToStop()
        {
            Console.WriteLine(ScreenMessages.ASK_TO_STOP);
            var answer = Console.ReadLine().Trim();

            return answer.Equals("Y") || answer.Equals("y");
        }
        private static void DisplayRoversFinalLocation(List<Rover> rovers)
        {
            rovers.ForEach(rover => Console.WriteLine(rover.GetCurrentLocation()));
        }
        private static void MoveRovers(List<Rover> rovers, List<string> instructions)
        {
            for (int i = 0; i < rovers.Count; i++)
            {
                rovers[i].Move(instructions[i]);
            }
        }
    }
}
