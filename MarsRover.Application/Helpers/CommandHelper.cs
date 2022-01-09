using System;
using System.Collections.Generic;
using MarsRover.Application.Commands;
using MarsRover.Application.Common.Interfaces;
using MarsRover.Domain.Rovers;

namespace MarsRover.Application.Helpers
{
    public static class CommandHelper
    {
        public static List<ICommand> GetRoverCommands(Rover rover, string directions)
        {
            List<ICommand> commands = new();

            foreach (char direction in directions.Trim().ToUpper())
            {
                switch (direction)
                {
                    case 'L':
                        commands.Add(new TurnLeftCommand(rover));
                        break;

                    case 'R':
                        commands.Add(new TurnRightCommand(rover));
                        break;

                    case 'M':
                        commands.Add(new MoveCommand(rover));
                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }

            return commands;
        }
    }
}