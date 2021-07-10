using System;
using System.Collections.Generic;

namespace hepsiburada.MarsRover
{
    public class CommandParser
    {
        private readonly string instructions;
        private readonly IDictionary<char, IRoverCommand> commandsLookup = new Dictionary<char, IRoverCommand>
        {
            {'M', new MoveForwardCommand()},
            {'L', new SpinLeftCommand()},
            {'R', new SpinRightCommand()}
        };
        public CommandParser(string instructions)
        {
            this.instructions = instructions;
        }

        public List<IRoverCommand> GetCommands()
        {
            var commands = new List<IRoverCommand>();
            char[] instructionChars = instructions.ToCharArray();
            for (int i = 0; i < instructionChars.Length; i++)
            {
                commands.Add(commandsLookup[instructionChars[i]]);   
            }
            return commands;
        }
    }
}
