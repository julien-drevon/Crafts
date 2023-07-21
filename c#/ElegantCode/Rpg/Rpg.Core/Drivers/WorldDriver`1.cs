using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using Rpg.Core.Dto;
using Rpg.Core.UseCases;

namespace Rpg.Core.Drivers;

public class WorldDriver<TWorld>
{
    private IPresenter<WorldUseCaseResponse, TWorld> _CreateWorldPresenter;

    public WorldDriver(IPresenter<WorldUseCaseResponse, TWorld> createWorldPresenter)
    { _CreateWorldPresenter = createWorldPresenter; }

    public async Task<(TWorld Entity, Error Error)> CreateWorld(
        WorldDriverRequest worldDriverRequest,
        CancellationToken cancellation = default)
    {
        return await DriverAdapter.CreateUseCaseWorflow(
            worldDriverRequest,
            new CreateWorldUseCase(),
            _CreateWorldPresenter,
            cancellation);
    }
}