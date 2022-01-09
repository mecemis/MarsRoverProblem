using System;

namespace MarsRover.Domain.Rovers
{
    public class RoverOutOfBoundsException : Exception
    {
        public RoverOutOfBoundsException()
        {
            
        }
        public RoverOutOfBoundsException(int xCoordinate, int yCoordinate)
            : base($"Vehicle went out of bounds ({xCoordinate},{yCoordinate})")
        {

        }
    }
}