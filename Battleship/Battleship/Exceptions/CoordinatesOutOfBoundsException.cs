using System;
using System.Collections.Generic;

namespace Battleship.Core.Exceptions
{
    public class CoordinatesOutOfBoundsException : Exception
    {
        public CoordinatesOutOfBoundsException(Guid playerId, IEnumerable<int> xSequence, IEnumerable<int> ySequence)
            : base($"Coordinates are outside of bame bounds.  PlayerId='{playerId}', X-Sequence='{string.Join(",", xSequence)}', Y-Sequence='{string.Join(",", ySequence)}'")
        {

        }
    }
}
