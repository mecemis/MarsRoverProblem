using MarsRover.Application.Commands;
using MarsRover.Application.Common.Interfaces;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Rovers;
using MarsRover.Domain.Surface;
using Moq;
using Xunit;

namespace MarsRover.Application.Tests
{
    public class TurnLeftCommandTests
    {
        private readonly Plateau _plateau;
        private readonly Rover _rover;

        public TurnLeftCommandTests()
        {
            _rover = new Rover(1);
            _plateau = new Plateau();
            _plateau.Initialize("5 5");
        }

        [Fact]
        public void Should_Return_North()
        {
            _rover.DeployRover(_plateau, "3 3 E");
            
            TurnLeftCommand turnLeftCommand = new (_rover);
            turnLeftCommand.Execute();

            Assert.Equal(CompassPoint.N, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Return_South()
        {
            _rover.DeployRover(_plateau, "3 3 W");

            TurnLeftCommand turnLeftCommand = new(_rover);
            turnLeftCommand.Execute();

            Assert.Equal(CompassPoint.S, _rover.CurrentPosition.CompassPoint);
        }
    }
}