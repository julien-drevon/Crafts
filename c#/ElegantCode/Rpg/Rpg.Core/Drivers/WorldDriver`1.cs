using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using Rpg.Core.Dto;
using Rpg.Core.Providers;
using Rpg.Core.UseCases;

namespace Rpg.Core.Drivers;

public class WorldDriver<TWorld>
{
    private readonly IPresenter<WorldUseCaseResponse, TWorld> _WorldPresenter;
    private readonly IProvideTheWorld _WorldProvider;
    private readonly ICreateItems _ItemsFactory;

    public WorldDriver(
        IPresenter<WorldUseCaseResponse, TWorld> createWorldPresenter,
        IProvideTheWorld worldProvider,
        ICreateItems itemsFactory)
    {
        _WorldPresenter = createWorldPresenter;
        _WorldProvider = worldProvider;
        _ItemsFactory = itemsFactory;
    }

    public async Task<(TWorld Entity, Error Error)> AddItems(
        AddItemsDriverRequest worldDriverRequest,
        CancellationToken cancellation = default)
    {
        return await DriverAdapter.CreateUseCaseWorflow(
            aRequestForDriverAdapter: worldDriverRequest,
            myUseCase: new AddItemsWorldUseCase(_WorldProvider, _ItemsFactory),
            presenter: _WorldPresenter,
            cancellation: cancellation);
    }

    public async Task<(TWorld Entity, Error Error)> CreateWorld(
        CreateWorldDriverRequest worldDriverRequest,
        CancellationToken cancellation = default)
    {
        return await DriverAdapter.CreateUseCaseWorflow(
            aRequestForDriverAdapter: worldDriverRequest,
            myUseCase: new CreateWorldUseCase(_WorldProvider),
            presenter: _WorldPresenter,
            cancellation: cancellation);
        ;
    }
}