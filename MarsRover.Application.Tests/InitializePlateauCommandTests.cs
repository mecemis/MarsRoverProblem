using MarsRover.Application.Commands;
using MarsRover.Domain.Common.Exceptions;
using MarsRover.Domain.Surface;
using Xunit;

namespace MarsRover.Application.Tests
{
    public class InitializePlateauCommandTests
    {
        [Fact]
        public void Should_Initialize_Plateau()
        {
            InitializePlateauCommand command = new("4 5");
            command.Execute();

            Assert.Equal(4, command.Plateau.Width);
            Assert.Equal(5, command.Plateau.Height);
        }

        [Fact]
        public void Should_Throw_Input_Not_Valid_Exception()
        {
            InitializePlateauCommand command = new("5");

            Assert.Throws<InputNotValidException>(() => command.Execute());
        }

        [Fact]
        public void Should_Throw_Input_Not_Valid_Exception2()
        {
            InitializePlateauCommand command = new(string.Empty);

            Assert.Throws<InputNotValidException>(() => command.Execute());
        }

        [Fact]
        public void Should_Throw_Plateau_Initialize_Failed_Exception()
        {
            InitializePlateauCommand command = new("-1 5");

            Assert.Throws<PlateauInitializeFailedException>(() => command.Execute());
        }
    }
}