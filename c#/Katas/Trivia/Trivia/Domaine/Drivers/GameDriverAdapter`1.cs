using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using System.Threading;
using System.Threading.Tasks;
using Trivia.Domaine.Services;
using Trivia.Domaine.UseCases;

namespace Trivia.Domaine.Drivers;

public class GameDriverAdapter<TGameResult>
{
    public GameDriverAdapter(IPresenter<GameResult, TGameResult> gamePresenter, IGameRepository gameRepository)
    {
        GamePresenter = gamePresenter;
        GameRepository = gameRepository;
    }

    public IPresenter<GameResult, TGameResult> GamePresenter { get; private set; }

    public IGameRepository GameRepository { get; private set; }

    public async Task<(TGameResult GameResult, Error Error)> CreateNew(NewGameRequest newGameRequest, CancellationToken cancellation = default)
    {
        return await DriverAdapter.CreateUseCaseWorkflow(newGameRequest, new CreateGameUseCase(GameRepository), GamePresenter, cancellation);
    }
}