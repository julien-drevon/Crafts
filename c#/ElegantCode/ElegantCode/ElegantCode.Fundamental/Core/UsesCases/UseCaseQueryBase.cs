using ElegantCode.Fundamental.Core.Entities;

namespace ElegantCode.Fundamental.Core.UsesCases;

public class UseCaseQueryBase : IGotCorrelationToken
{
    protected UseCaseQueryBase(Guid correlationToken)
    {
        CorrelationToken = correlationToken;
    }

    public virtual Guid CorrelationToken { get; }
}