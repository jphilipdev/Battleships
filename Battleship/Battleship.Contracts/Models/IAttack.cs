using System;

namespace Battleship.Contracts.Models
{
    public interface IAttack
    {
        Guid Id { get; }

        ICoordinate Coordinate { get; }
    }
}