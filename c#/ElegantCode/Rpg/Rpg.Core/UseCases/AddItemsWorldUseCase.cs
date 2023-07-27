using ElegantCode.Fundamental.Core.UsesCases;
using Rpg.Core.Dto;
using Rpg.Core.Providers;

namespace Rpg.Core.UseCases
{
    public class AddItemsWorldUseCase : IUseCaseAsync<AddItemsWorldUseCaseQuery, WorldUseCaseResponse>
    {
        private readonly IProvideTheWorld _WorldProvider;

        public AddItemsWorldUseCase(IProvideTheWorld worldProvider)
        {
            _WorldProvider = worldProvider;
        }

        public async Task<WorldUseCaseResponse> Execute(AddItemsWorldUseCaseQuery request, CancellationToken cancelToken = default)
        {
            var world = await _WorldProvider.GetWorld(request.CorrelationToken, request.Id);
            world.AddElement(request.Items);
            return new WorldUseCaseResponse(request.CorrelationToken, world);
        }
    }
}