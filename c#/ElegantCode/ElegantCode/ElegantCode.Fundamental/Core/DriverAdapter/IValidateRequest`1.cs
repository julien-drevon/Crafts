using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Utils;

namespace ElegantCode.Fundamental.Core.DriverAdapter
{
    public interface IValidateRequest<TUseCaseQuery> where TUseCaseQuery : IGotCorrelationToken
    {
        Guid CorrelationToken { get; }

        public (TUseCaseQuery UseCaseQuery, Error Error) ValidateRequest();
    }
}