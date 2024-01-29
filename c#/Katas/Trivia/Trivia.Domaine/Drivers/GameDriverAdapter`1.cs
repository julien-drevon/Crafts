using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using ElegantCode.Fundamental.Core.UsesCases;
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

    public async Task<(TGameResult GameResult, Error Error)> Create(NewGameRequest newGameRequest, CancellationToken cancellationToken = default)
    {
        return await DriverAdapter.CreateUseCaseWorkflow(newGameRequest, new CreateGameUseCase(GameRepository), GamePresenter, cancellationToken);
    }

    public async Task<(TGameResult GameResult, Error Error)> Start(StartGameRequest startRequest, CancellationToken cancellationToken=default)
    {
        return await DriverAdapter.CreateUseCaseWorkflow(startRequest, new StartGameUseCase(GameRepository), GamePresenter, cancellationToken);
    }
}

