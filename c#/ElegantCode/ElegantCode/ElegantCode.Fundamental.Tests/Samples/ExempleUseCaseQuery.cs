using ElegantCode.Fundamental.Core.UsesCases;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExampleUseCaseQuery : UseCaseQueryBase
{
    public ExampleUseCaseQuery(Guid correlationToken, string theResponse)
        : base(correlationToken)
    {
        TheResponse = theResponse;
    }

    public string TheResponse { get; set; }
}