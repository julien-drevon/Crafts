using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using ElegantCode.Fundamental.Core.UsesCases;
using Rpg.Core.Domain;
using Rpg.Core.Dto;
using Rpg.Core.UseCases;

namespace Rpg.Core.Drivers;

public class WorldDriver<TWorld>
{
    private readonly IProvideTheWorld _WorldProvider;
    private readonly IPresenter<WorldUseCaseResponse, TWorld> _WorldPresenter;

    public WorldDriver(IPresenter<WorldUseCaseResponse, TWorld> createWorldPresenter, IProvideTheWorld worldProvider)
    {
        _WorldPresenter = createWorldPresenter;
        _WorldProvider = worldProvider;
    }

    public async Task<(TWorld Entity, Error Error)> AddItems(WorldDriverRequest worldDriverRequest, CancellationToken cancellation = default)
    {

        _WorldPresenter.PresentData(new WorldUseCaseResponse(worldDriverRequest.Id, worldDriverRequest.CorrelationToken) { Items = new Sprite[] { new(10, 10), new(0, 0) } });
        return await _WorldPresenter.View();
    }

    public async Task<(TWorld Entity, Error Error)> CreateWorld(
        WorldDriverRequest worldDriverRequest,
        CancellationToken cancellation = default)
    {
        return await DriverAdapter.CreateUseCaseWorflow(
            worldDriverRequest,
            new CreateWorldUseCase(_WorldProvider),
            _WorldPresenter,
            cancellation);
    }
}

//public class AddItemsWorldDriverRequest
//{
//    public 
//}

//public class AddIemsInWorldUseCase : IUseCaseAsync<object, object>
//{
//}