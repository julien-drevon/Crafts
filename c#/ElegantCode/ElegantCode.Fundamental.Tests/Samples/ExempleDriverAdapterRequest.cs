using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;

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

        if (this.TheResponse == "42" || this.TheResponse == "24") return new(new(CorrelationToken, TheResponse), null);
        return new(null, new Error(CorrelationToken, "Formatage incorrect"));
    }
}