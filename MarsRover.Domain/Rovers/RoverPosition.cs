using MarsRover.Domain.Enums;

namespace MarsRover.Domain.Rovers
{
    public class RoverPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CompassPoint CompassPoint { get; set; }

        public RoverPosition(int x, int y, CompassPoint compassPoint)
        {
            X = x;
            Y = y;
            CompassPoint = compassPoint;
        }
    }
}