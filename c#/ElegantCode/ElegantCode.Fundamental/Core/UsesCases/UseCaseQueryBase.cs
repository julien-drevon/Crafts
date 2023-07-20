using ElegantCode.Fundamental.Core.DriverAdapter;

namespace ElegantCode.Fundamental.Core.UsesCases
{
    public class UseCaseQueryBase : IUSeCaseQuery
    {
        protected UseCaseQueryBase(Guid correlationToken)
        {
            CorrelationToken = correlationToken;
        }

        public Guid CorrelationToken { get; }
    }
}
