namespace ElegantCode.Fundamental.Core.UsesCases;

public class UseCaseQueryBase : IUSeCaseQuery
{
    protected UseCaseQueryBase(Guid correlationToken)
    {
        CorrelationToken = correlationToken;
    }

    public virtual Guid CorrelationToken { get; }
}