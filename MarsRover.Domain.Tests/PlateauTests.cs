using MarsRover.Domain.Common.Exceptions;
using MarsRover.Domain.Surface;
using Xunit;

namespace MarsRover.Domain.Tests
{
    public class PlateauTests
    {
        private readonly Plateau _plateau;

        public PlateauTests()
        {
            _plateau = new Plateau();
        }

        [Fact]
        public void Should_Initialize_Plateau()
        {
            _plateau.Initialize("4 5");

            Assert.Equal(4, _plateau.Width);
            Assert.Equal(5, _plateau.Height);
        }

        [Fact]
        public void Should_Throw_Input_Not_Valid_Exception()
        {
            Assert.Throws<InputNotValidException>(() => _plateau.Initialize("5"));
        }

        [Fact]
        public void Should_Throw_Input_Not_Valid_Exception2()
        {
            Assert.Throws<InputNotValidException>(() => _plateau.Initialize(string.Empty));
        }

        [Fact]
        public void Should_Throw_Plateau_Initialize_Failed_Exception()
        {
            Assert.Throws<PlateauInitializeFailedException>(() => _plateau.Initialize("-1 5"));
        }
    }
}