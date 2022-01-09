using System;
using MarsRover.Application.Commands;
using MarsRover.Domain.Common.Exceptions;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Rovers;
using MarsRover.Domain.Surface;
using Xunit;

namespace MarsRover.Application.Tests
{
    public class DeployRoverCommandTests
    {
        private readonly Plateau _plateau;

        public DeployRoverCommandTests()
        {
            _plateau = new Plateau();
            _plateau.Initialize("5 5");
        }

        [Fact]
        public void Should_Deploy_Rover()
        {
            DeployRoverCommand command = new(_plateau, "3 3 N", 1);

            command.Execute();

            Assert.Equal(1, command.Rover.Id);
            Assert.Equal(3, command.Rover.CurrentPosition.X);
            Assert.Equal(3, command.Rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.N, command.Rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Throw_Input_Not_Valid_Exception()
        {
            DeployRoverCommand command = new(_plateau, "3 N", 1);

            Assert.Throws<InputNotValidException>(() => command.Execute());
        }

        [Fact]
        public void Should_Throw_Format_Exception()
        {
            DeployRoverCommand command = new(_plateau, "a 3 N", 1);

            Assert.Throws<FormatException>(() => command.Execute());
        }

        [Fact]
        public void Should_Throw_Deploy_Failed_Exception()
        {
            DeployRoverCommand command = new(_plateau, "-3 3 N", 1);
            
            Assert.Throws<RoverDeployFailedException>(()=>command.Execute());
        }
    }
}