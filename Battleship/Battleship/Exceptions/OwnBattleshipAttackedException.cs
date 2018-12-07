using System;

namespace Battleship.Core.Exceptions
{
    public class OwnBattleshipAttackedException : Exception
    {
        public OwnBattleshipAttackedException(Guid playerId, Guid battleshipId)
            : base($"Cannot attack own battleship.  PlayerId='{playerId}', BattleshipId='{battleshipId}'")
        {

        }
    }
}
