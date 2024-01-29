using ElegantCode.Fundamental.Core.UsesCases;
using Trivia.Domaine.Drivers;
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
        return new GameResult(newGameRequest.CorrelationToken, result);
    }
}


public class StartGameUseCase : IUseCaseAsync<StartGameQuery, GameResult>
{
    private IGameRepository GameRepository;

    public StartGameUseCase(IGameRepository gameRepository)
    {
        this.GameRepository = gameRepository;
    }

    public async Task<GameResult> Execute(StartGameQuery request, CancellationToken cancelToken = default)
    {
        var game = await GameRepository.Create(
                new TriviaGameBuilder(request.GameId).Build());

        game.Status = TriviaGameStatus.InGame;

        return await Task.FromResult(new GameResult(request.CorrelationToken, game));
    }
}