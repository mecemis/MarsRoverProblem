using System;

namespace MarsRover.Domain.Rovers
{
    public class RoverDeployFailedException : Exception
    {
        public RoverDeployFailedException()
        {
        }

        public RoverDeployFailedException(string message) : base(message)
        {
            
        }
    }
}