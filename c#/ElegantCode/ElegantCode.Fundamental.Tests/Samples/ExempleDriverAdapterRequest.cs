using ElegantCode.Fundamental.Core;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleDriverAdapterRequest : IValidateRequest<ExempleUseCaseQuery>
{
    public ExempleDriverAdapterRequest(Guid correlationToken)
    {
        CorrelationToken = correlationToken;
    }

    public Guid CorrelationToken { get; }

    public string TheResponse { get; set; }

    public (ExempleUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
    {
        if (this.TheResponse != "42") return new(null, new Error("Formatage incorrect"));

        return new(new(CorrelationToken, TheResponse), null);
    }
}