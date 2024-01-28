using ElegantCode.Fundamental.Core.UsesCases;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trivia.Domaine.Entities;
using Trivia.Domaine.Services;

namespace Trivia.Domaine.UseCases;

public class CreateGameUseCase : IUseCaseAsync<CreateGameQuery, GameResult>
{
    public CreateGameUseCase(IGameRepository gameRepository)
    {
        GameRepository = gameRepository;
    }

    public IGameRepository GameRepository { get; }

    public async Task<GameResult> Execute(CreateGameQuery newGameRequest, CancellationToken cancelToken = default)
    {
        return await GameRepository.Create(newGameRequest);
    }
}
