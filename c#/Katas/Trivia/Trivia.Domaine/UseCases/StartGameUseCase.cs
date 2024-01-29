using ElegantCode.Fundamental.Core.UsesCases;
using Trivia.Domaine.Entities;
using Trivia.Domaine.Services;

namespace Trivia.Domaine.UseCases;

public class StartGameUseCase : IUseCaseAsync<StartGameQuery, TriviaGame>
{
    private IGameRepository GameRepository;

    public StartGameUseCase(IGameRepository gameRepository)
    {
        GameRepository = gameRepository;
    }

    public async Task<TriviaGame> Execute(StartGameQuery request, CancellationToken cancelToken = default)
    {
        var game = await GameRepository.Create(
                new TriviaGameBuilder(request.GameId).Build());

        game.Status = TriviaGameStatus.InGame;

        return await Task.FromResult(game);
    }
}