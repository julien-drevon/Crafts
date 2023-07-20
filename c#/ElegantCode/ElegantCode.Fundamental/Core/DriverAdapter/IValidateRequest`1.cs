using ElegantCode.Fundamental.Core.Errors;

namespace ElegantCode.Fundamental.Core.DriverAdapter
{
    public interface IValidateRequest<TUseCaseQuery> where TUseCaseQuery : IUSeCaseQuery
    {
        public (TUseCaseQuery UseCaseQuery, Error Error) ValidateRequest();
    }

    public interface IUSeCaseQuery
    {
        Guid CorrelationToken { get; }
    }

    public class UseCaseQueryBase : IUSeCaseQuery
    {
        protected UseCaseQueryBase(Guid correlationToken)
        {
            CorrelationToken = correlationToken;
        }

        public Guid CorrelationToken { get; }
    }
}
