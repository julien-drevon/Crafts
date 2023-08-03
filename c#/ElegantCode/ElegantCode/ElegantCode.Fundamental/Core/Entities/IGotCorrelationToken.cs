namespace ElegantCode.Fundamental.Core.Entities
{
    public interface IGotCorrelationToken
    {
        Guid CorrelationToken { get; }
    }
}