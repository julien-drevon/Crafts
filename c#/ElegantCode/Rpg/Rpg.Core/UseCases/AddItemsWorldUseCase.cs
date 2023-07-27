using ElegantCode.Fundamental.Core.UsesCases;
using Rpg.Core.Domain;
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
            return new WorldUseCaseResponse(request.Id, request.CorrelationToken) { Items = new Sprite[] { new(10, 10), new(0, 0) } };
        }
    }
}

