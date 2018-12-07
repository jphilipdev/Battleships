using System;
using System.Collections.Generic;

namespace Battleship.Core.Exceptions
{
    public class CoordinatesNotStraightLineException : Exception
    {
        public CoordinatesNotStraightLineException(Guid playerId, IEnumerable<int> xSequence, IEnumerable<int> ySequence)
            : base($"Coordinates do not form straight line.  PlayerId='{playerId}', X-Sequence='{string.Join(",", xSequence)}', Y-Sequence='{string.Join(",", ySequence)}'")
        {

        }
    }
}
