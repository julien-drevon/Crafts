using ElegantCode.Fundamental.Core.UsesCases;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleUseCaseQuery : UseCaseQueryBase
{
    public ExempleUseCaseQuery(Guid correlationToken, string theResponse)
        : base(correlationToken)
    {
        TheResponse = theResponse;
    }

    public string TheResponse { get; set; }
}