using ElegantCode.Fundamental.Core.UsesCases;
using Rpg.Core.Dto;
using Rpg.Core.Providers;
using Rpg.Core.UseCases.Query;

namespace Rpg.Core.UseCases;

public class CreateWorldUseCase : IUseCaseAsync<CreateWorldUseCaseQuery, WorldUseCaseResponse>
{
    private readonly IProvideTheWorld _WorldProvider;

    public CreateWorldUseCase(IProvideTheWorld worldProvider)
    {
        this._WorldProvider = worldProvider;
    }

    public async Task<WorldUseCaseResponse> Execute(CreateWorldUseCaseQuery request, CancellationToken cancelToken = default)
    {
        return new WorldUseCaseResponse(await _WorldProvider.CreateWorld(request));
    }
}