namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleDriverAdapterRequest
{
    public Guid CorrelationToken { get; }

    public ExempleDriverAdapterRequest(Guid correlationToken)
    {
        CorrelationToken = correlationToken;
    }

    public string TheResponse { get; set; }
}