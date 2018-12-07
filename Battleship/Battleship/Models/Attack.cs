using Battleship.Contracts.Models;
using System;

namespace Battleship.Models
{
    public class Attack : IAttack
    {
        public Attack(Guid id, ICoordinate coordinate)
        {
            Id = id;
            Coordinate = coordinate;
        }

        public Guid Id { get; }

        public ICoordinate Coordinate { get; }
    }
}
