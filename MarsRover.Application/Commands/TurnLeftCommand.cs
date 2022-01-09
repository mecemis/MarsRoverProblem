using MarsRover.Application.Common.Interfaces;
using MarsRover.Domain.Rovers;

namespace MarsRover.Application.Commands
{
    public class TurnLeftCommand : ICommand
    {
        private readonly Rover _rover;

        public TurnLeftCommand(Rover rover)
        {
            _rover = rover;
        }
        public void Execute()
        {
            _rover.TurnLeft();
        }
    }
}