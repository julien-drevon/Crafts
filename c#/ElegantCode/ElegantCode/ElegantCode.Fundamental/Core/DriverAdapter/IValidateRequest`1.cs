using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.UsesCases;

namespace ElegantCode.Fundamental.Core.DriverAdapter
{

    public interface IValidateRequest<TUseCaseQuery> where TUseCaseQuery : IUSeCaseQuery
    {
        Guid CorrelationToken { get; }

        public (TUseCaseQuery UseCaseQuery, Error Error) ValidateRequest();
    }
}