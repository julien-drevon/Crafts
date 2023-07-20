using ElegantCode.Fundamental.Core;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleUseCase : IUseCaseAsync<ExempleUseCaseQuery, ExempleUseCaseResponse>
{
    public Task<ExempleUseCaseResponse> Execute(ExempleUseCaseQuery request, CancellationToken cancelToken = default)
    {
        return Task.FromResult(new ExempleUseCaseResponse(request.CorrelationToken, "42"));
    }
}