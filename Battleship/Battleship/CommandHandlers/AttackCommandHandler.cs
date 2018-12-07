using Battleship.Contracts;
using Battleship.Contracts.Models;
using Battleship.Core.Exceptions;
using Battleship.Models;
using System;
using System.Linq;

namespace Battleship.Core.CommandHandlers
{
    public interface IAttackCommandHandler
    {
        Guid Execute(Guid playerId, ICoordinate coordinate);
    }

    public class AttackCommandHandler : IAttackCommandHandler
    {
        private readonly IStore _store;

        public AttackCommandHandler(IStore store)
        {
            _store = store;
        }

        public Guid Execute(Guid playerId, ICoordinate coordinate)
        {
            var attackId = Guid.NewGuid();

            SaveAttack(attackId, coordinate);

            SaveAttackResult(attackId, playerId, coordinate);

            return attackId;
        }

        private void SaveAttack(Guid attackId, ICoordinate coordinate)
        {
            // TODO: first check if this position has been attacked before
            var attack = new Attack(attackId, coordinate);
            _store.AddAttack(attack);
        }

        private void SaveAttackResult(Guid attackId, Guid playerId, ICoordinate coordinate)
        {
            var usedCoordinate = _store.QueryUsedCoordinate(coordinate);

            if (usedCoordinate == null)
            {
                AddUnsuccessfulAttack(attackId);
            }
            else
            {
                AddSuccessfulAttack(attackId, playerId, usedCoordinate);
            }
        }

        private void AddUnsuccessfulAttack(Guid attackId)
        {
            _store.AddAttackResult(new AttackResult(attackId, false));
        }

        private void AddSuccessfulAttack(Guid attackId, Guid playerId, IUsedCoordinate usedCoordinate)
        {
            IBattleship battleship = GetBattleship(usedCoordinate);

            if (battleship.PlayerId == playerId)
            {
                throw new OwnBattleshipAttackedException(playerId, battleship.Id);
            }

            _store.AddAttackResult(new AttackResult(attackId, true, battleship.Id));

            // TODO: need a way to store that a battleship has been attacked and for which coordinate
            // change AttackResult to include a BattleShipId, then query for all the AttackResults for that BattleshipId,
            // if the battleship has no coordinates which haven't been hit then add BattleshipSunk to store

            var battleshipAttacks = _store.QueryAttackResults(battleship.Id);

            foreach(var coordinate in battleship.Coordinates)
            {
                if(battleshipAttacks.Any(p => p.AttackId))
            }
        }

        private IBattleship GetBattleship(IUsedCoordinate usedCoordinate)
        {
            var battleship = _store.QueryBattleship(usedCoordinate.BattleshipId);
            if (battleship == null)
            {
                throw new BattleshipNotFoundException(usedCoordinate.BattleshipId);
            }

            return battleship;
        }
    }
}
