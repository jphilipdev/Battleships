using Battleship.Contracts;
using Battleship.Contracts.Models;
using System;

namespace Battleship.Adapters.InMemory
{
    public class InMemoryStore : ICommandStore
    {
        public void AddAttack(IAttack attack)
        {
            throw new NotImplementedException();
        }

        public void AddAttackResult(IAttackResult attackResult)
        {
            throw new NotImplementedException();
        }

        public void AddBattleship(IBattleship battleship)
        {
            throw new NotImplementedException();
        }

        public void AddUsedCoordinate(IUsedCoordinate usedCoordinate)
        {
            throw new NotImplementedException();
        }

        public IAttackResult QueryAttackResult(Guid attackId)
        {
            throw new NotImplementedException();
        }

        public IBattleship QueryBattleship(Guid battleshipId)
        {
            throw new NotImplementedException();
        }

        public IUsedCoordinate QueryUsedCoordinate(ICoordinate coordinate)
        {
            throw new NotImplementedException();
        }
    }
}
