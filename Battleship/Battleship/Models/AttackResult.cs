using Battleship.Contracts.Models;
using System;

namespace Battleship.Models
{
    public class AttackResult : IAttackResult
    {
        public AttackResult(Guid attackId, bool hit, Guid? hitBattleshipId = null)
        {
            AttackId = attackId;
            Hit = hit;
            HitBattleshipId = hitBattleshipId;
        }

        public Guid AttackId { get; }

        public bool Hit { get; }

        public Guid? HitBattleshipId { get; }
    }
}
