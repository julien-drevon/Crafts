using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using Trivia.Domaine.Entities;
using Trivia.Domaine.Services;
using Trivia.Domaine.UseCases;

namespace Trivia.Domaine.Drivers;

public class GameDriverAdapter<TGameResult>
{
    public GameDriverAdapter(IPresenter<TriviaGame, TGameResult> gamePresenter, IGameRepository gameRepository)
    {
        GamePresenter = gamePresenter;
        GameRepository = gameRepository;
    }

    public IPresenter<TriviaGame, TGameResult> GamePresenter { get; private set; }

    public IGameRepository GameRepository { get; private set; }

    public async Task<(TGameResult TriviaGame, Error Error)> Create(NewGameRequest newGameRequest, CancellationToken cancellationToken = default)
    {
        return await DriverAdapter.CreateUseCaseWorkflow(newGameRequest, new CreateGameUseCase(GameRepository), GamePresenter, cancellationToken);
    }

    public async Task<(TGameResult GameResult, Error Error)> LancerDes(StartGameRequest startRequest, CancellationToken cancellationToken = default)
    {
        return await DriverAdapter.CreateUseCaseWorkflow(startRequest, new StartGameUseCase(GameRepository), GamePresenter, cancellationToken);
    }
}