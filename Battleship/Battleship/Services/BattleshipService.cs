using Battleship.Contracts;
using Battleship.Contracts.Models;
using Battleship.Core.CommandHandlers;
using System;
using System.Collections.Generic;

namespace Battleship.Core.Services
{
    public class BattleshipService
    {
        private readonly IStartGameCommandHandler _startGameCommandHandler;
        private readonly IAddBattleshipCommandHandler _addBattleshipCommandHandler;
        private readonly IAttackCommandHandler _attackCommandHandler;

        public BattleshipService(IStartGameCommandHandler startGameCommandHandler, IAddBattleshipCommandHandler addBattleshipCommandHandler, IAttackCommandHandler attackCommandHandler)
        {
            _startGameCommandHandler = startGameCommandHandler;
            _addBattleshipCommandHandler = addBattleshipCommandHandler;
            _attackCommandHandler = attackCommandHandler;
        }

        public Guid StartGame()
        {
            return _startGameCommandHandler.Execute();
        }

        public Guid AddBattleship(Guid playerId, IReadOnlyList<ICoordinate> coordinates)
        {
            return _addBattleshipCommandHandler.Execute(playerId, coordinates);
        }

        public Guid Attack(Guid playerId, ICoordinate coordinate)
        {
            return _attackCommandHandler.Execute(playerId, coordinate);
        }
    }
}
