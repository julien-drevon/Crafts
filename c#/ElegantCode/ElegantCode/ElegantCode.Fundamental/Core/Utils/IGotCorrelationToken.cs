namespace ElegantCode.Fundamental.Core.Utils
{
    public interface IGotCorrelationToken
    {
        Guid CorrelationToken { get; }
    }
}