using ElegantCode.Fundamental.Core.UsesCases;
using Trivia.Domaine.Drivers;
using Trivia.Domaine.Entities;
using Trivia.Domaine.Services;

namespace Trivia.Domaine.UseCases;

public class CreateGameUseCase : IUseCaseAsync<CreateGameQuery, TriviaGame>
{
    public CreateGameUseCase(IGameRepository gameRepository)
    { GameRepository = gameRepository; }

    public IGameRepository GameRepository { get; }

    public async Task<TriviaGame> Execute(CreateGameQuery newGameRequest, CancellationToken cancelToken = default)
    {
        return await GameRepository.Create(
            new TriviaGameBuilder(newGameRequest.CorrelationToken, newGameRequest.GameId)
            .AddPlayers(newGameRequest.PlayerNames)
            .AddPlateau(newGameRequest.Plateau)
            .Build()); ;
    }
}
