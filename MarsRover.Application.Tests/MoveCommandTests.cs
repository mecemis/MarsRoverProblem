using MarsRover.Application.Commands;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Rovers;
using MarsRover.Domain.Surface;
using Xunit;

namespace MarsRover.Application.Tests
{
    public class MoveCommandTests
    {
        private readonly Plateau _plateau;
        private readonly Rover _rover;

        public MoveCommandTests()
        {
            _rover = new Rover(1);
            _plateau = new Plateau();
            _plateau.Initialize("5 5");
        }

        [Fact]
        public void Should_Rover_Go_Forward_By_X()
        {
            _rover.DeployRover(_plateau, "3 3 E");
            MoveCommand command = new(_rover);
            command.Execute();

            Assert.Equal(4, _rover.CurrentPosition.X);
            Assert.Equal(3, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.E, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Rover_Go_Back_By_X()
        {
            _rover.DeployRover(_plateau, "3 3 W");
            MoveCommand command = new(_rover);
            command.Execute();

            Assert.Equal(2, _rover.CurrentPosition.X);
            Assert.Equal(3, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.W, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Not_Rover_Go_Forward_By_X()
        {
            _rover.DeployRover(_plateau, "5 3 E");
            MoveCommand command = new(_rover);
            command.Execute();

            Assert.Equal(5, _rover.CurrentPosition.X);
            Assert.Equal(3, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.E, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Rover_Go_Forward_By_Y()
        {
            _rover.DeployRover(_plateau, "3 3 N");
            MoveCommand command = new(_rover);
            command.Execute();

            Assert.Equal(3, _rover.CurrentPosition.X);
            Assert.Equal(4, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.N, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Rover_Go_Back_By_Y()
        {
            _rover.DeployRover(_plateau, "3 3 S");
            MoveCommand command = new(_rover);
            command.Execute();

            Assert.Equal(3, _rover.CurrentPosition.X);
            Assert.Equal(2, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.S, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Not_Rover_Go_Forward_By_Y()
        {
            _rover.DeployRover(_plateau, "3 5 N");
            MoveCommand command = new(_rover);
            command.Execute();

            Assert.Equal(3, _rover.CurrentPosition.X);
            Assert.Equal(5, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.N, _rover.CurrentPosition.CompassPoint);
        }
    }
}