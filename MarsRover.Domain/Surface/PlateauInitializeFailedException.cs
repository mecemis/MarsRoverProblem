using System;

namespace MarsRover.Domain.Surface
{
    public class PlateauInitializeFailedException : Exception
    {
        public PlateauInitializeFailedException()
        {
            
        }
        public PlateauInitializeFailedException(string message) : base(message)
        {
            
        }
    }
}