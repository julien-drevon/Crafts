using ElegantCode.Fundamental.Core.Entities;
using ElegantCode.Fundamental.Core.Errors;

namespace ElegantCode.Fundamental.Core.DriverAdapter;

public abstract class BaseDriverAdapterRequest<TUseCaseQuery> : IValidateRequest<TUseCaseQuery>
where TUseCaseQuery : IGotCorrelationToken
{
    protected BaseDriverAdapterRequest(Guid correlationToken)
    {
        this.CorrelationToken = correlationToken;
    }

    public virtual Guid CorrelationToken { get; }

    public abstract (TUseCaseQuery UseCaseQuery, Error Error) ValidateRequest();
}