using Battleship.Contracts;
using Battleship.Contracts.Models;
using Battleship.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Core.CommandHandlers
{
    public interface IAddBattleshipCommandHandler
    {
        Guid Execute(Guid playerId, IReadOnlyList<ICoordinate> coordinates);
    }

    public class AddBattleshipCommandHandler : IAddBattleshipCommandHandler
    {
        private readonly IEventStore _eventStore;

        public AddBattleshipCommandHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public Guid Execute(Guid playerId, IReadOnlyList<ICoordinate> coordinates)
        {
            var battleshipId = Guid.NewGuid();

            ValidateCoordinates(playerId, coordinates);

            EmitBattleshipAdded(playerId, coordinates, battleshipId);

            return battleshipId;
        }

        private void ValidateCoordinates(Guid playerId, IReadOnlyList<ICoordinate> coordinates)
        {
            ValidateCoordinatesProvided(playerId, coordinates);

            var xSequence = coordinates.Select(p => p.X).ToList();
            var ySequence = coordinates.Select(p => p.Y).ToList();

            ValidateCoordinatesWithinBounds(playerId, coordinates, xSequence, ySequence);
            ValidateCoordinatesInStraightLine(playerId, xSequence, ySequence);
        }        

        private void ValidateCoordinatesProvided(Guid playerId, IReadOnlyList<ICoordinate> coordinates)
        {
            if (!coordinates.Any())
            {
                throw new CoordinatesNotProvidedException(playerId);
            }
        }        

        private void ValidateCoordinatesWithinBounds(Guid playerId, IReadOnlyList<ICoordinate> coordinates, List<int> xSequence, List<int> ySequence)
        {
            if (coordinates.Any(p => p.X < 1) || coordinates.Any(p => p.Y < 1) || coordinates.Any(p => p.X > 10) || coordinates.Any(p => p.Y > 10))
            {
                throw new CoordinatesOutOfBoundsException(playerId, xSequence, ySequence);
            }
        }

        private void ValidateCoordinatesInStraightLine(Guid playerId, List<int> xSequence, List<int> ySequence)
        {
            if (new HashSet<int>(xSequence).Count > 1 && new HashSet<int>(ySequence).Count > 1)
            {
                throw new CoordinatesNotStraightLineException(playerId, xSequence, ySequence);
            }
        }

        private void EmitBattleshipAdded(Guid playerId, IReadOnlyList<ICoordinate> coordinates, Guid battleshipId)
        {
            var battleship = new Models.Battleship(battleshipId, playerId, coordinates);
            _eventStore.BattleshipAdded(battleship);
        }
    }
}
