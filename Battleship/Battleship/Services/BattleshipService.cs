using Battleship.Contracts;
using Battleship.Contracts.Models;
using Battleship.Core.CommandHandlers;
using System;

namespace Battleship.Core.Services
{
    public class BattleshipService
    {
        private readonly IStore _store;
        private readonly IAttackCommandHandler _attackCommandHandler;

        public BattleshipService(IStore store, IAttackCommandHandler attackCommandHandler)
        {
            _store = store;
            _attackCommandHandler = attackCommandHandler;
        }

        public Guid Attack(Guid playerId, ICoordinate coordinate)
        {
            return _attackCommandHandler.Execute(playerId, coordinate);
        }
    }
}
