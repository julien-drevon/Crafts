using ElegantCode.Fundamental.Core.UsesCases;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExampleUseCaseResponse : UseCaseResponseBase
{
    public ExampleUseCaseResponse(Guid correlationToken, string theResponse)
        : base(correlationToken)
    {
        TheResponse = theResponse;
    }

    public string TheResponse { get; }
}