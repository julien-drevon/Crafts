using ElegantCode.Fundamental.Core.Entities;

namespace ElegantCode.Fundamental.Core.UsesCases;

public class UseCaseResponseBase : IGotCorrelationToken
{
    public UseCaseResponseBase(Guid correlationToken)
    {
        CorrelationToken = correlationToken;
    }

    public Guid CorrelationToken { get; }
}