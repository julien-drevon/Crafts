using ElegantCode.Fundamental.Core.UsesCases;
using Trivia.Domaine.Entities;
using Trivia.Domaine.Services;

namespace Trivia.Domaine.UseCases;

public class RepondreGameUseCase : IUseCaseAsync<RepondreGameQuery, TriviaGame>
{
    private IGameRepository GameRepository;

    public RepondreGameUseCase(IGameRepository gameRepository)
    {
        GameRepository = gameRepository;
    }

    public async Task<TriviaGame> Execute(RepondreGameQuery request, CancellationToken cancelToken = default)
    {
        var game = await GameRepository.Get(request.CorrelationToken, request.GameId, cancelToken);

        game.Repondre(request.Reponse);

        return await GameRepository.Save(game, cancelToken);
    }
}