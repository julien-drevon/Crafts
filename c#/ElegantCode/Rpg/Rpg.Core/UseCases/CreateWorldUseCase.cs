using ElegantCode.Fundamental.Core.UsesCases;
using Rpg.Core.Dto;

namespace Rpg.Core.UseCases
{
    public class CreateWorldUseCase : IUseCaseAsync<CreateWorldUseCaseQuery, WorldUseCaseResponse>
    {
        public async Task<WorldUseCaseResponse> Execute(CreateWorldUseCaseQuery request, CancellationToken cancelToken = default)
        {
            return new WorldUseCaseResponse(request.Id, request.CorrelationToken);
        }
    }
}
