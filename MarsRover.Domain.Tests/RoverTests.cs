using System;
using MarsRover.Domain.Common.Exceptions;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Rovers;
using MarsRover.Domain.Surface;
using Xunit;

namespace MarsRover.Domain.Tests
{
    public class RoverTests
    {
        private readonly Plateau _plateau;
        private readonly Rover _rover;

        public RoverTests()
        {
            _plateau = new Plateau();
            _plateau.Initialize("5 5");
            _rover = new Rover(1);
        }

        #region DeployRover

        [Fact]
        public void Should_Deploy_Rover()
        {
            _rover.DeployRover(_plateau, "3 3 N");


            Assert.Equal(1, _rover.Id);
            Assert.Equal(3, _rover.CurrentPosition.X);
            Assert.Equal(3, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.N, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Throw_Input_Not_Valid_Exception()
        {
            Assert.Throws<InputNotValidException>(() => _rover.DeployRover(_plateau, "3 N"));
        }

        [Fact]
        public void Should_Throw_Format_Exception()
        {
            Assert.Throws<FormatException>(() => _rover.DeployRover(_plateau, "a 3 N"));
        }

        [Fact]
        public void Should_Throw_Deploy_Failed_Exception()
        {
            Assert.Throws<RoverDeployFailedException>(() => _rover.DeployRover(_plateau, "-3 3 N"));
        }

        #endregion

        #region TurnLeft

        [Fact]
        public void Should_Turn_Left_Return_North()
        {
            _rover.DeployRover(_plateau, "3 3 E");

            _rover.TurnLeft();

            Assert.Equal(CompassPoint.N, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Turn_Left_Return_South()
        {
            _rover.DeployRover(_plateau, "3 3 W");

            _rover.TurnLeft();

            Assert.Equal(CompassPoint.S, _rover.CurrentPosition.CompassPoint);
        }

        #endregion

        #region TurnRight

        [Fact]
        public void Should_Turn_Right_Return_North()
        {
            _rover.DeployRover(_plateau, "3 3 W");

            _rover.TurnRight();

            Assert.Equal(CompassPoint.N, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Turn_Right_Return_West()
        {
            _rover.DeployRover(_plateau, "3 3 S");

            _rover.TurnRight();

            Assert.Equal(CompassPoint.W, _rover.CurrentPosition.CompassPoint);
        }

        #endregion

        #region Move

        [Fact]
        public void Should_Rover_Go_Forward_By_X()
        {
            _rover.DeployRover(_plateau, "3 3 E");
            
            _rover.Move();

            Assert.Equal(4, _rover.CurrentPosition.X);
            Assert.Equal(3, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.E, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Rover_Go_Back_By_X()
        {
            _rover.DeployRover(_plateau, "3 3 W");

            _rover.Move();

            Assert.Equal(2, _rover.CurrentPosition.X);
            Assert.Equal(3, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.W, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Not_Rover_Go_Forward_By_X()
        {
            _rover.DeployRover(_plateau, "5 3 E");

            _rover.Move();

            Assert.Equal(5, _rover.CurrentPosition.X);
            Assert.Equal(3, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.E, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Rover_Go_Forward_By_Y()
        {
            _rover.DeployRover(_plateau, "3 3 N");

            _rover.Move();

            Assert.Equal(3, _rover.CurrentPosition.X);
            Assert.Equal(4, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.N, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Rover_Go_Back_By_Y()
        {
            _rover.DeployRover(_plateau, "3 3 S");

            _rover.Move();

            Assert.Equal(3, _rover.CurrentPosition.X);
            Assert.Equal(2, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.S, _rover.CurrentPosition.CompassPoint);
        }

        [Fact]
        public void Should_Not_Rover_Go_Forward_By_Y()
        {
            _rover.DeployRover(_plateau, "3 5 N");

            _rover.Move();

            Assert.Equal(3, _rover.CurrentPosition.X);
            Assert.Equal(5, _rover.CurrentPosition.Y);
            Assert.Equal(CompassPoint.N, _rover.CurrentPosition.CompassPoint);
        }

        #endregion
    }
}