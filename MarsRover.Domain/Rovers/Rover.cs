using System;
using MarsRover.Domain.Common.Exceptions;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Surface;

namespace MarsRover.Domain.Rovers
{
    public class Rover
    {
        public int Id { get; }
        public Plateau Plateau { get; private set; }
        public RoverPosition CurrentPosition { get; private set; }

        public Rover(int id)
        {
            Id = id;
        }

        public void DeployRover(Plateau plateau, string startingPositionInput)
        {
            string[] startingPosition = startingPositionInput?.Trim().Split(' ');

            ValidateStartingPositionLength(startingPosition);

            int xCoordinate = int.Parse(startingPosition[0]);
            int yCoordinate = int.Parse(startingPosition[1]);

            CheckIfCoordinatesAreValid(xCoordinate, yCoordinate);

            CompassPoint point = Enum.Parse<CompassPoint>(startingPosition[2]);

            CurrentPosition = new RoverPosition(xCoordinate, yCoordinate, point);

            Plateau = plateau;
        }


        public string GetCurrentPosition()
            => $"{CurrentPosition.X} {CurrentPosition.Y} {CurrentPosition.CompassPoint}";


        public void Move()
        {
            int tempX = CurrentPosition.X;
            int tempY = CurrentPosition.Y;

            switch (CurrentPosition.CompassPoint)
            {
                case CompassPoint.N:
                    if (IsYCoordinateValid(++tempY))
                        CurrentPosition.Y++;
                    break;
                case CompassPoint.S:
                    if (IsYCoordinateValid(--tempY))
                        CurrentPosition.Y--;
                    break;
                case CompassPoint.E:
                    if (IsXCoordinateValid(++tempX))
                        CurrentPosition.X++;
                    break;
                case CompassPoint.W:
                    if (IsXCoordinateValid(--tempX))
                        CurrentPosition.X--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void TurnLeft()
        {
            CurrentPosition.CompassPoint = CurrentPosition.CompassPoint is not CompassPoint.W ? --CurrentPosition.CompassPoint : CompassPoint.S;
        }

        public void TurnRight()
        {
            CurrentPosition.CompassPoint = CurrentPosition.CompassPoint is not CompassPoint.S ? ++CurrentPosition.CompassPoint : CompassPoint.W;
        }

        #region Validations

        private void CheckIfCoordinatesAreValid(int xCoordinate, int yCoordinate)
        {
            if (xCoordinate < 0 || yCoordinate < 0)
                throw new RoverDeployFailedException($"Deploy failed with these coordinates: {xCoordinate},{yCoordinate}");
        }

        private void ValidateStartingPositionLength(string[] startingPosition)
        {
            if (startingPosition.Length is not 3)
                throw new InputNotValidException(nameof(startingPosition), string.Join(' ', startingPosition));
        }

        private bool IsXCoordinateValid(int xCoordinate)
            => (xCoordinate <= Plateau.Width && xCoordinate >= 0);


        private bool IsYCoordinateValid(int yCoordinate)
            => (yCoordinate <= Plateau.Height && yCoordinate >= 0);


        #endregion
    }
}