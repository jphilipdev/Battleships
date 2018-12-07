using Battleship.Contracts.Models;
using System;

namespace Battleship.Models
{
    public class Coordinate : ICoordinate
    {
        public Coordinate(int x, int y)
        {
            ValidateCoordinate(x, nameof(x));
            ValidateCoordinate(y, nameof(y));

            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        private void ValidateCoordinate(int value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentException($"Coordinate index out of bounds: '{value}'", name);
            }
        }
    }
}
