using MarsRover.Application.Common.Interfaces;
using MarsRover.Domain.Surface;

namespace MarsRover.Application.Commands
{
    public class InitializePlateauCommand : ICommand
    {
        public Plateau Plateau { get; private set; }
        private readonly string _edgeOfAreaInput;

        public InitializePlateauCommand(string edgeOfAreaInput)
        {
            Plateau = new Plateau();
            _edgeOfAreaInput = edgeOfAreaInput;
        }
        public void Execute()
        {
            Plateau.Initialize(_edgeOfAreaInput);
        }
    }
}