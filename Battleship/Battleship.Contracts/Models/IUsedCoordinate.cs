using System;

namespace Battleship.Contracts.Models
{
    public interface IUsedCoordinate
    {
        Guid BattleshipId { get; }

        ICoordinate Coordinate { get; }
    }
}