using ElegantCode.Fundamental.Core.UsesCases;
using Trivia.Domaine.Entities;
using Trivia.Domaine.Services;

namespace Trivia.Domaine.UseCases;

public class CreateGameUseCase : IUseCaseAsync<CreateGameQuery, GameResult>
{
    public CreateGameUseCase(IGameRepository gameRepository)
    { GameRepository = gameRepository; }

    public IGameRepository GameRepository { get; }

    public async Task<GameResult> Execute(CreateGameQuery newGameRequest, CancellationToken cancelToken = default)
    {
        var result = await GameRepository.Create(
            new TriviaGameBuilder(newGameRequest.GameId).AddPlayers(newGameRequest.PlayerNames).Build());
        return new GameResult(result.Id, result.Players);
    }
}