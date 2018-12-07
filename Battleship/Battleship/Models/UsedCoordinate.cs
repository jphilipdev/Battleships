using Battleship.Contracts.Models;
using System;

namespace Battleship.Core.Models
{
    public class UsedCoordinate : IUsedCoordinate
    {
        public UsedCoordinate(Guid battleshipId, ICoordinate coordinate)
        {
            BattleshipId = battleshipId;
            Coordinate = coordinate;
        }

        public Guid BattleshipId { get; }

        public ICoordinate Coordinate { get; }
    }
}
