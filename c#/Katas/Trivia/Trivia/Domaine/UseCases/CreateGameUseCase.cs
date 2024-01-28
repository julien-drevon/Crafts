using ElegantCode.Fundamental.Core.UsesCases;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trivia.Domaine.Entities;

namespace Trivia.Domaine.UseCases
{
    public class CreateGameUseCase : IUseCaseAsync<CreateGameQuery, GameResult>
    {
        public Task<GameResult> Execute(CreateGameQuery newGameRequest, CancellationToken cancelToken = default)
        {
            var players = newGameRequest.PlayerNames.Select(x => new Player(x));
            return Task.FromResult(new GameResult(newGameRequest.GameId, players));
        }
    }
}

