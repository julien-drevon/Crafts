using ElegantCode.Fundamental.Core.UsesCases;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleUseCase : IUseCaseAsync<ExampleUseCaseQuery, ExampleUseCaseResponse>
{
    public Task<ExampleUseCaseResponse> Execute(ExampleUseCaseQuery request, CancellationToken cancelToken = default)
    {
        if (request.TheResponse != "42")
        {
            throw new UseCaseException(request.CorrelationToken, "La reponse Fournie n'est pas LA reponse");
        }
        return Task.FromResult(new ExampleUseCaseResponse("42"));
    }
}