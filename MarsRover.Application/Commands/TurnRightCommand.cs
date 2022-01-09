using MarsRover.Application.Common.Interfaces;
using MarsRover.Domain.Rovers;

namespace MarsRover.Application.Commands
{
    public class TurnRightCommand : ICommand
    {
        private readonly Rover _rover;

        public TurnRightCommand(Rover rover)
        {
            _rover = rover;
        }
        public void Execute()
        {
            _rover.TurnRight();
        }
    }
}