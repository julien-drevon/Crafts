using ElegantCode.Fundamental.Core.Errors;

namespace ElegantCode.Fundamental.Core.DriverAdapter
{
    public interface IUSeCaseQuery
    {
        Guid CorrelationToken { get; }
    }

    public interface IValidateRequest<TUseCaseQuery> where TUseCaseQuery : IUSeCaseQuery
    {
        Guid CorrelationToken { get; }

        public (TUseCaseQuery UseCaseQuery, Error Error) ValidateRequest();
    }
}