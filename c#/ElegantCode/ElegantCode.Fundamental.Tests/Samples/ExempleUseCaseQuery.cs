namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleUseCaseQuery
{
    public ExempleUseCaseQuery(Guid correlationToken, string theResponse)
    {
        CorrelationToken = correlationToken;
        TheResponse = theResponse;
    }

    public Guid CorrelationToken { get; set; }

    public string TheResponse { get; set; }
}