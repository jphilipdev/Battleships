using Battleship.Contracts;
using System;

namespace Battleship.Core.CommandHandlers
{
    public interface IStartGameCommandHandler
    {
        Guid Execute();
    }

    public class StartGameCommandHandler : IStartGameCommandHandler
    {
        private readonly IEventStore _eventStore;

        public StartGameCommandHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public Guid Execute()
        {
            var gameId = Guid.NewGuid();
            _eventStore.GameStarted(gameId);

            return gameId;
        }
    }
}
