using MarsRover.Application.Common.Interfaces;
using MarsRover.Domain.Rovers;
using MarsRover.Domain.Surface;

namespace MarsRover.Application.Commands
{
    public class DeployRoverCommand : ICommand
    {
        public Rover Rover { get; private set; }
        private readonly Plateau _plateau;
        private readonly string _roverStartingPositionInput;

        public DeployRoverCommand(Plateau plateau, string roverStartingPositionInput,int roverId)
        {
            Rover = new Rover(roverId);
            _plateau = plateau;
            _roverStartingPositionInput = roverStartingPositionInput;
        }
        public void Execute()
        {
            Rover.DeployRover(_plateau, _roverStartingPositionInput);
        }
    }
}