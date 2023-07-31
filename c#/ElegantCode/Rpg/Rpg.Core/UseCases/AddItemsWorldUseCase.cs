using ElegantCode.Fundamental.Core.UsesCases;
using Rpg.Core.Dto;
using Rpg.Core.Providers;

namespace Rpg.Core.UseCases
{
    public class AddItemsWorldUseCase : IUseCaseAsync<AddItemsWorldUseCaseQuery, WorldUseCaseResponse>
    {
        private readonly IProvideTheWorld _WorldProvider;
        private readonly ICreateItems _ItemsFactory;

        public AddItemsWorldUseCase(IProvideTheWorld worldProvider, ICreateItems itemsFactory)
        {
            _WorldProvider = worldProvider;
            _ItemsFactory = itemsFactory;
        }

        public async Task<WorldUseCaseResponse> Execute(AddItemsWorldUseCaseQuery request, CancellationToken cancelToken = default)
        {
            var world = await _WorldProvider.GetWorld(request.CorrelationToken, request.Id);
            world.AddElement(_ItemsFactory.Do(request.Items));
            return new WorldUseCaseResponse(request.CorrelationToken, world);
        }
    }
}