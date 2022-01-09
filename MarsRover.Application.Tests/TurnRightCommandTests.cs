using MarsRover.Application.Commands;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Rovers;
using MarsRover.Domain.Surface;
using Xunit;

namespace MarsRover.Application.Tests
{
    public class TurnRightCommandTests
    {
        private readonly Plateau _plateau;
        private readonly Rover _rover;

        public TurnRightCommandTests()
        {
            _rover = new Rover(1);
            _plateau = new Plateau();
            _plateau.Initialize("5 5");
        }


        [Fact]
        public void Should_Return_North()
        {
            _rover.DeployRover(_plateau, "3 3 W");

            TurnRightCommand turnRightCommand = new(_rover);
            turnRightCommand.Execute();

            Assert.Equal(CompassPoint.N, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Return_West()
        {
            _rover.DeployRover(_plateau, "3 3 S");

            TurnRightCommand turnRightCommand = new(_rover);
            turnRightCommand.Execute();

            Assert.Equal(CompassPoint.W, _rover.CurrentPosition.CompassPoint);
        }
    }
}