using System;

namespace Battleship.Contracts.Models
{
    public interface IAttackResult
    {
        Guid AttackId { get; }

        bool Hit { get; }
    }
}
