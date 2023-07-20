using ElegantCode.Fundamental.Core;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.UsesCases;
using System.Runtime.Serialization;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleUseCase : IUseCaseAsync<ExempleUseCaseQuery, ExempleUseCaseResponse>
{
    public Task<ExempleUseCaseResponse> Execute(ExempleUseCaseQuery request, CancellationToken cancelToken = default)
    {
        if(request.TheResponse !="42")
        {
            throw new UseCaseExecption("La reponse Fournie n'est pas LA réponse");
        }
        return Task.FromResult(new ExempleUseCaseResponse(request.CorrelationToken, "42"));
    }
}

