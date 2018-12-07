using System;
using System.Collections.Generic;

namespace Battleship.Contracts.Models
{
    public interface IBattleship
    {
        Guid Id { get; }

        Guid PlayerId { get; }

        IReadOnlyList<ICoordinate> Coordinates { get; }
    }
}