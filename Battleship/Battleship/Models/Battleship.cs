using Battleship.Contracts.Models;
using System;
using System.Collections.Generic;

namespace Battleship.Core.Models
{
    public class Battleship : IBattleship
    {
        public Battleship(Guid id, Guid playerId, IReadOnlyList<ICoordinate> coordinates)
        {
            Id = Id;
            PlayerId = playerId;
            Coordinates = coordinates;
        }

        public Guid Id { get; }

        public Guid PlayerId { get; }

        public IReadOnlyList<ICoordinate> Coordinates { get; }
    }
}