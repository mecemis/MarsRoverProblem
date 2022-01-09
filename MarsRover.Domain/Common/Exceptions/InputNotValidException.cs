using System;

namespace MarsRover.Domain.Common.Exceptions
{
    public class InputNotValidException : Exception
    {
        public InputNotValidException(string inputName, string value) 
            : base($"{inputName} was invalid format: {value}")
        {
        }

        public InputNotValidException(string message) : base(message)
        {
            
        }
    }
}