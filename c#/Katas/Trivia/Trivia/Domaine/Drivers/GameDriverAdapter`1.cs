using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using System.Threading;
using System.Threading.Tasks;
using Trivia.Domaine.UseCases;

namespace Trivia.Domaine.Drivers
{
    public class GameDriverAdapter<TGameResult>
    {
        private IPresenter<GameResult, TGameResult> GamePresenter;

        public GameDriverAdapter(IPresenter<GameResult, TGameResult> gamePresenter)
        {
            GamePresenter = gamePresenter;
        }

        public async Task<(TGameResult GameResult, Error Error)> CreateNew(NewGameRequest newGameRequest, CancellationToken cancellation = default)
        {
            return await DriverAdapter.CreateUseCaseWorkflow(newGameRequest, new CreateGameUseCase(), GamePresenter, cancellation);
        }
    }
}