using System;

namespace Battleship.Core.Exceptions
{
    public class BattleshipNotFoundException : Exception
    {
        public BattleshipNotFoundException(Guid battleshipId)
            : base($"Could not find Battleship.  BattleshipId='{battleshipId}'")
        {

        }
    }
}
