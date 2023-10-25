using ElegantCode.Fundamental.Core.Entities;
using ElegantCode.Fundamental.Core.Errors;

namespace ElegantCode.Fundamental.Core.DriverAdapter;

public interface IValidateRequest<TUseCaseQuery> where TUseCaseQuery : IGotCorrelationToken
{
    Guid CorrelationToken { get; }

    public (TUseCaseQuery UseCaseQuery, Error Error) ValidateRequest();
}