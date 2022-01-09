using System.Linq;
using MarsRover.Domain.Common.Exceptions;

namespace MarsRover.Domain.Surface
{
    public class Plateau
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public void Initialize(string edgeOfAreaInput)
        {
            CheckIfEdgeOfAreaInputExist(edgeOfAreaInput);

            string[] coordinatesString = edgeOfAreaInput?.Trim().Split(' ');//.Select(int.Parse).ToArray();

            ValidatePlateauCoordinatesLength(coordinatesString);

            int[] coordinates = coordinatesString.Select(int.Parse).ToArray();

            CheckIfCoordinatesAreValid(coordinates);

            this.Width = coordinates[0];
            this.Height = coordinates[1];
        }

        #region Validations

        private void CheckIfCoordinatesAreValid(int[] coordinates)
        {
            if (coordinates.Any(x => x < 0) || coordinates.All(x => x == 0))
                throw new PlateauInitializeFailedException(
                    $"Given coordinates are not valid: {string.Join(' ', coordinates)}");
        }

        private void CheckIfEdgeOfAreaInputExist(string edgeOfAreaInput)
        {
            if (string.IsNullOrEmpty(edgeOfAreaInput))
                throw new InputNotValidException(nameof(edgeOfAreaInput), edgeOfAreaInput);
        }

        private void ValidatePlateauCoordinatesLength(string[] coordinatesString)
        {
            if (coordinatesString.Length is not 2)
                throw new InputNotValidException(nameof(coordinatesString), string.Join(' ', coordinatesString));
        }

        #endregion

    }
}