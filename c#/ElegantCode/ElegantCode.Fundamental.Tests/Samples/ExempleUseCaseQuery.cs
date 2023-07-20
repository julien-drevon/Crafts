using ElegantCode.Fundamental.Core.UsesCases;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleUseCaseQuery : UseCaseQueryBase
{
    public ExempleUseCaseQuery(Guid correlationToken, string theResponse)
        : base(correlationToken)
    {
        CorrelationToken = correlationToken;
        TheResponse = theResponse;
    }

    public Guid CorrelationToken { get; set; }

    public string TheResponse { get; set; }
}