using Battleship.Contracts.Models;
using System;
using System.Collections.Generic;

namespace Battleship.Contracts
{
    public interface IReadModelStore
    {
        void AddBattleship(IBattleship battleship);

        void AddUsedCoordinate(IUsedCoordinate usedCoordinate);

        void AddAttack(IAttack attack);

        void AddAttackResult(IAttackResult attackResult);

        IBattleship QueryBattleship(Guid battleshipId);

        IUsedCoordinate QueryUsedCoordinate(ICoordinate coordinate);

        IAttackResult QueryAttackResult(Guid attackId);

        IReadOnlyList<IAttackResult> QueryAttackResults(Guid battleshipId);
    }
}
