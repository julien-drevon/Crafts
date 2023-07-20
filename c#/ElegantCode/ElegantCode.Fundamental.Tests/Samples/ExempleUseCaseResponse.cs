namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleUseCaseResponse
{
    public ExempleUseCaseResponse(Guid correlationToken, string theResponse)
    {
        CorrelationToken = correlationToken;
        TheResponse = theResponse;
    }

    public Guid CorrelationToken { get; }

    public string TheResponse { get; }
}